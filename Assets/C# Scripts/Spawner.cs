using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public RGB.Color mObstacleColor;
    public int mObstacleType;
    public Vector3 mObstacleSpeed;
    public GameObject mObstacleTypeInstance;
    // variable for patterns
    public int mPatternType;
    //variable of instance
    public Vector3 mSpawnerSpeedTransition;
    public float mSpawnerLimits;
    public float mSpawnTime;
    public float mTimer;
    private int mDirection;

    // Use this for initialization
    void Start () {
        mSpawnTime = Random.Range(0.3f, .8f);
        mSpawnerSpeedTransition = new Vector3(Random.Range(1, 5), 0, 0);
        mSpawnerLimits = Random.Range(1.0f, 7.5f);
        mPatternType = Random.Range(1, 4);
        mDirection = 1;
        mTimer = mSpawnTime;
        mObstacleType = Random.Range(1, 4);
        setPrefab();
    }
	
	// Update is called once per frame
	void Update () {
	    if(mTimer >= 0)
        {
            mTimer = mTimer - Time.deltaTime;
            usePatternSpawner();
        } else {
            mTimer = mSpawnTime;
            usePatternInstance(); 
        }
	}

    void usePatternSpawner()
    {
       
        switch (mPatternType)
        {
            case 1:
                // public Vector3 mSpawnerSpeedTransition;
                if (gameObject.transform.position.x >   mSpawnerLimits)
                {
                    mDirection = 1;
                }
                else if (gameObject.transform.position.x < -1 * mSpawnerLimits)
                {
                    mDirection = -1;
                }
                break;
            case 2:
                if (gameObject.transform.position.x > .5 * mSpawnerLimits)
                {
                    mDirection = 1;
                }
                else if (gameObject.transform.position.x < -.5 * mSpawnerLimits)
                {
                    mDirection = -1;
                }
                break;
            case 3:
                if (gameObject.transform.position.x >   mSpawnerLimits)
                {
                    mDirection = 1;
                }
                else if (gameObject.transform.position.x < -1 * mSpawnerLimits)
                {
                    mDirection = -1;
                }
                break;
        }
        gameObject.transform.position = gameObject.transform.position - (mDirection * mSpawnerSpeedTransition*Time.deltaTime);

    }
    void usePatternInstance()
    {
        GameObject bullet;
        switch (mPatternType)
        {
            case 1:
                mObstacleSpeed = new Vector3(0, 1, 0);
                bullet = Instantiate(mObstacleTypeInstance, gameObject.transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor, mObstacleSpeed);
                break;
            case 2:
                mObstacleSpeed = new Vector3(0, 2, 0);
                bullet = Instantiate(mObstacleTypeInstance, gameObject.transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor, mObstacleSpeed);
                break;
            case 3:
                mObstacleSpeed = new Vector3(1, 1, 0);
                bullet = Instantiate(mObstacleTypeInstance, new Vector3(gameObject.transform.position.x-1f, gameObject.transform.position.y ), Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor, mObstacleSpeed);
                mObstacleSpeed = new Vector3(0, 1, 0);
                bullet = Instantiate(mObstacleTypeInstance, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1f), Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor, mObstacleSpeed);
                mObstacleSpeed = new Vector3(-1, 1, 0);
                bullet = Instantiate(mObstacleTypeInstance, new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor, mObstacleSpeed);
                break;
        }


    }
    void setPrefab()
    {
       switch (mObstacleType)
        {
            case 1:
                mObstacleTypeInstance = Resources.Load("Obstacle2") as GameObject;
                break;
            case 2:
                mObstacleTypeInstance = Resources.Load("Obstacle3") as GameObject;
                break;
            case 3:
                mObstacleTypeInstance = Resources.Load("Obstacle4") as GameObject;
                break;
        }
    }
}
