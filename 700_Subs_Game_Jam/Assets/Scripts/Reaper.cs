using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectableActor))]
public class Reaper : MonoBehaviour {

	[System.NonSerialized]
	public SelectableActor actor;
	public Vector3 moveTarget;

	public LayerMask layerMask;
	public float rayDistance = 1000;

	public bool moving = false;

	public GameObject indicatorPrefab;
	public float stoppingDistance = 1.8f;
	public float moveSpeed = 25;

	void Start () {
		actor = GetComponent<SelectableActor> ();
	}
	
	void Update () 
	{
		if (actor.Selected)
		{
			if (Input.GetButtonDown ("Fire2"))
			{
				if (CameraRaycast.Instance.CameraCast (layerMask, rayDistance))
				{
					if (CameraRaycast.Instance.hitObject.tag == "Enemy")
					{
						print ("target enemy");
					} else
					{
						moveTarget = CameraRaycast.Instance.hitPoint;
						GameObject.Instantiate(indicatorPrefab, CameraRaycast.Instance.hitPoint + Vector3.up, Quaternion.identity);
						moving = true;
					}
				}
			}
		} else
		{

		}

		float distance = Vector3.Distance (transform.position, moveTarget);
		if (distance < stoppingDistance)
		{
			moving = false;
		} else
		{
			Move ();
		}

		Rotate ();
	}

	void Rotate()
	{
		if (moving)
		{
			// face movement direction
			Vector3 direction = moveTarget - transform.position;
			Quaternion dir = Quaternion.LookRotation (direction);
			transform.rotation = dir;
		} else
		{
			// find and face closest enemy
		}
	}

	void Move()
	{
		if (moveTarget != Vector3.zero)
		{
			transform.position = Vector3.MoveTowards (transform.position, moveTarget, moveSpeed * Time.deltaTime);
		}
	}
}
