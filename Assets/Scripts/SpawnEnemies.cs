using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject playerGameObject;
	private PlayerScript playerScript;
	public GameObject enemyPrefab;
	float previousPlayTimeTick = 0f;
	float currentPlayTime = 0f;
	float spawnRate = 0.5f;
	float minimumSpawnRate = 0.1f;
	float spawnRateCounter;
	int spawnMinRadius = 20;
	int spawnMaxRadius = 50;
	int nextPlayerKillsIncrease;
	float spawnRateIncreaseSecondsInterval = 2f;
	int spawnRateIncreaseKillsInterval = 10;
	float spawnRateIncrease = 0.01f;

	void Start () {
		spawnRateCounter = spawnRate;
		playerScript = playerGameObject.GetComponent<PlayerScript> ();
		nextPlayerKillsIncrease = spawnRateIncreaseKillsInterval;
	}

	void Update () {
		currentPlayTime += Time.deltaTime;
		spawnRateCounter += Time.deltaTime;

		if (spawnRateCounter >= spawnRate) {
			SpawnEnemy ();
			spawnRateCounter = 0f;
		}

		if (spawnRate > minimumSpawnRate) {
			IncreaseSpawnRate ();
		}

		Debug.Log ("Spawn rate: " + spawnRate + ", " + (1f / spawnRate) + " enemies per second");
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
		return (new Vector2 (playerGameObject.transform.position.x, playerGameObject.transform.position.z));
	}

	void IncreaseSpawnRate() {
		if (currentPlayTime - previousPlayTimeTick >= spawnRateIncreaseSecondsInterval) {
			spawnRate = Mathf.Clamp (spawnRate - spawnRateIncrease, minimumSpawnRate, spawnRate);
			previousPlayTimeTick = currentPlayTime;
		}

		if (playerScript.player.EnemiesKilled() == nextPlayerKillsIncrease) {
			spawnRate = Mathf.Clamp (spawnRate - spawnRateIncrease, minimumSpawnRate, spawnRate);
			nextPlayerKillsIncrease += spawnRateIncreaseKillsInterval;
		}
	}
}
