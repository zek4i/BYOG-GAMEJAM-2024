using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private float stoppingDistance = 2f;

    public float detectionRange = 2f;
    private DeathHandler deathHandler;

    private NavMeshAgent navMeshAgent;
    private bool isChasing = false;
    private Animator animator;
    private float originalSpeed;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        originalSpeed = navMeshAgent.speed; // Store the original speed
        deathHandler = player.GetComponent<DeathHandler>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius && !IsPlayerLookingAtEnemy())
        {
            StartChasing();
        }
        else if (isChasing && distanceToPlayer > stoppingDistance)
        {
            ContinueChasing();
        }
        else if (isChasing && distanceToPlayer <= stoppingDistance)
        {
            StopChasing();
        }

        if (IsPlayerLookingAtEnemy())
        {
            StopChasing();
        }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your player has the tag "Player"
        {
            // Call the method to change to the Game Over scene
            SceneManager.LoadScene("GameOverScene");
        }

    }

        public void SlowDown(float slowMultiplier)
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.speed /= slowMultiplier; // Slow down the enemy
            StartCoroutine(ResetSpeedAfterDelay(3f)); // Reset speed after 3 seconds
            Debug.Log("enemies slowed for 3 seconds boi");
           
        }
        else
        {
            Debug.LogWarning("NavMeshAgent not found on enemy: " + gameObject.name);
        }
    }
    private IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified duration
        navMeshAgent.speed = originalSpeed; // Reset to original speed
    }
    void StartChasing()
    {
        animator.SetBool("IsMoving", true);
        isChasing = true;
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(player.position);
    }

    void ContinueChasing()
    {
        animator.SetBool("IsMoving", true);
        navMeshAgent.SetDestination(player.position);
    }

    void StopChasing()
    {
        animator.SetBool("IsMoving", false);
        isChasing = false;
        navMeshAgent.isStopped = true;
    }

    bool IsPlayerLookingAtEnemy()
    {
        Vector3 directionToEnemy = (transform.position - player.position).normalized;
        float dotProduct = Vector3.Dot(player.forward, directionToEnemy);
        return dotProduct > 0.5f;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}