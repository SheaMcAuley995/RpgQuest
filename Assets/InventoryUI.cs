using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    [SerializeField]
    public GameObject inventoryUI;

    InventorySlot[] slots;

    Inventory inventory;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

	}

    private void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            Debug.Log("Inventory button");
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
            
        }

    }
}
