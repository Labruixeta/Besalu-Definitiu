using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConsolaTextControl : MonoBehaviour 
{
	public TextMesh texteMesh;
	public string entrada="";
	public bool entradaBool=false;
	public string sortida="";
	public string[] tros;
	public int paraula = 0;
	public bool salt = false;
	public bool espera = false;

	void Start () 
	{
		texteMesh = GameObject.Find("ConsolaText").GetComponent<TextMesh> ();
		texteMesh.text = "";
	}
	
	void Update () 
	{
		
		bool usserAction = Input.GetMouseButtonDown (0);
		if (!string.IsNullOrEmpty (entrada) && !entradaBool) 
		{
			paraula = 0;
			entradaBool = true;
			char[] limits = { ' ' };
			tros = entrada.Split (limits);
			entrada = "";
		}
		if (entradaBool && !espera && paraula < tros.Length) {	
			sortida = sortida + tros [paraula] + " ";
			paraula++;
			if (sortida.Length > 40 && !salt) {
				salt = true;
				sortida = sortida + "\n";
			} else if (sortida.Length > 80) {
				espera = true;
				salt = false;
			}
			texteMesh.text = sortida;
		} else if (paraula == tros.Length) {
			entradaBool = false;
		}
		if (usserAction && espera) 
		{
			sortida = "";
			espera = false;
			salt = false;
			texteMesh.text = sortida;
		}
		if (usserAction && paraula == tros.Length) 
		{
			paraula = 0;
			sortida = "";
			espera = false;
			salt = false;
			entradaBool = false;
			texteMesh.text = sortida;
		}

	}

	void EscriuTexte(string texte)
	{
		if (!entradaBool) 
		{
			sortida = "";
			entrada = texte;
			texte = sortida;
		} 

	}
}
