using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ExitDoor : MonoBehaviour
{
    public GameObject exitDoor; // Reference to the exit door object
    public PlayerInventory playerInventory;
    public TextMeshProUGUI messageTextPro;// Reference to the PlayerInventory
    public string escapeSceneName = "YouHaveEscaped";

    private void Start()
    {  
        // Optionally, you can ensure the exit door is initially active
        if (exitDoor != null)
        {
            exitDoor.SetActive(true); // Make sure the exit door is visible at the start
        }
        if (messageTextPro != null)
        {
            messageTextPro.text = ""; // Clear any existing text on screen
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player has entered the trigger
        {
            if (playerInventory.totalGemsCollected >= 30) // Check if the player has collected enough gems
            {
                StartCoroutine(ShowMessageAndLoadScene("The exit door is unlocked!", 0f, escapeSceneName));
                Debug.Log("The exit door is unlocked!");
            }
            else
            {
                StartCoroutine(ShowMessage("You need 30 gems to unlock the door.", 2f));
                Debug.Log("You need more gems to unlock the door.");
            }
        }
    }
    private IEnumerator ShowMessageAndLoadScene(string message, float delay, string sceneName)
    {
        messageTextPro.text = message; // Display the message
        yield return null; // Wait for a frame to show the message
        SceneManager.LoadScene(sceneName);
    }
    private IEnumerator ShowMessage(string message, float delay)
    {
        messageTextPro.text = message; // Display the message
        yield return new WaitForSeconds(delay); // Wait for the specified duration (2 seconds)
        messageTextPro.text = ""; // Clear the message
        
    }
}

