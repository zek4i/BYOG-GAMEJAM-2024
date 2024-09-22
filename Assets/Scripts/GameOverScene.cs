using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your player has the tag "Player"
        {
            // Call the method to change to the Game Over scene
            SceneManager.LoadScene(1);
        }

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
