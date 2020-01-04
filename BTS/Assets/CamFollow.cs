using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] GameObject toFollow;
    
    void Update()
    {
        transform.position = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y, -10);    
    }
}
