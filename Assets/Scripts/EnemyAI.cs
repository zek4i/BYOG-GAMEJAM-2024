using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private float stoppingDistance = 2f;

    private NavMeshAgent navMeshAgent;
    private bool isChasing = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Ensure you have a NavMeshAgent component attached
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // Calculate distance between player and enemy

        if (distanceToPlayer <= detectionRadius && !IsPlayerLookingAtEnemy())
        {
            StartChasing(); // Start chasing the player
        }
        else if (isChasing && distanceToPlayer > stoppingDistance)
        {
            ContinueChasing(); // Keep chasing the player
        }
        else if (isChasing && distanceToPlayer <= stoppingDistance)
        {
            StopChasing(); // Stop when too close to the player
        }

        if (IsPlayerLookingAtEnemy())
        {
            StopChasing(); // Stop chasing if the player is looking at the enemy
        }
    }

    void StartChasing()
    {
        isChasing = true;
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(player.position); // Set the player's position as the destination
    }

    void ContinueChasing()
    {
        navMeshAgent.SetDestination(player.position); // Continuously update the destination
    }

    void StopChasing()
    {
        isChasing = false;
        navMeshAgent.isStopped = true; // Stop the agent's movement
    }

    bool IsPlayerLookingAtEnemy()
    {
        Vector3 directionToEnemy = (transform.position - player.position).normalized; // Calculate the direction from player to enemy
        float dotProduct = Vector3.Dot(player.forward, directionToEnemy); // Check if the player is looking at the enemy
        return dotProduct > 0.5f; // Returns true if the player is facing the enemy
    }

    void OnDrawGizmosSelected()
    {
        // Display detection radius when the object is selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
