using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    public LayerMask movementMask;

    public Interactable focus;

    Camera cam;
    PlayerMotor motor;

    private void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }

        }
    }

    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        newFocus.OnFocused(transform);
        motor.FollowTarget(newFocus);
    }

    void RemoveFocus()
    {
        focus.on
        focus = null;
        motor.StopFollowingTarget();
    }
}
