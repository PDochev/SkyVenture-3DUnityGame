using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    public float speed;
    public GameObject pivot;
  

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet; // to check if the walkpoint is already set
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;


    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;




    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range 
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;


        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
             walkPointSet = false;

    }

    private void SearchWalkPoint()
    {
        //Calculate random point in a range

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }


    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        // empty child game object look at player
        // transform.rotate based on the child's rotation on y and w
        pivot.transform.LookAt(player);
        gameObject.transform.rotation = new Quaternion(0f, pivot.transform.rotation.y, 0f, pivot.transform.rotation.w);


       

        if (!alreadyAttacked)
        {

            //Attack Code here (shooting , etc)

            // Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
           
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);  
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }



    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
           
            
        }
        //Invoke(nameof(DestroyEnemy), 0.5f);
    }



    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }



    //private void OnDrawGizmosSelected()  // Drawing the color of the Attack range and the soght range 
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, attackRange);
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, sightRange);
    //}
}


