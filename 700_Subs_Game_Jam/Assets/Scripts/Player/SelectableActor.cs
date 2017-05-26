using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActorType
{
	building,
	unit
}

public class SelectableActor : MonoBehaviour {

	public ActorType type;
	private GameObject selectRingInstance;
	public GameObject selectRingPrefab;

	public float ringScale;
	private bool isSelected = false;

	public float defaultRingElevation = 0;

	void Start () {
		
	}
	
	void Update () 
	{
		if (Input.GetButtonDown ("Fire2"))
		{
			//Selected = false;
			//SelectionController.Instance.SetSelection (null);
		}

		if (Input.GetButtonDown ("Fire1"))
		{
			if (SelectionController.Instance.GetSelection () != this.gameObject)
			{
				Selected = false;
			}
		}
	}

	public bool Selected
	{
		get
		{
			return isSelected;
		}

		set
		{
			isSelected = value;

			if (value)
			{
				if (selectRingInstance == null)
				{
					selectRingInstance = GameObject.Instantiate (selectRingPrefab, transform.position + (defaultRingElevation * Vector3.up), transform.rotation);
					selectRingInstance.transform.localScale = new Vector3 (ringScale, ringScale, ringScale);

					selectRingInstance.transform.SetParent (this.transform);
				} else
				{
					selectRingInstance.SetActive (true);
				}
			} else
			{
				if(selectRingInstance)
					selectRingInstance.SetActive (false);
			}
		}
	}

	void OnMouseDown()
	{
		Selected = true;
		SelectionController.Instance.SetSelection (gameObject);
	}
}
