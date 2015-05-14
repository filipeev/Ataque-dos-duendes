using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private NavMeshAgent agent;

    public Transform player;
    public int life;
    public GameObject[] PatrolPoints;
    public float patrolTime;
    public bool playerInArea;
    private int randomPoint, oldPoint;
	// Use this for initialization


	// Use this for initialization
	void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
        Patrol();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Patrol()
    {
        oldPoint = randomPoint;
        randomPoint = Random.Range(0, PatrolPoints.Length);
        if (oldPoint != randomPoint)
        {
            agent.SetDestination(PatrolPoints[randomPoint].transform.position);
        }
        else
        {
            Patrol();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EnemyPoint" && !playerInArea)
        {
            Invoke("Patrol", patrolTime);
        }
        if (other.transform.tag == "Player")
        {
            playerInArea = true;
            PursuePlayer();
        }
    }

    void PursuePlayer()
    {
        agent.SetDestination(player.transform.position);
    } 
}
