using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MScript : MonoBehaviour {
	public bool mcontrol = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool macction = Input.GetMouseButtonDown (0);
		if (macction && mcontrol) {
			mcontrol = false;
			macction = false;
			GameObject.Find ("ObjecteMostrat").SendMessage ("MouseOnObjecte", gameObject.name);
			GameObject.Find ("ObjecteMostrat").SendMessage ("ClicExtern", gameObject.name);
		} else {
			mcontrol = false;
		}
	}
	void OnMouseOver()
	{
		mcontrol = true;
	}
	public void OnMouseExit()
	{
		mcontrol = false;
	}

}
