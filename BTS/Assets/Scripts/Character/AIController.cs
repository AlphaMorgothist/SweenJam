using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController 
{
    Rigidbody2D rB;

    public AIController(Rigidbody2D RB)
    {
        rB = RB;
        Start();
    }

    void Start()
    {
        
    }
    
    public void Update(Vector2 force)
    {
        rB.AddForce(force, ForceMode2D.Force);
    }
}
