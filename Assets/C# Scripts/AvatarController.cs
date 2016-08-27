using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour
{
	private int[] mLastFrameTouches;
	private RGB.Color mColor;
	private Vector2 velocity;
	private float rotation;

	private const float MAX_VELOCITY = 25f;
	private const float TORQUE = 300f;
	private const float ACCELERATION = 150f;

	// Use this for initialization
	void Start ()
	{
		mLastFrameTouches = null;
		mColor = RGB.Color.Blue;
		velocity = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool shouldChangeColor = false;

		if (Input.touchSupported && Input.touchCount > 0)
		{
			shouldChangeColor = isNewTouchTapped();
		}

		if (!Input.touchSupported && Input.GetKeyDown(KeyCode.Space))
		{
			shouldChangeColor = true;
		}

		if (shouldChangeColor)
		{
			changeColor();
		}

		float z = transform.rotation.eulerAngles.z;
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			if (velocity.x > -MAX_VELOCITY)
			{
				velocity.x -= ACCELERATION * Time.deltaTime;
			}

			if (z < 315f)
			{
				transform.Rotate(Vector3.forward, TORQUE * Time.deltaTime);
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
		{
			if (velocity.x < MAX_VELOCITY)
			{
				velocity.x += ACCELERATION * Time.deltaTime;
			}

			if (z > 225f)
			{
				transform.Rotate(Vector3.forward, -TORQUE * Time.deltaTime);
			}
		}
		else {
			if (velocity.x > 0f)
			{
				velocity.x -= ACCELERATION * Time.deltaTime;
				if (velocity.x < 0f)
				{
					velocity.x = 0f;
				}
			}
			else if (velocity.x < 0f)
			{
				velocity.x += ACCELERATION * Time.deltaTime;
				if (velocity.x > 0f)
				{
					velocity.x = 0f;
				}
			}

			if (z > 270f)
			{
				transform.Rotate(Vector3.forward, -TORQUE * Time.deltaTime);

				if (transform.rotation.eulerAngles.z < 270f)
				{
					transform.rotation = Quaternion.Euler(0, 0, 270f);
				}
			}
			else if (z < 270f)
			{
				transform.Rotate(Vector3.forward, TORQUE * Time.deltaTime);

				if (transform.rotation.eulerAngles.z > 270f)
				{
					transform.rotation = Quaternion.Euler(0, 0, 270f);
				}
			}
		}

		transform.position += (Vector3) velocity * Time.deltaTime;
	}

	private bool isNewTouchTapped()
	{
		int[] newFrameTouches = new int[Input.touchCount];
		int index = 0;
		bool result = false;

		foreach (Touch touch in Input.touches)
		{
			newFrameTouches[index++] = touch.fingerId;

			foreach (int fingerId in mLastFrameTouches)
			{
				if (fingerId == touch.fingerId)
				{
					result = true;
				}
			}
		}

		mLastFrameTouches = newFrameTouches;

		return result;
	}

	private void changeColor()
	{
		if (mColor == RGB.Color.Blue)
		{
			mColor = RGB.Color.Red;
			gameObject.GetComponent<Renderer>().material.color = Color.red;
		}
		else if (mColor == RGB.Color.Red)
		{
			mColor = RGB.Color.Green;
			gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		else
		{
			mColor = RGB.Color.Blue;
			gameObject.GetComponent<Renderer>().material.color = Color.blue;
		}
	}
}
