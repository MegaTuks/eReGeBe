﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject mInsPanel;
	public GameObject mCredPanel;
    

    void Start () 
	{
        PlayerPrefs.SetInt("Third", 110);
        PlayerPrefs.SetInt("Second", 5250);
        PlayerPrefs.SetInt("First", 10235);
        mInsPanel.SetActive (false);
		mCredPanel.SetActive (false);
	}

	public void lookCredits ()
    {
		mCredPanel.SetActive (true);
	}

	public void closeCredits ()
    {
		mCredPanel.SetActive (false);
	}
	public void LookInstructions ()
	{
		mInsPanel.SetActive (true);
	}

	public void CloseIns ()
	{
		mInsPanel.SetActive (false);
	}

	public void StartGame () 
	{
		SceneManager.LoadScene ("Nivel");
	}
	public void endGame () 
	{
		Application.Quit ();
	}
}

