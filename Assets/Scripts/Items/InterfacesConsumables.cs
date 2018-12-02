using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InterfacesConsumables
{

    public interface IItemizable
    {
        void Use(GameObject player); // to use the item, we give it the game object of the player that wants to use it so that it can do changes on it
        void PickedUp(); // makes it disappear from the world, some special effect when picked up
        void Drop(); // drops the item, making it reappear in the world
    }

}
