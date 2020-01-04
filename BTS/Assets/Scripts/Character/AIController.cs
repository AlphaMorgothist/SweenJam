using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController
{
    Rigidbody2D rB;
    Transform trans;
    public bool Grounded = false;
    public GameObject Target = null;

    public bool Jumping { get; private set; }

    public AIController(Rigidbody2D RB, Transform _trans)
    {
        rB = RB;
        trans = _trans;
    }

    bool IsJumping()
    {
        if (rB.velocity.y > 0) return true;
        else if (IsGrounded() && !Jumping) return false;
        else
        {
            Jumping = false;
            return false;
        }
    }

    public void Update(Vector2 force)
    {
        Grounded = IsGrounded();
        if (Grounded)
        {
            rB.AddForce(force, ForceMode2D.Force);
        }
        else if (!Grounded && Mathf.Abs(rB.velocity.y) < 0.4f && Target == null)
        {
            TurnAround();
        }
        else if (Target && !IsJumping())
        {
            Jump(Target.transform.position);
        }
    }

    void TurnAround()
    {
        Vector2 rot = trans.localEulerAngles;
        rot.y += 180;
        trans.localEulerAngles = rot;
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(trans.position, trans.TransformDirection(Vector2.right) + trans.TransformDirection(Vector2.down), 1);
        Debug.DrawRay(trans.position, trans.TransformDirection(Vector2.right) + trans.TransformDirection(Vector2.down), Color.gray, 0.8f);
        if (!hit) return false;
        if (hit.collider.tag == "Ground")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Jump(Vector2 pos)
    {
        Jumping = true;
        Vector2 p = pos;
        float gravity = Physics.gravity.magnitude;
        float initialAngle = trans.TransformDirection(Vector2.right).z;
        float angle = (pos.x > trans.position.x) ? 45 : -45;
        angle *= Mathf.Deg2Rad;
        Vector3 planarTarget = new Vector3(p.x, p.y, 0);
        Vector3 planarPostion = new Vector3(trans.position.x, trans.position.y, 0);
        float distance = Vector2.Distance(planarTarget, planarPostion);
        float yOffset = trans.position.y - p.y;
        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));
        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));        
        float angleBetweenObjects = Vector2.Angle(Vector2.right, planarTarget - planarPostion);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector2.up) * velocity;
        //rB.AddForce(finalVelocity * rB.mass, ForceMode2D.Impulse);
        rB.velocity = finalVelocity * 1.2f;
        if (Vector2.Distance(trans.position, pos) > 2f)
        {
            Debug.Log(Vector2.Distance(trans.position, pos));
        }
        else
        {
            Debug.Log("Target Wiped");
            rB.velocity = rB.velocity * 0.5f;
            Target = null;
        }
    }
}
