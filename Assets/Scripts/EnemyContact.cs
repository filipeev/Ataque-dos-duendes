using UnityEngine;
using System.Collections;

public class EnemyContact : MonoBehaviour {
    public GameController gameController;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Character")
        {
            gameController.GetEnemys();
        }
        if (other.transform.tag == "EnemyPoint")
        {
            transform.parent.gameObject.GetComponent<Enemy>().InvokePatrol();
        }
    }
}
