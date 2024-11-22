using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIScript : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Player;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange;

    public float chaseSpeed = 3.5f;
    public float patrolSpeed = 2f;

    public GameObject Checkpoint;
    private Vector3 respawnPoint;

    public AudioClip attackSound; 
    private AudioSource audioSource;

    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
        Agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>(); 
    }

    private void Start()
    {
        respawnPoint = Checkpoint.transform.position;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange) ChasePlayer();
        else Patroling();
    }

    private void Patroling()
    {
        Agent.speed = patrolSpeed;

        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            Agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint + Vector3.up * 2, Vector3.down, 4f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        Agent.speed = chaseSpeed;

        Agent.SetDestination(Player.position);

        if (Vector3.Distance(transform.position, Player.position) <= attackRange)
        {
            AttackPlayer();
            audioSource.PlayOneShot(attackSound);
        }
    }

    private void AttackPlayer()
    {
        Agent.ResetPath(); 

        transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));

        if (!alreadyAttacked)
        {
            if (attackSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(attackSound);
            }

            Debug.Log("Enemy attacks the player");

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), 1f); 
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
                other.transform.position = respawnPoint; 
                controller.enabled = true;
            }
            else
            {
                other.transform.position = respawnPoint; 
            }

            Debug.Log("Player respawned at checkpoint.");
        }
    }
}