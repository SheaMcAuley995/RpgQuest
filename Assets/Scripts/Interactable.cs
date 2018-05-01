using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractType {Collision , Interact, Both }


public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

<<<<<<< HEAD
    public InteractType interactType;

=======
>>>>>>> 2d540326b4e897daf6d6d411b305a49cc6f9d8c0
    bool hasInteracted = false;
    public virtual void Interact ()
    {

        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance<=radius)
            {
                Interact();
                Debug.Log("INTERACT");
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmos()
    {
        if (interactionTransform == null)
            interactionTransform = transform;


        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

}
