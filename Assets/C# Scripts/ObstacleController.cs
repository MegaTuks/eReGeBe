using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObstacleController : MonoBehaviour
{
    
    public Vector3 mMovementSpeed;
    public int mObstacleType;
    Vector2 mTargetPosition;
    public GameObject mTarget;
    public Sprite mOsbstacleImage;
	// Use this for initialization
	void Start ()
    {
 
	}

    public void setObstacle(int type, Vector3 speed)
    {
        mObstacleType = type;
        mMovementSpeed = speed;
    }
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.position = gameObject.transform.position + mMovementSpeed;
    }
}
