using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJocScript : MonoBehaviour 
{
	public string nomEntrada="";
	private bool segur=false;
	private bool segurObj=false;
	public Animator fade;
	public GameObject trans;
	public GameObject N1;
	public GameObject N2;
	public GameObject N3;

	public int ns;
	public int ne;
	private AudioSource musicaJoc;
	public bool butEstat = false;

	void Start()
	{
		//-----------------------------------------------------------------------------------------------
		// VALORS INICIALS
		//-----------------------------------------------------------------------------------------------

		N1.SetActive(true);
		N2.SetActive (false);
		N3.SetActive (false);
		musicaJoc = GameObject.Find ("MusicaJoc").GetComponent<AudioSource> ();
		musicaJoc.Play ();
		Escriu("Arrives a Besalú un dimecres al matí. Fa temps que tens ganes de visitar-lo tranquil i sense gaire gent. Deixes el cotxe al parquing i et disposses a entrar a la vila Comtal pel pont Vell.");
		fade = GameObject.Find ("Fade").GetComponent<Animator> ();
		fade.Play ("FadeOn");

	}
	void Update () 
	{
		if (butEstat) {
			Escriu ("butEstat=true");
		}
		if (!string.IsNullOrEmpty (nomEntrada) ) 
		{
			switch (nomEntrada) 
			{
			case "NS1":
				SetEstat ();
				Escriu("Pont Vell.");
				break;

			case "NS2":
				SetEstat ();
				Escriu("Porta d'accés a Besalú. Antigament hi havia un peatge en aquesta porta.");
				break;
			case "NS3":
				if (!segur) 
				{
					segur = true;
					nomEntrada = "";
					Escriu("Escales cap al riu.");
				} 
				else 
				{
					ne = 2;
					ns = 1;
					SetEstat ();
					Escriu("");
					ApagaSensors ();
					fade.Play ("FadeOff");
				}
				break;
			case "NS4":
				SetEstat ();
				Escriu("El riu Fluvia passa amb força per sota el pont.");
				break;
			case "NS5":
				SetEstat ();
				Escriu("Antiga muralla.");
				break;
			case "NS6":
				if (!segur) 
				{
					segur = true;
					nomEntrada = "";
					Escriu("Camí d'entrada al la vila.");
				} 
				else 
				{
					ne = 3;
					ns = 1;
					SetEstat ();
					Escriu("");
					ApagaSensors ();
					fade.Play ("FadeOff");
				}
				break;

			case "NS7":
				segurObj = false;
				SetEstat ();
				Escriu("Des d'aquí tens una vista fantàstica del pont.");
				break;
			case "NS8":
				if (!segur) 
				{
					segurObj = false;
					segur = true;
					Escriu("Tornar.");
					nomEntrada = "";
				} 
				else 
				{
					segurObj = false;
					ne = 1;
					ns = 2;
					SetEstat ();
					Escriu("");
					ApagaSensors ();
					fade.Play ("FadeOff");
				}
				break;
			case "NS9":
				if (!segurObj) 
				{
					segurObj = true;
					SetEstat ();
					Escriu("Objecte : RELLOTGE.");
				} 
				else 
				{
					GameObject.Find ("ObjecteMostrat").SendMessage ("EntraObjecte",1);
					segurObj = false;
					Escriu("Rellotge Agafat.");
					SetEstat ();
					GameObject.Find ("NS9").SetActive (false);
				}
				break;
			case "NS15":
				segurObj = false;
				SetEstat ();
				Escriu("L'entrada a la vila vella..");
				break;
			case "NS16":
				if (!segur) 
				{
					segurObj = false;
					segur = true;
					Escriu("Tornar.");
					nomEntrada = "";
				} 
				else 
				{
					segurObj = false;
					ne = 1;
					ns = 3;
					SetEstat ();
					Escriu("");
					ApagaSensors ();
					fade.Play ("FadeOff");
				}
				break;


			case "ObjecteSortida":
				SetEstat ();
				Escriu("Surt.");
				Application.Quit ();
				break;

			default:
				segur = false;
				segurObj = false;
				nomEntrada = "";
				break;
			}
		}
	}
	void EntraObjecte(string nomNou)
	{
		if (nomNou.Length > 0) 
		{
			nomEntrada = nomNou;
		} 
		else 
		{
			print ("Error d'entrada. Longitut de la cadena = 0");
			nomEntrada = "";
		}
	}
	void ControlExternFade()
	{
		CanviaNivell (ns,ne);
		fade.Play ("FadeOn");
		EncenSensors ();
	}
	void Escriu(string txt)
	{
		GameObject.Find ("Consola").SendMessage ("EscriuTexte", txt);
	}
	void ApagaSensors()
	{
		trans = GameObject.Find ("Sensors");
		trans.SetActive (false);
	}
	void EncenSensors()
	{
		trans.SetActive (true);
	}
	void CanviaNivell(int surt, int entra)
	{
		switch (entra) 
		{
		case 1:
			N1.SetActive (true);
			break;
		case 2:
			N2.SetActive (true);
			break;
		case 3:
			N3.SetActive (true);
			break;

		default:
			break;
		}
		switch (surt) 
		{
		case 1:
			N1.SetActive (false);
			break;
		case 2:
			N2.SetActive (false);
			break;
		case 3:
			N3.SetActive (false);
			break;

		default:
			break;
		}

	}
	void SetEstat()
	{
		segur = false;
		nomEntrada = "";
	}
	public void ButOn()
	{
		print ("Si");
		butEstat = true;
	}
	public void ButOff()
	{
		butEstat = false;
	}
}
