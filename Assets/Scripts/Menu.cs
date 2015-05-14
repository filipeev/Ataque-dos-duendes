using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void jogar(){
		Application.LoadLevel ("Game");
	}

	public void creditos(){
		
	}

	public void sair(){
		Application.Quit ();
	}
}
