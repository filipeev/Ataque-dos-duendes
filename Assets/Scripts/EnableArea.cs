using UnityEngine;
using System.Collections;

public class EnableArea : MonoBehaviour {
    public Enemy enemy;
	// Use this for initialization
	void Start () {
        
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.characterInArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.characterInArea = false;
        }
    }
}
