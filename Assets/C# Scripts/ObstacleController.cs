using UnityEngine;
using System.Collections;
using UnityEngine.Sprites;

public class ObstacleController : MonoBehaviour
{
    
    public Vector3 mMovementSpeed;
    public RGB.Color mObstacleType;
    Vector2 mTargetPosition;
    public GameObject mTarget;
    public SpriteRenderer mOsbstacleImage;
	// Use this for initialization
	void Start ()
    {

    }

    public void setObstacle(RGB.Color type, Vector3 speed)
    {
        mObstacleType = type;
        mMovementSpeed = speed;
        setColor(mObstacleType);
    }
	
    void setColor(RGB.Color type)
    {
        mOsbstacleImage = gameObject.GetComponent<SpriteRenderer>();
        if (type == RGB.Color.Blue)
        {
            mOsbstacleImage.color = new Color(0f, 1f, 1f);
        }
        else if(type == RGB.Color.Red)
        {
            mOsbstacleImage.color = new Color(1f, 0.3f, 0.3f);
        }
        else if (type == RGB.Color.Green)
        {
            mOsbstacleImage.color = new Color(0.4f, 1f, 0.4f);
        }
    }
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.position = gameObject.transform.position - mMovementSpeed * Time.deltaTime;
    }
}
