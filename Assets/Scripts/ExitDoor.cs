using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitDoor : MonoBehaviour
{
    public GameObject exitDoor; // Reference to the exit door object
    public PlayerInventory playerInventory; // Reference to the PlayerInventory

    private void Start()
    {
        // Optionally, you can ensure the exit door is initially active
        if (exitDoor != null)
        {
            exitDoor.SetActive(true); // Make sure the exit door is visible at the start
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player has entered the trigger
        {
            if (playerInventory.totalGemsCollected >= 30) // Check if the player has collected enough gems
            {
                Debug.Log("The exit door is unlocked!"); // Log when the door is unlocked
                //exitDoor.SetActive(false); // Hide the exit door
                // Optionally, show a message to the player here
            }
            else
            {
                Debug.Log("You need more gems to unlock the door."); // Log if not enough gems
            }
        }
    }
}

