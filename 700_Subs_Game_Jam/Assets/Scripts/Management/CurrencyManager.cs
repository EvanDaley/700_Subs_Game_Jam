using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour {

	public static CurrencyManager Instance;
	public Text resourceText;
	public float minerals;

	void Awake()
	{
		Instance = this;
		resourceText.text = minerals.ToString ();

	}

	public void addMinerals(float amt)
	{
		minerals += amt;
		resourceText.text = minerals.ToString ();
	}

	public void subtractMinerals(float amt)
	{
		minerals -= amt;
		resourceText.text = minerals.ToString ();

		// save minerals
	}


	public float getMinerals()
	{
		return minerals;
	}
}
