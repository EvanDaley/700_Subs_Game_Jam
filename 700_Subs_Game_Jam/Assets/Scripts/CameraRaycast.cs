using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour {

	public static CameraRaycast Instance;

	public GameObject hitObject;
	public Transform hitTransform;
	public Vector3 hitPoint;
	public Vector3 hitNormal;

	void Awake()
	{
		Instance = this;
	}

	public bool CameraCast(LayerMask layerMask, float distance)
	{
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, distance, layerMask))
		{
			hitPoint = hit.point;
			hitTransform = hit.transform;
			hitObject = hit.transform.gameObject;
			hitNormal = hit.normal;

			return true;
		} else
			return false;
	}
}
