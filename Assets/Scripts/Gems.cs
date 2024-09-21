using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if(playerInventory != null )
        {
            playerInventory.GemsCollected();
            playerInventory.gemPickupSound.Play(); // Play the gem pickup sound
            gameObject.SetActive(false);
        }

    }

}
