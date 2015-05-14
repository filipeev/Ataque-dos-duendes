using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
	
	private bool pauseGame;
	private bool showGUI;
	
	public RawImage telaPause;
	
	// Use this for initialization
	void Start () {
		pauseGame = false;
		showGUI = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			pauseGame = !pauseGame;
			
			if(pauseGame == true)
			{
				Time.timeScale = 0;
				pauseGame = true;
                GameObject.Find("Player").GetComponent<MoveController>().enabled = false;
				showGUI = true;
			}
			
			if(pauseGame == false)
			{
				Time.timeScale = 1;
				pauseGame = false;
                GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
				showGUI = false;
			}
		}
		
		if (GameObject.Find ("Dialogos").transform.position.y > 120) {
            GameObject.Find("Player").GetComponent<MoveController>().enabled = false;
			Time.timeScale = 0;
		} else if(GameObject.Find ("Dialogos").transform.position.y < 120 && !pauseGame) {
            GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
			Time.timeScale = 1;
		}
		
		if(showGUI == true)
		{
			telaPause.GetComponent<RawImage>().enabled = true;
		}
		else
		{
			telaPause.GetComponent<RawImage>().enabled = false;
		}
	}
}