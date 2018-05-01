using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterenceInteract : Interactable {

    [SerializeField]
    private string LevelName;

    public override void Interact()
    {
        //LevelLoader.instance.LoadLevel(LevelName);
        base.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(interactType == InteractType.Collision || interactType == InteractType.Both)
        {
            Interact();
        }
    }

}
