using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAI : MonoBehaviour {

	public float moveSpeed = 4;
	public float stoppingDistance = 2;
	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	void Update () 
	{
		float distance = Vector3.Distance (transform.position, Nexus.Instance.transform.position);

		if (distance < stoppingDistance)
		{
			// animator.attack
		} else
		{
			// animator.move
			Move ();
		}

		transform.LookAt (Nexus.Instance.transform.position);


	}

	void Move()
	{
		transform.position = Vector3.MoveTowards (transform.position, Nexus.Instance.transform.position, moveSpeed * Time.deltaTime);
	}
}
