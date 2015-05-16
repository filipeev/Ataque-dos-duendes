using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventario : MonoBehaviour {

	public int money;
	public int arma;

	public bool itemSuborno;
	
	public Text moneyText;


	// Use this for initialization
	void Start () {
		money = 100;
		arma = 0;
		itemSuborno = false;
	}
	
	// Update is called once per frame
	void Update () {

		moneyText.GetComponent<Text> ().text = money.ToString ();

		if (arma == 1) {
			//animacao jogador com arma 1
			//acoes  arma 1
		}

		if (arma == 2) {
			//animacao jogador com arma 2
			//acoes  arma 2
		}
	}
}
