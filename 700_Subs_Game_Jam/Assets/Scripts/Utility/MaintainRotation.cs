using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainRotation : MonoBehaviour {

	public Vector3 rotation;

	void Update () {
		transform.rotation = Quaternion.LookRotation(rotation, Vector3.up);
	}
}
