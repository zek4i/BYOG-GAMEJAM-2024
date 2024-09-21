using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;



public class PlayerInventory : MonoBehaviour
{
    public int gemCount = 0; // Track how many gems have been collected
    public int gemsToActivateSpeedBoost = 5; // Number of gems required to activate speed boost
    public float boostMultiplier = 2.5f; // Speed boost multiplier
    public float boostDuration = 5f; // Duration of the speed boost
    public int totalGemsCollected = 0; // New variable to track total gems collected

    private FirstPersonController playerController;
    public int gemsToSlowEnemies = 15; // Number of gems required to slow enemies
    [SerializeField] public float enemySlowMultiplier = 0.5f; // Multiplier to slow enemies

    public SpeedBuffText playerUI; // Reference to PlayerUI
    public EnemySlowText enemySlowUI;

    public AudioSource gemPickupSound; // Reference to the AudioSource for the gem pickup sound

    // New variable to track gems for slowing enemies
    private int enemySlowGemCount = 0;

    private void Start()
    {
        // Get reference to the FirstPersonController component
        playerController = GetComponent<FirstPersonController>();

    }

    public int NumberOfGems
    {
        get;
        private set;
    }

    public UnityEvent<PlayerInventory> OnGemsCollected;

    public void GemsCollected()
    {
        gemCount++;
        totalGemsCollected++; // Increment the total gems collected
        enemySlowGemCount++; // Increment the slow gem count
        Debug.Log("Total Gems Collected: " + totalGemsCollected);

        // Check if the gem count is equal to or exceeds the required number to activate the speed boost
        if (gemCount >= gemsToActivateSpeedBoost)
        {
            playerController.ApplySpeedBoost(boostMultiplier, boostDuration);
            Debug.Log("Speed boost activated!"); // Add debug log
            playerUI.ShowSpeedBoostText(boostDuration);
            gemCount = 0; // Reset the gem count after the boost (optional)
        }

        // Check if gems collected for slowing down enemies
        if (enemySlowGemCount >= gemsToSlowEnemies)
        {
            Debug.Log("15 gems collected, applying slow effect to enemies."); // Confirm the call
            SlowDownEnemies(); // Call the slow down method
            enemySlowGemCount = 0; // Reset the slow gem count after applying effect
        }



        NumberOfGems++; // If this property is used somewhere else
        OnGemsCollected.Invoke(this);
    }

    private void SlowDownEnemies()
    {
        EnemyAI[] enemies = FindObjectsOfType<EnemyAI>(); // Find all enemies in the scene

        if (enemies.Length == 0)
        {
            Debug.Log("No enemies found to slow down!"); // Debug if no enemies are found
        }
        else
        {
            Debug.Log(enemies.Length + " enemies found, applying slow effect"); // Log how many enemies are found
        }

        foreach (EnemyAI enemy in enemies)
        {
            Debug.Log("Slowing down enemy: " + enemy.name); // Log each enemy's name to ensure they're being affected
            enemy.SlowDown(enemySlowMultiplier); // Slow down each enemy
        }
        enemySlowUI.ShowEnemySlowText(3f);
    }

}

