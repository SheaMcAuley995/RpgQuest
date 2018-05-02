using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : Interactable {

    public override void Interact()
    {
        StartCoroutine(LookAtTarget(GameObject.FindGameObjectWithTag("Player").transform));
        DialogueManager.instance.StartDialogue(GetComponent<DialogueTrigger>().dialogue);
        base.Interact();
    }

    IEnumerator LookAtTarget(Transform target)
    {
        GetComponent<Transform>().LookAt(new Vector3(0, target.position.y,0));
        yield return null;
    }
}
