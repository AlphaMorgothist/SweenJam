using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]


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
    [SerializeField] bool grounded = false;
    Dictionary<GameObject, float> pointDict;

    //Designer Members (Debug Purpose)
    [Header("Character Stats (DEBUG PURPOSE)")]
    [Range(1, 100)]
    [SerializeField] float moveSpeed;
    [Range(1, 100)]
    [SerializeField] float jumpHeight;
    [Range(0, 3)]
    [SerializeField] float health;
    [Range(1, 100)]
    [SerializeField] float recoverySpeed;
    [Space(8)]
    [Header("Character Status (DEBUG PURPOSE)")]
    [SerializeField] AIStatus.StatusType statusType;
    [Space(8)]
    [Header("Raycast Check Tags, ref-only do not edit")]
    [SerializeField] string groundTag;
    [SerializeField] string trapTag;
    [SerializeField] string lootTag;
    [SerializeField] string useTag;

    // Declare 'sight' detection members
    Transform trans;
    float scanDelay = 0.4f;
    GameObject currentGround = null;
    List<GameObject> touchedPlats;

    //John's Status Getter/Setter
    public AIStatus CharStatus { get => charStatus; set => charStatus = value; }

    //Animator Getter
    public Animator CharAnim { get => GetComponent<Animator>(); }

    void Start()
    {
        trans = transform;
        charControl = new AIController(gameObject.GetComponent<Rigidbody2D>(), trans);
        pointDict = new Dictionary<GameObject, float>();
        charStats = new AIStats(moveSpeed, jumpHeight, health, recoverySpeed);
        charStatus = new AIStatus();
        touchedPlats = new List<GameObject>();
    }
    
    void Update()
    {
        charControl.Update(trans.TransformDirection(Vector2.right) * moveSpeed);
        grounded = charControl.Grounded;
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
        //ClearLog();
        //Check Status to see if we are feared, if so we just randomly run and forget the rest of this process

        GameObject finalObjective;
        List<GameObject> seenObjects = new List<GameObject>();
        pointDict.Clear();

        Collider2D[] hits = Physics2D.OverlapCircleAll(trans.position, jumpHeight);
        if (hits.Length >= 1)
        {
            //Lists for: Platforms, traps, ladders, chests
            foreach (var hit in hits)
            {
                switch (hit.tag)
                {
                    case "Ground":
                        if (hit.gameObject == currentGround) break;
                        RaycastHit2D[] rayHits = Physics2D.RaycastAll(trans.position, hit.transform.position);
                        if (rayHits.Length > 0)
                        {
                            if (rayHits[0].collider != hit && rayHits[0].collider.gameObject.tag != hit.gameObject.tag)
                            {
                                Debug.Log("Object obstructed by: " + rayHits[0].transform.gameObject);
                                break;
                            }
                            seenObjects.Add(hit.gameObject);
                            Debug.Log("New Ground Detected");
                            Debug.DrawRay(trans.position, hit.transform.position - trans.position, Color.blue, 0.8f, false);
                        }
                        break;
                    case "Trap":
                        break;
                    case "Use":
                        break;
                    case "Loot":
                        break;
                    default:
                        break;
                }
            }
        }
        // Call Point Function: Calculate final Objective
        finalObjective = TallyPoints(seenObjects, pointDict);
        if (finalObjective == currentGround || touchedPlats.Contains(finalObjective)) charControl.Target = null;
        else charControl.Target = finalObjective;
        yield return new WaitForSeconds(scanDelay);
        thinking = false;
    }

    #region Utility
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 250, 250, 0.2f);
        Gizmos.DrawSphere(trans.position, jumpHeight);
    }

    private void OnGUI()
    {
        foreach (var aObject in pointDict)
        {
            GUI.color = Color.black;
            Vector2 platPoint = Camera.main.WorldToScreenPoint(aObject.Key.transform.position);
            GUI.Label(new Rect(platPoint.x, Screen.height - platPoint.y - 25, 100, 50), (Mathf.Floor(aObject.Value * 100) / 100).ToString());
        }
    }


    
    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
    #endregion This Shit is all for testing

    GameObject TallyPoints(List<GameObject> SeenObjects, Dictionary<GameObject, float> pointDict)
    {
        float pointCost = 0;
        foreach (var gObject in SeenObjects)
        {
            pointCost += Vector2.Distance(trans.position, gObject.transform.position) * 10;
            switch (gObject.tag)
            {
                case "Ground":
                    if (gObject.transform.position.y > trans.position.y)
                    {
                        pointCost *= 0.9f;
                    }
                    else
                    {
                        pointCost *= 5;
                    }
                    break;
                case "Trap":
                    pointCost *= 3f;
                    break;
                case "Use":
                    pointCost *= 0.4f;
                    break;
                case "Loot":
                    pointCost *= 0.5f;
                    break;
                default:
                    break;
            }
            pointDict.Add(gObject, pointCost);
        }
        float lowPoint = 0;
        GameObject temp = null;
        if (pointDict.Count < 1) return null;
        foreach (var keyVal in pointDict)
        {
            if (lowPoint == 0)
            {
                lowPoint = keyVal.Value;
                temp = keyVal.Key;
            }
            else if (keyVal.Value < lowPoint)
            {
                lowPoint = keyVal.Value;
                temp = keyVal.Key;
            }
        }
        Debug.Log("Target: " + temp);
        return temp;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && collision.gameObject.transform.position.y < trans.position.y)
        {
            currentGround = collision.gameObject;
            charControl.Grounded = true;
            touchedPlats.Add(currentGround);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && collision.gameObject.transform.position.y < trans.position.y)
        {
            currentGround = null;
            //charControl.Grounded = false;
        }
    }

    public void DamageChar(float amount)
    {
        charStats.AffectStat(AIStats.StatType.hp, amount, true);
    }

    public void HealChar(float amount)
    {
        charStats.AffectStat(AIStats.StatType.hp, amount, false);
    }

}
