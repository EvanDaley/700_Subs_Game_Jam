using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour {

	public float lifeTime;
	private float deathTime;

	void Start () {
		deathTime = Time.time + lifeTime;
	}
	
	void Update () {
		if (Time.time > deathTime)
			Destroy (gameObject);
	}
}
