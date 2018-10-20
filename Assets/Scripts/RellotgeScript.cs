using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RellotgeScript : MonoBehaviour 
{
	void ControlRellotge()
	{
		GameObject.Find ("ObjecteMostrat").SendMessage ("FadeOffObjecte");
	}
}
