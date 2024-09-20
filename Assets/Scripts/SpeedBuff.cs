using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SpeedBuff : MonoBehaviour
{
    public float boostMultiplier = 1.5f; // The amount by which to increase speed
    public float boostDuration = 5f;     // How long the boost lasts

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Try to get the FirstPersonController component and apply the speed boost
            FirstPersonController playerController = other.GetComponent<FirstPersonController>();
            if (playerController != null)
            {
                playerController.ApplySpeedBoost(boostMultiplier, boostDuration);
            }

            Destroy(gameObject); // Destroy the speed buff object after it's picked up
        }
    }
}

