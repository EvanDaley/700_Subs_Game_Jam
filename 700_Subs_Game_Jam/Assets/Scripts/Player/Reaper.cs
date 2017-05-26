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

	public bool canFire = true;
	public float cooldownTime = 0;
	public float coolDuration = .3f;
	public float damage = 40;

	public GameObject pSystem;


	void Start () {
		actor = GetComponent<SelectableActor> ();
		pSystem.SetActive (false);
	}
	
	void Update () 
	{
		if (cooldownTime < Time.time)
			canFire = true;
		
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

	void OnTriggerStay(Collider other)
	{
		if (canFire == true)
		{
			canFire = false;
			cooldownTime = Time.time + coolDuration;
			Attack (other.gameObject);
		}
	}

	void Attack(GameObject target)
	{
		pSystem.SetActive (true);
		pSystem.transform.LookAt (target.transform.position);
		Invoke ("HideSystem", coolDuration/4);

		EnemyHealth health = target.GetComponent<EnemyHealth> ();
		if (health != null)
		{
			health.TakeDamage (damage);
		} else
		{
			if (target.tag == "Minerals")
			{
				CurrencyManager.Instance.addMinerals (100);
			}

			if (target.tag == "GoldMinerals")
			{
				CurrencyManager.Instance.addMinerals (200);
			}
		}
	}

	void HideSystem()
	{
		pSystem.SetActive (false);

	}
}
