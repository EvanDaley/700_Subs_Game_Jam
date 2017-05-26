using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipType
{
	reaper,
	corsair,
	deadilus
}

public class Nexus : MonoBehaviour {

	public GameObject spawnPoint;

	public GameObject reaperPrefab;

	void Start () 
	{
		GetComponent<SelectableActor> ().Selected = true;
	}
	
	void Update () {
		
	}

	public void TrySpawnReaper()
	{
		if(CurrencyManager.Instance.getMinerals() > 5999)
		{
			CurrencyManager.Instance.subtractMinerals (6000);
			GameObject.Instantiate (reaperPrefab, spawnPoint.transform.position, Quaternion.identity);
		}
	}
}
