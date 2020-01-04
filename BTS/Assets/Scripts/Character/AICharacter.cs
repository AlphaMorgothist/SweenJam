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

    //Class Functionality Members
    bool thinking = false;

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
    [Space(8)]
    [Header("Raycast Check Tags")]
    [SerializeField] string groundTag;
    [SerializeField] string trapTag;
    [SerializeField] string lootTag;
    [SerializeField] string useTag;

    // Add raycast sight members
    Transform trans;
    float scanDelay;

    void Start()
    {
        trans = transform;
        charControl = new AIController(gameObject.GetComponent<Rigidbody2D>());
        charStats = new AIStats(moveSpeed, jumpHeight, health, recoverySpeed);
        charStatus = new AIStatus();

    }
    
    void Update()
    {
        if (!thinking)
        {
            StartCoroutine(Think());
        }
    }

    /// <summary>
    /// Called in update to prepare a viable output for a force vector (given to AIControlller)
    /// </summary>
    IEnumerator Think()
    {
        thinking = true;

        //Raycast here (Grounding Raycast + Objective-Searching Raycast)

        List<Vector2> Objectives = new List<Vector2>();
        List<GameObject> SeenObjects = new List<GameObject>();
        for (int i = 0; i < 359; i++)
        {            
            Vector3 dir = trans.rotation.eulerAngles;
            dir = new Vector3(dir.x, dir.y + i, dir.z);
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, dir, jumpHeight);
            if (hits.Length > 1)
            {
                foreach (var hit in hits)
                {
                    if (hit.collider.tag == groundTag)
                    {
                        //Add hit ground to list of seen objects IF we aren't already standing on it
                        //Lists for: Platforms, traps, ladders, chests
                        //Seen = true;
                       // positions.Add(hit.point);
                        Debug.DrawRay(transform.position, dir * jumpHeight, Color.blue, 0.8f, false);
                    }
                }
            }
            yield return new WaitForSeconds(scanDelay);

        }

        //Make list of viable targets (based on object tag)
        //Check Status to see if we are feared, if so we just randomly run and forget the rest of this process
        //Equate cost of each listed action using Stats to mod costs
        //Move towards target
        //If Arrived at target, use (Ladder, chest, etc)
        
    }

}
