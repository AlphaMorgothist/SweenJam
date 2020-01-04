using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]


public class AICharacter : MonoBehaviour
{
    /* 
      DEV NOTES 
      -> Char needs to raycast
      -> Refer to point system for current objective 
            -> weigh options based on input from Stats and Status (Status first)
                -> move towards objective.

    */

    //Character-Class Members
    [SerializeField] AIController charControl;
    [SerializeField] AIStats charStats;
    [SerializeField] AIStatus charStatus;


    //Designer Members (Debug Purpose)
    [Header("Character Stats (DEBUG PURPOSE)")]
    [Range(1, 100)]
    [SerializeField] float moveSpeed;
    [Range(1, 100)]
    [SerializeField] float jumpHeight;
    [Range(0, 100)]
    [SerializeField] float health;
    [Range(1, 100)]
    [SerializeField] float recoverySpeed;
    [Space(8)]
    [Header("Character Status (DEBUG PURPOSE)")]
    [SerializeField] AIStatus.StatusType statusType;


    void Start()
    {
        charControl = new AIController(gameObject.GetComponent<Rigidbody2D>());
        charStats = new AIStats(moveSpeed, jumpHeight, health, recoverySpeed);
        charStatus = new AIStatus();

    }
    
    void Update()
    {
        
    }
}
