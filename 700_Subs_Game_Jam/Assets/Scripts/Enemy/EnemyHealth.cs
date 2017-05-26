using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth = 1000;

	public float health = 1000;
	public Slider healthSlider;
	public float healingAmt = .2f;
	public GameObject bloodPrefab;

	public float deathValue;

	void Start () 
	{
		health = maxHealth;

		healthSlider.maxValue = maxHealth;
		healthSlider.value = maxHealth;

	}
	
	void Update () 
	{
		SelfHeal ();
	}

	public void TakeDamage(float amt)
	{
		print ("here");

		health -= amt;
		healthSlider.value = health;

		if (health < 0)
		{
			CurrencyManager.Instance.addMinerals (deathValue);

			GameObject.Instantiate (bloodPrefab, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

	void SelfHeal()
	{
		if (health < maxHealth)
		{
			health += healingAmt;
			healthSlider.value = health;

		}


	}


}
