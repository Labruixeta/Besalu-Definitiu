using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanviFi : MonoBehaviour {

	public void DetectaFi()
	{
		GameObject.Find ("ObjecteControlInici").SendMessage ("Fi");
	}
}
