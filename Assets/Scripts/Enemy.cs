using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public MoveController moveController;
    public Transform player, combatPosition;
    public Camera combatCamera;
    public Canvas menu, talk;
    public int life;
    public bool characterInArea;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(player);
	}

  /*  void OnMouseDown()
    {
        if (characterInArea)
        {
            OpenMenu();
        }
        else
        {
            Debug.Log("entrou");
            moveController.MoveFunction();
            moveController.goPosition = combatPosition.transform.position;
            moveController.ableMove = false;
        }
    }

    void OpenMenu()
    {
        if (Camera.main.enabled)
        {
            Camera.main.enabled = false;
        }
        menu.enabled = true;
        moveController.canMove = false;
        player.transform.position = combatPosition.transform.position;
        player.transform.rotation = combatPosition.transform.rotation;
    }

    public void Talk()
    {
        talk.enabled = true;
        menu.enabled = false;
        Invoke("OpenMenu", 2);
    }*/

}
