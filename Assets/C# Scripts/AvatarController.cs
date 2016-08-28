﻿using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour
{
	private int[] mLastFrameTouches;
	private RGB.Color mColor;
	private Rigidbody2D mRigidbody;

	private Color[] mPalette;

	private const float TORQUE = 20f;
	private const float ANGULAR_DRAG = 150f;
	private const float ACCELERATION = 25f;

	// Use this for initialization
	void Start ()
	{
		mPalette = new Color[]{ new Color(0f, 1f, 1f), new Color(1f, 0.3f, 0.3f), new Color(0.4f, 1f, 0.4f) };
		mLastFrameTouches = null;
		mColor = RGB.Color.Blue;
		gameObject.GetComponent<Renderer>().material.color = mPalette[0];
		mRigidbody = GetComponent<Rigidbody2D>();
	}
	
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

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			if (mRigidbody.rotation < -45f)
			{
				mRigidbody.AddTorque(TORQUE);
			}
			mRigidbody.AddForce(new Vector2(-ACCELERATION, 0));
		}
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			if (mRigidbody.rotation > -135f)
			{
				mRigidbody.AddTorque(-TORQUE);
			}
			mRigidbody.AddForce(new Vector2(ACCELERATION, 0));
		}
		else
		{
			if (mRigidbody.rotation < -90f)
			{
				mRigidbody.rotation = mRigidbody.rotation + ANGULAR_DRAG * Time.deltaTime;
				if (mRigidbody.rotation > -90f)
				{
					mRigidbody.rotation = -90f;
				}
			}
			else if (mRigidbody.rotation > -90f)
			{
				mRigidbody.rotation = mRigidbody.rotation - ANGULAR_DRAG * Time.deltaTime;
				if (mRigidbody.rotation < -90f)
				{
					mRigidbody.rotation = -90f;
				}
			}

			if (mRigidbody.velocity.x < 0f)
			{
				mRigidbody.velocity = new Vector2(mRigidbody.velocity.x + ACCELERATION * Time.deltaTime, 0f);
				if (mRigidbody.velocity.x > 0f)
				{
					mRigidbody.velocity = new Vector2(0, 0);
				}
			}
			else if (mRigidbody.velocity.x > 0f)
			{
				mRigidbody.velocity = new Vector2(mRigidbody.velocity.x - ACCELERATION * Time.deltaTime, 0f);
				if (mRigidbody.velocity.x < 0f)
				{
					mRigidbody.velocity = new Vector2(0, 0);
				}
			}
		}

		if (mRigidbody.rotation < -135f)
		{
			mRigidbody.angularVelocity = 0f;
			mRigidbody.rotation = -135f;
		}
		else if (mRigidbody.rotation > -45f)
		{
			mRigidbody.angularVelocity = 0f;
			mRigidbody.rotation = -45f;
		}
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
			gameObject.GetComponent<Renderer>().material.color = mPalette[1];
		}
		else if (mColor == RGB.Color.Red)
		{
			mColor = RGB.Color.Green;
			gameObject.GetComponent<Renderer>().material.color = mPalette[2];
		}
		else
		{
			mColor = RGB.Color.Blue;
			gameObject.GetComponent<Renderer>().material.color = mPalette[0];
		}
	}
}
