using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float paddingAmt = .05f;
	private Vector3 initialPosition;
	public float moveSpd = 25;
	public float moveMultiplier = 1;
	public float scrollSpeed = 5;
	public float minHeight = 20;
	public float maxHeight = 20;


	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.H))
		{
			transform.position = initialPosition;
		}

		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && transform.position.y > minHeight)
		{
			transform.Translate (transform.forward * scrollSpeed, Space.World);
		}
		else if (Input.GetAxis ("Mouse ScrollWheel") < 0 && transform.position.y < maxHeight)
		{
			transform.Translate (transform.forward * -scrollSpeed, Space.World);

		}

		moveCamera (moveSpd / 2, paddingAmt);
		moveCamera (moveSpd * 1f, paddingAmt / 2);
		moveCamera (moveSpd * 1.5f, 0);
	}

	void moveCamera(float moveSpeed, float paddingRatio)
	{
		if (Input.mousePosition.y < paddingRatio * Screen.height)
		{
			transform.Translate (Vector3.back * moveSpeed * Time.deltaTime, Space.World);
		}

		else if (Input.mousePosition.y > (1 - paddingRatio) * Screen.height)
		{
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
		}

		if (Input.mousePosition.x < paddingRatio * Screen.width)
		{
			transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
		}

		else if (Input.mousePosition.x > (1 - paddingRatio) * Screen.width)
		{
			transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
		}
	}
}
