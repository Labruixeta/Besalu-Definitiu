using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlObjecteMostrat : MonoBehaviour 
{
	public Image m1;
	public Image m2;
	public Image m3;
	public Image m4;
	public Image m5;
	public Image objecteImatge;
	public Animator animaciObjecte;
	public int numObjecte=0;
	public int objTriat;
	public int objAntTriat;

	public bool espera = false;
	public bool controlObjecte=false;
	public int[] objLlista;
	public string[] objNom;
	void Start()
	{
		objNom = new string[5];
		objLlista = new int[5];

		objNom [0] = "Rellotge";
		objNom [1] = "Agulla Gràn";
		objNom [2] = "Agulla Petita";
		objNom [3] = "Res";
		objNom [4] = "Objecte de proba";

		m1.CrossFadeAlpha (0,0,true);
		m2.CrossFadeAlpha (0,0,true);
		m3.CrossFadeAlpha (0,0,true);
		m4.CrossFadeAlpha (0,0,true);
		m5.CrossFadeAlpha (0,0,true);
	}
	void Update () 
	{
		bool usserAction4 = Input.GetMouseButtonDown (0);
		if (numObjecte > 0 && !espera) 
		{
			espera = true;
			switch (numObjecte) 
			{
			case 1:
				Nou ();
				break;
			case 2:
				Nou ();
				break;
			default:
				break;
			}
		}
		if (usserAction4 && espera) 
		{
			FadeOffObjecte ();
			espera = false;
			numObjecte = 0;
		}
	}

	void FadeOnObjecte ()
	{
		GameObject.Find ("ObjecteControlJoc").SendMessage ("ApagaSensors");
		switch (numObjecte) 
		{
		case 1:
			objecteImatge.sprite = Resources.Load<Sprite> ("Objectes/rellotge_grn");
			animaciObjecte.Play("ObjecteRellotgeOn");
			break;
		case 2:
			objecteImatge.sprite = Resources.Load<Sprite> ("Objectes/2");
			animaciObjecte.Play("ObjecteRellotgeOn");
			break;
		default:
			break;
		}
	}

	public void FadeOffObjecte()
	{
		GameObject.Find ("ObjecteControlJoc").SendMessage ("EncenSensors");
		switch (numObjecte) 
		{
		case 1:
			animaciObjecte.Play ("ObjecteRellotgeOff");
			AfegeigObjecte (1);
			MostraObjectes ();
			break;
		case 2:
			animaciObjecte.Play ("ObjecteRellotgeOff");
			AfegeigObjecte (2);
			MostraObjectes ();
			break;
		default:
			break;
		}
	}

	void Nou()
	{
		animaciObjecte = GameObject.Find ("Objecte").GetComponent<Animator> ();
		FadeOnObjecte ();
	}

	public void EntraObjecte(int entrada)
	{
		numObjecte = entrada;
	}
	void MostraObjectes()
	{
		for (int i = 0; i < 5; i++) {
			if (objLlista [i] >0) {
				if (i == 0) {
					m1.sprite = Resources.Load<Sprite> ("Objectes/" + objLlista[i]);
					m1.CrossFadeAlpha (1, 1, true);
				} else if (i == 1) {
					m2.sprite = Resources.Load<Sprite> ("Objectes/" + objLlista[i]);
					m2.CrossFadeAlpha (1, 1, true);
				} else if (i == 2) {
					m3.sprite = Resources.Load<Sprite> ("Objectes/" + objLlista[i]);
					m3.CrossFadeAlpha (1, 1, true);
				} else if (i == 3) {
					m4.sprite = Resources.Load<Sprite> ("Objectes/" + objLlista[i]);
					m4.CrossFadeAlpha (1, 1, true);
				} else if (i == 4) {
					m5.sprite = Resources.Load<Sprite> ("Objectes/" + objLlista[i]);
					m5.CrossFadeAlpha (1, 1, true);
				}
			}
		}
	}
	void AfegeigObjecte(int nou)
	{
		for (int i = 0; i < 5; i++) {
			if (objLlista [i] == 0) {
				objLlista [i] = nou;
				i = 5;
			}
		}
	}
	public void MouseOnObjecte (string moo)
	{
			objAntTriat = objTriat;
		switch (moo) {
		case "M1":
			if (objLlista [0] >0) 
			{
				controlObjecte = true;
				objTriat = 1;
				if (objAntTriat == 0) 
				{
					GameObject.Find ("Consola").SendMessage ("EscriuTexte", "OT : " + objNom [objLlista [0] - 1] + "OA : Cap");
				} 
				else 
				{
					GameObject.Find ("Consola").SendMessage ("EscriuTexte", "OT : " + objNom [objLlista [0] - 1] + "OA : " + objNom [objLlista [objAntTriat - 1] - 1]);
				}
			} 
			else 
			{
				controlObjecte = false;
				objTriat = 0;
				GameObject.Find ("Consola").SendMessage ("EscriuTexte", "1 Vuit" );
			}
			break;
		case "M2":
			if (objLlista [1] >0) {
				controlObjecte = true;
				objTriat = 2;
				GameObject.Find ("Consola").SendMessage ("EscriuTexte", "Objecte triat : " + objNom[objLlista[1]-1] );
			} else {
				controlObjecte = false;
				objTriat = 0;
				GameObject.Find ("Consola").SendMessage ("EscriuTexte", "2 Vuit" );
			}
			break;
		case "M3":
			if (objLlista [2] >0) {
				controlObjecte = true;
				objTriat = 3;
				GameObject.Find ("Consola").SendMessage ("EscriuTexte", "Objecte triat : " + objNom[objLlista[2]-1] );
			} else {
				controlObjecte = false;
				objTriat = 0;
				GameObject.Find ("Consola").SendMessage ("EscriuTexte", "3 Vuit" );
			}
			break;
		case "M4":
			if (objLlista [3] >0) {
				controlObjecte = true;
				objTriat = 4;
				GameObject.Find ("Consola").SendMessage ("EscriuTexte", "Objecte triat : " + objNom[objLlista[3]-1] );
			} else {
				controlObjecte = false;
				objTriat = 0;
				GameObject.Find ("Consola").SendMessage ("EscriuTexte", "4 Vuit" );
			}
			break;
		
		case "M5":
			if (objLlista [4] >0) {
				controlObjecte = true;
				objTriat = 5;
				GameObject.Find ("Consola").SendMessage ("EscriuTexte", "Objecte triat : " + objNom[objLlista[4]-1] );
			} else {
				controlObjecte = false;
				objTriat = 0;
				GameObject.Find ("Consola").SendMessage ("EscriuTexte", "5 Vuit" );
			}
			break;

		default:
			controlObjecte = false;
			objTriat = 0;
			break;
		}
	}
	void ClicExtern()
	{
		objTriat = 0;
	}

}
