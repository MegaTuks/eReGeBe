using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject insPanel;
	public GameObject credPanel;
	void Start () 
	{
		insPanel.SetActive (false);
		credPanel.SetActive (false);
	}

	public void lookCredits () {
		credPanel.SetActive (true);
	}

	public void closeCredits () {
		credPanel.SetActive (false);
	}
	public void LookInstructions ()
	{
		insPanel.SetActive (true);
	}
	public void CloseIns ()
	{
		insPanel.SetActive (false);
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

