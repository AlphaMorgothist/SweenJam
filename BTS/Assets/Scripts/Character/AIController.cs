using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController
{
    Rigidbody2D rB;
    Transform trans;
    public bool Grounded = false;
    public GameObject Target = null;
    public Vector2 maxSpeed;

    public bool Jumping { get; private set; }

    public AIController(Rigidbody2D RB, Transform _trans)
    {
        rB = RB;
        trans = _trans;
        maxSpeed = new Vector2(1, 10);
    }

    bool IsJumping()
    {
        if (Mathf.Abs(rB.velocity.y) > 0.1f) return true;
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
            if (rB.velocity.x > maxSpeed.x) rB.velocity = new Vector2(maxSpeed.x, rB.velocity.y);
            rB.AddForce(force, ForceMode2D.Force);
        }
        else if (!Grounded && Target && !IsJumping())
        {
            rB.velocity *= 0.5f;
            Jump(Target.transform.position);
        }
        else
        {
            TurnAround();
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
        float initialAngle = trans.TransformDirection(Vector2.right).x * Mathf.Deg2Rad;
        float angle = (pos.x > trans.position.x) ? 45 : -45;
        angle *= Mathf.Deg2Rad;
        Vector3 planarTarget = new Vector3(p.x, p.y, 0);
        Vector3 planarPostion = new Vector3(trans.position.x, trans.position.y, 0);
        float distance = Vector2.Distance(planarTarget, planarPostion);
        float yOffset = trans.position.y - p.y;
        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));
        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));        
        float angleBetweenObjects = Vector2.Angle(trans.TransformDirection(Vector2.right), planarTarget - planarPostion);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector2.up) * velocity;
        //rB.AddForce(finalVelocity * rB.mass * 5, ForceMode2D.Impulse);
        rB.velocity = finalVelocity * 1.4f;
        if (Vector2.Distance(trans.position, pos) > 3f || IsJumping())
        {
            Debug.Log(Vector2.Distance(trans.position, pos));
        }
        else
        {
            Debug.Log("Target Wiped");
            Target = null;
        }
    }
}
