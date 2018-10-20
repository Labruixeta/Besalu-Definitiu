using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSControl : MonoBehaviour {
	public bool controlEntrada2 = false;
		
	void Update () 
	{
		bool usserAction2 = Input.GetMouseButtonDown (0);
		if (usserAction2 && controlEntrada2) 
		{
			controlEntrada2 = false;
			usserAction2 = false;
			if (gameObject.name.Contains ("N") || gameObject.name.Contains ("O")) 
			{
				GameObject.Find ("ObjecteControlJoc").SendMessage ("EntraObjecte", gameObject.name);
				GameObject.Find ("ObjecteMostrat").SendMessage ("ClicExtern");
			} 
			else if (gameObject.name.Contains ("M")) 
			{ 
				GameObject.Find ("ObjecteMostrat").SendMessage ("MouseOnObjecte", gameObject.name);
			}
		} 
		else 
		{
			controlEntrada2 = false;
		}
	}
	void OnMouseOver()
	{
		controlEntrada2 = true;
	}
	void OnMouseExit()
	{
	controlEntrada2 = false;
	}

}
