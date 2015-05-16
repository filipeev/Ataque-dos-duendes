using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private NavMeshAgent agent;

    public Transform player;
    public int life, type;
    public GameObject[] PatrolPoints;
    public float patrolTime;
    public bool playerInArea, chasing, patrolling;
    private int randomPoint, oldPoint;
	// Use this for initialization


	// Use this for initialization
	void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
        Patrol();
	}
	
	// Update is called once per frame
	void Update () {
        PursuePlayer();
	}

    public void InvokePatrol(){
        if (!playerInArea)
        {
            Invoke("Patrol", patrolTime);            
        }
    }

    void Patrol()
    {
        if (!playerInArea)
        {
            oldPoint = randomPoint;
            randomPoint = Random.Range(0, PatrolPoints.Length);
            if (oldPoint != randomPoint)
            {
                agent.SetDestination(PatrolPoints[randomPoint].transform.position);
                patrolling = true;
            }
            else
            {
                Patrol();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy" && playerInArea)
        {
            GameObject otherEnemy = other.gameObject;
            if (!otherEnemy.GetComponent<Enemy>().chasing && !otherEnemy.GetComponent<Enemy>().playerInArea)
            {
                otherEnemy.GetComponent<Enemy>().ChaseGroup();                
            }
        }
        if (other.transform.tag == "Player")
        {
            playerInArea = true;
            chasing = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playerInArea = false;
        }
        if (other.transform.tag == "Enemy" && !playerInArea)
        {
            chasing = false;
            GameObject otherEnemy = other.gameObject;
            otherEnemy.GetComponent<Enemy>().ChaseGroup();
        }
    }

    public void ChaseGroup()
    {
        chasing = true;
    }

    public void LeaveGroup()
    {
        chasing = false;
    }

    void PursuePlayer()
    {
        if (playerInArea || chasing)
        {
            patrolling = false;
            agent.SetDestination(player.transform.position);
        }
        else if(!patrolling)
        {
            patrolling = true;
            Patrol();
        }
    } 
}
