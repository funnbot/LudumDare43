using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Tooltip("Number of items the inventory can have.")]
    public int inventorySize;

    InterfacesConsumables.IItemizable[] inventory;
    int itemsCarried = 0;

    private void Awake() 
    {
        // initialize inventory with size we want it to have
        inventory = new InterfacesConsumables.IItemizable[inventorySize-1];
    }

    public void UseItem(int slot) // receives the slot of the item we want to use, decrement the int itemsCarrier and calls the use function on the item with our players gameObject
    {
        itemsCarried--;
        inventory[slot].Use(gameObject);
    }

    public void DropItem(int slot) // receives the slot of the item we want to drop, decrease itemsCarried int and call that item's drop function for it to reappear in the world
    {
        itemsCarried--;
        inventory[slot].Drop();
    }

    public void PickedUpItem(InterfacesConsumables.IItemizable item)
    {
        if (!IsFull()) // if inventory isn't full, we increment number of items on it and add the item we want to pick up to the next free slot
        {
            itemsCarried++;

            int slot = FreeSlot();
            inventory[slot] = item;
            item.PickedUp(); // make it disappear from the world by calling function PickedUp()

        }
        else
        {
            Debug.Log("Inventory Full!!!");
        }
    }

    public bool IsFull() // returns true if there aren't open spaces, false if we have space to store new items
    {
        if(itemsCarried == inventorySize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    int FreeSlot() // returns the next free slot in the inventory array
    {
        int slot = 0; // we have to initialize the int with some number

        for(int i = 0;i < inventory.Length; i++) // goes through all the inventory slots, if it finds one with nothing, updates the slot integer to that number
        {
            if(inventory[i] == null)
            {
                slot = i;
                break;
            }
        }

        return slot; // returns the slot number
    }


}
