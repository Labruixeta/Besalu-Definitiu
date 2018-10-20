using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapaOnControl : MonoBehaviour 
{
	public bool controlEntrada = false;
	public bool controlEnces = false;
	public GameObject mapaImatge;

	void Start () 
	{
		mapaImatge.SetActive (false);
	}
	
	void Update () 
	{
		bool usserAction3 = Input.GetMouseButtonDown (0);
		if (usserAction3 && controlEntrada) 
		{
			usserAction3 = false;
			controlEntrada = false;
//			Image Imatge2 = GetComponent<Image> ();
			if (!controlEnces) 
			{
				mapaImatge.SetActive (true);
				controlEnces = true;
//				Imatge2.sprite = Resources.Load<Sprite> ("MapaOnLow");
				GameObject.Find("ObjecteControlJoc").SendMessage("ApagaSensors");
			} 
			else 
			{
				mapaImatge.SetActive (false);
				controlEnces = false;
//				Imatge2.sprite = Resources.Load<Sprite> ("MapaOffLow");
				GameObject.Find("ObjecteControlJoc").SendMessage("EncenSensors");
			}
		}
	}
	void OnMouseOver()
	{
		controlEntrada = true;
	}
	void OnMouseExit()
	{
		controlEntrada = false;
	}
}
