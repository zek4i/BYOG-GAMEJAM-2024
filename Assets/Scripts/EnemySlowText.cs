using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySlowText : MonoBehaviour
{

    public TextMeshProUGUI enemySlowText; // Reference to your TextMeshPro component

    private void Start()
    {
        enemySlowText.gameObject.SetActive(false); // Hide the text at the start
    }

    // Call this method to show the enemy slow text
    public void ShowEnemySlowText(float duration)
    {
        enemySlowText.gameObject.SetActive(true); // Show the text
        StartCoroutine(HideTextAfterDuration(duration)); // Start the coroutine to hide it
    }

    private IEnumerator HideTextAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration); // Wait for the specified duration
        enemySlowText.gameObject.SetActive(false); // Hide the text after the wait
    }
}