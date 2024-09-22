using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        Debug.Log("game is reloaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("game is quit");
        Application.Quit();
    }
}
