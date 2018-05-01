using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable {

    PlayerManager playerManager;
    CharacterStats myStats;


    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
<<<<<<< HEAD
    { 
=======
    {
        
>>>>>>> 2d540326b4e897daf6d6d411b305a49cc6f9d8c0
        base.Interact();

        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }

}
