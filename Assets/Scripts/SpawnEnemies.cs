using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject player;
	public GameObject enemyPrefab;
	float spawnRate = 0.5f;
	float spawnRateCounter = 3f;
	int spawnMinRadius = 20;
	int spawnMaxRadius = 50;

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
		Vector3 newPosition = randomPositionAroundPlayer() + player2DPosition();

		newPosition.z = newPosition.y;
		newPosition.y = 0;

		return newPosition;
	}

	Vector2 randomPositionAroundPlayer () {
		return (Random.insideUnitCircle.normalized * Random.Range(spawnMinRadius, spawnMaxRadius));
	}

	Vector2 player2DPosition () {
		return (new Vector2 (player.transform.position.x, player.transform.position.z));
	}
}
