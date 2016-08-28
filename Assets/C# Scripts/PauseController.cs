using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {
    private bool paused;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void pauseGame ()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
