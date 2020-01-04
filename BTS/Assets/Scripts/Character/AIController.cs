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

    public AIController(Rigidbody2D RB, Transform _trans)
    {
        rB = RB;
        trans = _trans;
        maxSpeed = new Vector2(1, 10);
    }

    bool IsJumping()
    {
        if (Mathf.Abs(rB.velocity.y) > 0.04f && !IsGrounded()) return true;
        else if (IsGrounded()) return false;
        else
        {
            return false;
        }
    }

    public void Update(Vector2 force, Transform _trans)
    {
        trans = _trans;
        Grounded = IsGrounded();
        if (!IsJumping())
        {
            if (Grounded)
            {
                if (rB.velocity.x > maxSpeed.x) rB.velocity = new Vector2(maxSpeed.x, rB.velocity.y);
                rB.AddForce(force, ForceMode2D.Force);
            }
            else if (!Grounded && Target && Vector2.Distance(trans.position, Target.transform.position) > 4)
            {
                rB.velocity *= 0.5f;
                TurnAround();
            }
            else if (!Grounded && Target)
            {
                rB.velocity *= 0.5f;
                Jump(Target.transform.position);
            }
            else
            {
                rB.velocity *= 0.5f;
                TurnAround();
            }
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
        RaycastHit2D hit = Physics2D.Raycast(trans.position, (trans.TransformDirection(Vector2.right) + trans.TransformDirection(Vector2.down)) * 0.5f, 1);
        if (!hit)
        {
            Debug.DrawRay(trans.position, (trans.TransformDirection(Vector2.right) + trans.TransformDirection(Vector2.down)) * 0.5f, Color.red, 0.2f);
            return false;
        }
        if (hit.collider.tag == "Ground")
        {
            Debug.DrawRay(trans.position, (trans.TransformDirection(Vector2.right) + trans.TransformDirection(Vector2.down)) * 0.5f, Color.green, 0.2f);
            return true;
        }
        else
        {
            return false;
        }
    }

    Vector3 CannonShot(Vector3 target, float angle)
    {
        Vector3 dir = target - trans.position;
        float h = dir.y;
        dir.y = 0;
        float dist = dir.magnitude;
        float a = angle * Mathf.Deg2Rad;
        dir.y = dist * Mathf.Tan(a);
        dist += h / Mathf.Tan(a);
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return vel * dir.normalized * 1.2f;
    }

    void Jump(Vector2 pos)
    {
        if (IsJumping()) return;
        rB.velocity = CannonShot(pos, 65);
        if (Vector2.Distance(trans.position, pos) < 1f)
        {
            Debug.Log("Target Wiped");
            Target = null;
        }
        //Update boolean
        IsJumping();
    }
}
