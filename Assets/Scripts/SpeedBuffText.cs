using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpeedBuffText : MonoBehaviour
{
    public TextMeshProUGUI speedBoostText; // Reference to your TextMeshPro component

    private void Start()
    {
        speedBoostText.gameObject.SetActive(false); // Hide the text at the start
    }

    // Call this method to show the speed boost text
    public void ShowSpeedBoostText(float duration)
    {
        speedBoostText.gameObject.SetActive(true); // Show the text
        StartCoroutine(HideTextAfterDuration(duration)); // Start the coroutine to hide it
    }

    private IEnumerator HideTextAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration); // Wait for the specified duration
        speedBoostText.gameObject.SetActive(false); // Hide the text after the wait
    }
}
