using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour {
	
	private bool dialogoKo;
	private bool primeiroDialogo;
	private bool canUpDialog;

	private Vector3 posicaoOpcoes;
	
	public GameObject dialogo;
	public Text textoDialogo;
	public RawImage personagemFalando;
	public Texture[] personagens;
	public GameObject opcao1;
	public GameObject opcao2;
	public GameObject[] opcoes;
	public Inventario scriptInventario;

	// Use this for initialization
	void Start () {
		primeiroDialogo = true;
		dialogoKo = false;
		posicaoOpcoes = new Vector3 (559.5f, -762f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (primeiroDialogo) {
			primeiroDialogo = false;
			canUpDialog = true;
		}
		
		if (dialogoKo) {
			canUpDialog = false;
			dialogoKo = false;
		}

		if (canUpDialog) {
			sobeCaixaDialogo ();
		} else {
			desceCaixaDialogo();
		}
	}



	void sobeCaixaDialogo(){
		if (dialogo.transform.position.y < 120) {
			dialogo.transform.Translate (0f, 15f, 0f);
		}
	}

	void desceCaixaDialogo(){
		if (dialogo.transform.position.y > -117) {
			dialogo.transform.Translate (0f, -15f, 0f);
		} else {
			for(int i = 0; i < opcoes.Length; i++)
			{
				opcoes[i].transform.position = posicaoOpcoes;
			}
		}
	}



	void OnTriggerEnter(Collider other){
		if (other.tag == "Ferreiro") {
			opcoes[0].transform.position = opcao1.transform.position;
			opcoes[1].transform.position = opcao2.transform.position;
			personagemFalando.GetComponent<RawImage>().texture = personagens[0];
			if (scriptInventario.arma != 0) {
				textoDialogo.GetComponent<Text>().text = "Voce ja possui uma arma, deseja comprar outra?";
			}else{
				textoDialogo.GetComponent<Text>().text = "Deseja comprar uma destas armas?";
			}
			canUpDialog = true;
		}
	}




	public void dialogoOk(){
		dialogoKo = true;
	}

	public void comprouArma1(){
		scriptInventario.money -= 80;
		scriptInventario.arma = 1;
		dialogoKo = true;
	}
	public void comprouArma2(){
		scriptInventario.money -= 40;
		scriptInventario.arma = 2;
		dialogoKo = true;
	}

	public void compraArma1(){
		if (scriptInventario.arma == 1) {
			textoDialogo.GetComponent<Text>().text = "Voce ja possui esta arma!";
		}
		else if (scriptInventario.money >= 80) {
			comprouArma1();
		} else {
			textoDialogo.GetComponent<Text>().text = "Voce nao tem dinehiro suficiente para esta arma, deseja algo mais?";
		}
	}

	public void compraArma2(){
		if (scriptInventario.arma == 2) {
			textoDialogo.GetComponent<Text>().text = "Voce ja possui esta arma!";
		}
		else if (scriptInventario.money >= 40) {
			comprouArma2();
		} else {
			textoDialogo.GetComponent<Text>().text = "Voce nao tem dinehiro suficiente para esta arma, deseja algo mais?";
		}
	}
}