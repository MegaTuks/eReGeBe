using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int mScore;
    public int mCombo;
    public float mScoreWaitTimer = 1.0f;
    public float mScoreCrono;
    public bool mSpawnerFlag1 = false;
    public bool mSpawnerFlag2 = false;
    public bool mSpawnerFlag3 = false;

    public Text mTextScore;
	// Use this for initialization
	void Start ()
    {
        mScoreCrono = mScoreWaitTimer;
        GameObject spawner = Instantiate(Resources.Load("Spawner"), gameObject.transform.position, Quaternion.identity) as GameObject;
    }

    void spawnSpawner(float center)
    {
        GameObject spawner = Instantiate(Resources.Load("Spawner"), gameObject.transform.position, Quaternion.identity) as GameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        mScoreCrono -= Time.deltaTime;
        if(mScoreCrono <= 0)
        {
            mScore += 5;
            mTextScore.text = "Score: " + mScore.ToString();
            mScoreCrono = mScoreWaitTimer;
        }

        if (mScore >= 5000 && !mSpawnerFlag1)
        {
            mSpawnerFlag1 = true;
            spawnSpawner(2f);
        }
        else if (mScore >= 100000  && !mSpawnerFlag2)
        {
            mSpawnerFlag2 = true;
            spawnSpawner(-2f);
        }
        else if (mScore >= 500000 && !mSpawnerFlag3)
        {
            mSpawnerFlag3 = true;
            spawnSpawner(-3f);
        }


    }
}
