using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject player;
	public GameObject enemyPrefab;
	float spawnRate = 3f;
	float spawnRateCounter = 3f;
	int spawnMinDistanceX = 10;
	int spawnMinDistanceZ = 10;
	int spawnMaxDistanceX = 20;
	int spawnMaxDistanceZ = 20;

	void Update () {
		spawnRateCounter += Time.deltaTime;

		if (spawnRateCounter >= spawnRate) {
			SpawnEnemy ();
			spawnRateCounter = 0f;
		}
	}

	void SpawnEnemy () {
		Instantiate (enemyPrefab, enemyRandomSpawnPosition(), Quaternion.identity);
	}

	Vector3 enemyRandomSpawnPosition () {
		return (
			new Vector3 (
				Random.Range(spawnMinDistanceX, spawnMaxDistanceX),
				0f,
				Random.Range(spawnMinDistanceZ, spawnMaxDistanceZ)
			)
		);
	}
}
