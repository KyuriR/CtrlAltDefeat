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
    public bool playerInSightRange, playerInAttackRange;

    public float chaseSpeed = 3.5f;
    public float patrolSpeed = 2f;
    public float stopDistance = 1.5f;

    public GameObject PlayerOB;
    public GameObject Checkpoint;
    private Vector3 respawnPoint;

    //public bool isDead;

    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        respawnPoint = Checkpoint.transform.position;
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
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

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        Agent.speed = chaseSpeed;
        Agent.stoppingDistance = stopDistance;

        if (Vector3.Distance(transform.position, Player.position) > stopDistance)
        {
            Agent.SetDestination(Player.position);
        }
        else
        {
            Agent.ResetPath();
        }
    }

    private void AttackPlayer()
    {
        Agent.SetDestination(transform.position);

        transform.LookAt(Player);

        if (!alreadyAttacked)
        {

            alreadyAttacked = true;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Move the player to the respawn point
            other.transform.position = respawnPoint;
            Debug.Log("Player respawned at checkpoint.");
        }
    }


}