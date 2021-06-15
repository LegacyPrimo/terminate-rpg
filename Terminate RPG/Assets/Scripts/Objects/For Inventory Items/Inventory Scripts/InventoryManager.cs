using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Text descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;

    public void SetTextAndButton(string description, bool buttonActive) 
    {
        descriptionText.text = description;
        if (buttonActive)
        {
            useButton.SetActive(true);
        }
        else 
        {
            useButton.SetActive(false);
        }
    }

    void MakeInventorySlot() 
    {
        if (playerInventory != null) 
        {
            for (int i = 0; i < playerInventory.items.Count; i++) 
            {
                if (playerInventory.items[i].numberHeld > 0)
                {
                    GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlots newSlot = temp.GetComponent<InventorySlots>();
                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.items[i], this);
                    }
                }
            }
        }
    }


    // Start is called before the first frame update
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlot();
        SetTextAndButton("", false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem) 
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
    }

    public void ClearInventorySlots() 
    {
        for (int i = 0; i < inventoryPanel.transform.childCount; i++) 
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    public void UseButtonPressed() 
    {
        if (currentItem) 
        {
            currentItem.Use();
            ClearInventorySlots();
            MakeInventorySlot();
            if (currentItem.numberHeld == 0) 
            {
                SetTextAndButton("", false);
            }
        }
    }
}
