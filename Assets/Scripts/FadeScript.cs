using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour 
{
	public void FadeEnd()
	{
		GameObject.Find ("ObjecteControlJoc").SendMessage ("ControlExternFade");
	}
}

