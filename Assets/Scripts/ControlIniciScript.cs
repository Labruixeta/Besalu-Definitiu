using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlIniciScript : MonoBehaviour 
{
	private GameObject temporal;
	public bool controlFi=false;
	private AudioSource musicaIntro;
	private AudioSource musicaJoc;
	private Animator animacio1;
	private Animator animacio2;

	void Start () 
	{
		animacio2 = GameObject.Find ("FosNegre2").GetComponent<Animator> ();
		animacio1 = GameObject.Find ("FosNegre1").GetComponent<Animator> ();
		temporal=GameObject.Find ("ObjecteIniciJoc");
		temporal.SetActive (false);
		musicaIntro = GetComponent<AudioSource> ();
		musicaJoc = GameObject.Find ("Musica").GetComponent<AudioSource> ();
		musicaIntro.Play ();
		animacio2.Play ("FosNegre2");
	}
	
	void Update () 
	{
		bool usserAction = Input.GetMouseButton (0);
		if (usserAction) 
		{
			animacio1.Play ("FosNegre1");
			musicaIntro.Stop ();
		}
	}

	public void Canvi ()
	{
	}

	public void Fi()
	{
		if (!controlFi) 
		{
			controlFi = true;
			musicaJoc.volume = 0.2f;
			musicaJoc.Play ();
			GameObject.Find ("ObjectePresentacio").SetActive (false);
			temporal.SetActive (true);
			animacio1.Play ("FosNegre1b");
		} 
		else
		{
			SceneManager.LoadScene (1);
		}
	}
}
