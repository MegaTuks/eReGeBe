using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    //variables of obstalces 
    public RGB.Color mObstacleColor;
    public RGB.Color mObstacleColor2;
    public RGB.Color mObstacleColor3;
    public int mObstacleNumbah;
    public int mObstacleType;
    public Vector3 mObstacleSpeed;
    public GameObject mObstacleTypeInstance;
    // variable for patterns
    public int mPatternType;
    //variable of spawnerbehavior
    public float mSpawnerPosition;
    public Vector3 mSpawnerSpeedTransition;
    public float mSpawnerLimits;
    public float mSpawnTime;
    public float mTimer;
    public float mWaitTime = 1.2f;
    public float mWaitTimer;
    public int mSpawnChange;
    public int mSpawnedObjects;
    private int mDirection;

    // Use this for initialization
    void Start () {
        mObstacleNumbah = Random.Range(1, 4);
        switch (mObstacleNumbah)
        {
            case 1:
                mObstacleColor = RGB.Color.Red;
                mObstacleColor2 = RGB.Color.Green;
                mObstacleColor3 = RGB.Color.Blue;
                break;
            case 2:
                mObstacleColor = RGB.Color.Green;
                mObstacleColor2 = RGB.Color.Red;
                mObstacleColor3 = RGB.Color.Blue;
                break;
            case 3:
                mObstacleColor = RGB.Color.Blue;
                mObstacleColor2 = RGB.Color.Green;
                mObstacleColor3 = RGB.Color.Red;
                break;
        }
        mWaitTimer = mWaitTime;
        mSpawnTime = Random.Range(0.3f, .6f);
        mSpawnerSpeedTransition = new Vector3(Random.Range(1, 5), 0, 0);
        mSpawnerLimits = Random.Range(1.5f, 7.5f);
        mPatternType = Random.Range(1, 7);
        mDirection = 1;
        mTimer = mSpawnTime;
        mSpawnedObjects = Random.Range(8, 20);
        mObstacleType = Random.Range(1, 4);
        setPrefab();
    }
	void refreshSpawner()
    {
        mObstacleNumbah = Random.Range(1, 4);
        switch (mObstacleNumbah)
        {
            case 1:
                mObstacleColor = RGB.Color.Red;
                mObstacleColor2 = RGB.Color.Green;
                mObstacleColor3 = RGB.Color.Blue;
                break;
            case 2:
                mObstacleColor = RGB.Color.Green;
                mObstacleColor2 = RGB.Color.Red;
                mObstacleColor3 = RGB.Color.Blue;
                break;
            case 3:
                mObstacleColor = RGB.Color.Blue;
                mObstacleColor2 = RGB.Color.Green;
                mObstacleColor3 = RGB.Color.Red;
                break;
        }
        mWaitTimer = mWaitTime;
        mSpawnTime = Random.Range(0.3f, .6f);
        mSpawnerSpeedTransition = new Vector3(Random.Range(1, 5), 0, 0);
        mSpawnerLimits = Random.Range(1.0f, 7.5f);
        mPatternType = Random.Range(1, 7);
        mDirection = 1;
        mTimer = mSpawnTime;
        mObstacleType = Random.Range(1, 4);
        mSpawnedObjects = Random.Range(8, 20);
        setPrefab();
    }
	// Update is called once per frame
	void Update ()
    {
	    if(mTimer >= 0)
        {
            mTimer = mTimer - Time.deltaTime;
            usePatternSpawner();
        }
        else
        {
            
            if (mSpawnedObjects == 0)
            {
                if (mWaitTimer >= 0)
                {
                    Debug.Log("entro?");
                    mWaitTimer = mWaitTimer - Time.deltaTime;
                 }
                else
                { 
                    refreshSpawner();
                    mWaitTimer = mWaitTime;
                }
            }
            else
            {
                mSpawnedObjects--;
                mTimer = mSpawnTime;
                usePatternInstance();
            }           
        }
	}

    void usePatternSpawner()
    {
       
        switch (mPatternType)
        {
            case 1:
            case 6:
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
                if (gameObject.transform.position.x >  mSpawnerLimits)
                {
                    mDirection = 1;
                }
                else if (gameObject.transform.position.x < 0 )
                {
                    mDirection = -1;
                }
                break;
            case 3:
            case 5:
                if (gameObject.transform.position.x >   mSpawnerLimits)
                {
                    mDirection = 1;
                }
                else if (gameObject.transform.position.x < -1 * mSpawnerLimits)
                {
                    mDirection = -1;
                }
                break;
            case 4:
                if (gameObject.transform.position.x > 0)
                {
                    mDirection = 1;
                }
                else if (gameObject.transform.position.x <  -1 * mSpawnerLimits)
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
                mObstacleSpeed = new Vector3(0, 2, 0);
                bullet = Instantiate(mObstacleTypeInstance, gameObject.transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor, mObstacleSpeed);
                break;
            case 2:
            case 4:
                mObstacleSpeed = new Vector3(0, 3, 0);
                bullet = Instantiate(mObstacleTypeInstance, gameObject.transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor, mObstacleSpeed);
                break;
            case 3:
                mObstacleSpeed = new Vector3(1, 2, 0);
                bullet = Instantiate(mObstacleTypeInstance, new Vector3(gameObject.transform.position.x-1f, gameObject.transform.position.y ), Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor, mObstacleSpeed);
                mObstacleSpeed = new Vector3(0, 2, 0);
                bullet = Instantiate(mObstacleTypeInstance, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1f), Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor2, mObstacleSpeed);
                mObstacleSpeed = new Vector3(-1, 2, 0);
                bullet = Instantiate(mObstacleTypeInstance, new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor, mObstacleSpeed);
                break;
            case 5:
                mObstacleSpeed = new Vector3(.5f, 2, 0);
                bullet = Instantiate(mObstacleTypeInstance, new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor3, mObstacleSpeed);
                mObstacleSpeed = new Vector3(-.5f, 2, 0);
                bullet = Instantiate(mObstacleTypeInstance, new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor, mObstacleSpeed);
                break;
            case 6:
                mObstacleSpeed = new Vector3(1, 2, 0);
                bullet = Instantiate(mObstacleTypeInstance, new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor, mObstacleSpeed);
                mObstacleSpeed = new Vector3(.5f, 2, 0);
                bullet = Instantiate(mObstacleTypeInstance, new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor3, mObstacleSpeed);
                mObstacleSpeed = new Vector3(0, 2, 0);
                bullet = Instantiate(mObstacleTypeInstance, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1f), Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor2, mObstacleSpeed);
                mObstacleSpeed = new Vector3(-.5f, 2, 0);
                bullet = Instantiate(mObstacleTypeInstance, new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y), Quaternion.identity) as GameObject;
                bullet.GetComponent<ObstacleController>().setObstacle(mObstacleColor3, mObstacleSpeed);
                mObstacleSpeed = new Vector3(-1, 2, 0);
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

    public void setXPosition(float xPos)
    {
        mSpawnerPosition = xPos;
    }
}
