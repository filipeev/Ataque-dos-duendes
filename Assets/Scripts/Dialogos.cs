using UnityEngine;
using System.Collections;

public class Dialogos : MonoBehaviour {
	
	private bool dialogoKo;
	private bool primeiroDialogo;
	
	public GameObject dialogo;
	// Use this for initialization
	void Start () {
		primeiroDialogo = true;
		dialogoKo = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (primeiroDialogo && dialogo.transform.position.y < 120) {
			dialogo.transform.Translate (0f, 15f, 0f);
		} else {
			primeiroDialogo = false;
		}
		
		
		if (dialogoKo && dialogo.transform.position.y > -117) {
			dialogo.transform.Translate (0f, -15f, 0f);
		} else {
			dialogoKo = false;
		}
	}
	
	public void dialogoOk(){
		dialogoKo = true;
	}
}