using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int mScore;
    public int mCombo = 0;
    public float mScoreWaitTimer = 0.2f;
    public float mScoreCrono;
    public bool mSpawnerFlag1 = false;
    public bool mSpawnerFlag2 = false;
    public bool mSpawnerFlag3 = false;
    public Outline mScoreLine;

    public Text mTextScore;
	// Use this for initialization
	void Start ()
    {
        mScoreCrono = mScoreWaitTimer;
        Instantiate(Resources.Load("Spawner"), gameObject.transform.position, Quaternion.identity);
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
            mScore += 5 + mCombo;
            mTextScore.text = "Score: " + mScore.ToString();
            mScoreCrono = mScoreWaitTimer;
        }

        if (mScore >= 5000 && !mSpawnerFlag1)
        {
            mSpawnerFlag1 = true;
            spawnSpawner(2f);
            mTextScore.fontSize = 65;
        }
        else if (mScore >= 15000  && !mSpawnerFlag2)
        {
            mSpawnerFlag2 = true;
            spawnSpawner(-2f);
            mTextScore.fontSize = 70;
            mScoreLine.effectColor = Color.yellow;
        }
        else if (mScore >= 30000 && !mSpawnerFlag3)
        {
            mSpawnerFlag3 = true;
            spawnSpawner(-3f);
            mTextScore.fontSize = 75;
        }


    }
}
