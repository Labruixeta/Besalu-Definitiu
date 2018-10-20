using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanvi : MonoBehaviour {

	public void EnviaSenyal()
	{
		GameObject.Find ("ObjecteControlInici").SendMessage ("Canvi");
	}
}
