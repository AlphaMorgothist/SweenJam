using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController 
{
    Rigidbody2D rB;
    public bool Grounded = false;

    public AIController(Rigidbody2D RB)
    {
        rB = RB;
        Init();
    }

    void Init()
    {
        
    }
    
    public void Update(Vector2 force)
    {
        rB.AddForce(force, ForceMode2D.Force);
    }

}
