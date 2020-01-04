using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = new PlayerController();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Fire"))
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                Resource resource;
                if (resource = hit.collider.GetComponent<Resource>())
                {
                    controller.SetActiveResource(resource);
                }
                TrapComponent trap;
                if (trap = hit.collider.GetComponent<TrapComponent>())
                {
                    controller.ChangeTargetTrap(trap);
                }
            }
        }
    }
}
