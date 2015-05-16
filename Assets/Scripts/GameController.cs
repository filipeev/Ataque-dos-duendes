using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject[] Enemys;
    public ArrayList type, life;
    public int persuers;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

	void Start () {
	
	}

    public void GetEnemys()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(Enemys.Length);

        foreach (GameObject EnemyBody in Enemys)
        {
            Enemy tempEnemy = EnemyBody.GetComponent<Enemy>();
            if (tempEnemy.playerInArea || tempEnemy.chasing)
            {
                type.Add(tempEnemy.type);
                life.Add(tempEnemy.life);
            }
        }
    }

	void Update () {
	
	}

    public void CombatMode()
    {
        Application.LoadLevel("Combat");
    }
}
