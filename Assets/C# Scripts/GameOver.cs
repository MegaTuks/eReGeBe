using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text Score;
    public Text First;
    public Text Second;
    public Text Third;

	// Use this for initialization
	void Start () {
        Score.text = PlayerPrefs.GetInt("Score").ToString();
        placeScores();

    }

    void placeScores()
    {
        int changeScore = PlayerPrefs.GetInt("Score");
        if (PlayerPrefs.GetInt("First") < changeScore)
        {
            PlayerPrefs.SetInt("First", changeScore);
        }
        else if(PlayerPrefs.GetInt("First") > changeScore && changeScore > PlayerPrefs.GetInt("Second"))
        {
            PlayerPrefs.SetInt("Second", changeScore);
        }
        else if (PlayerPrefs.GetInt("First") > changeScore && changeScore < PlayerPrefs.GetInt("Second") && changeScore > PlayerPrefs.GetInt("Third"))
        {
            PlayerPrefs.SetInt("Third", changeScore);
        }
        First.text = "First: " + PlayerPrefs.GetInt("First").ToString();
        Second.text = "Second: " + PlayerPrefs.GetInt("Second").ToString();
        Third.text = "Third: " + PlayerPrefs.GetInt("Third").ToString();

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Nivel");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
