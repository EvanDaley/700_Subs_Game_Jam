using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

	public GameObject spikerPrefab;

	public float spawnTime = 0;
	public float spawnCooldown = 4;

	public float spawnRadius = 300;

	void Start () {
		
	}
	
	void Update () 
	{
		if (Time.time > spawnTime)
		{
			spawnTime = Time.time + spawnCooldown;

			if (spawnCooldown < .1f)
				spawnCooldown = .1f;
			else
				spawnCooldown *= .99f;

			SpawnRandomEnemy ();

		}
	}

	void SpawnRandomEnemy()
	{
		Vector3 spawnPosition = GetSpawnPosition ();
		GameObject.Instantiate (spikerPrefab, spawnPosition, Quaternion.identity);
	}

	Vector3 GetSpawnPosition()
	{
		Vector2 spawnPosition = Random.insideUnitCircle * spawnRadius;
		Vector3 spawnPos = new Vector3 (spawnPosition.x, .9f, spawnPosition.y);

		if (Vector3.Distance (Nexus.Instance.transform.position, spawnPos) < 50)
		{
			return GetSpawnPosition ();
		} else
			return spawnPos;

	}
}
