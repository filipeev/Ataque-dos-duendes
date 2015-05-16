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
			
			if(pauseGame == true){
				paused();
			}
			
			if(pauseGame == false){
				unPaused();
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
			GameObject.Find("bt_continue").transform.position = new Vector2(718.5f, 201.9f);
			GameObject.Find("bt_menu_inicial").transform.position = new Vector2(718.5f, 137.5f);
		}
		else
		{
			telaPause.GetComponent<RawImage>().enabled = false;
			GameObject.Find("bt_continue").transform.position = new Vector2(0f, -1000f);
			GameObject.Find("bt_menu_inicial").transform.position = new Vector2(0f, -1000f);
		}
	}

	void paused(){
		Time.timeScale = 0;
		pauseGame = true;
		GameObject.Find("Player").GetComponent<MoveController>().enabled = false;
		showGUI = true;
	}

	void unPaused(){
		Time.timeScale = 1;
		pauseGame = false;
		GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
		showGUI = false;
	}

	public void continuar(){
		unPaused ();
	}

	public void irParaMenu(){
		Application.LoadLevel ("Menu inicial");
	}
}