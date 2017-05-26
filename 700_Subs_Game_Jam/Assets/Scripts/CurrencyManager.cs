using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {

	public static CurrencyManager Instance;

	public float minerals;

	void Awake()
	{
		Instance = this;
	}

	public void addMinerals(float amt)
	{
		minerals += amt;

	}

	public void subtractMinerals(float amt)
	{
		minerals -= amt;

		// save minerals
	}


	public float getMinerals()
	{
		return minerals;
	}
}
