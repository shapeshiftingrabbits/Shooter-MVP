using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject playerGameObject;
	private PlayerScript playerScript;
	public GameObject enemyPrefab;

	float previousPlayTimeTick = 0f;
	float currentPlayTime = 0f;

	float spawnSpeedTick;
	float enemiesPerSecond = 1f;
	float minimumEnemiesPerSecond = 1f;
	float maximumEnemiesPerSecond = 10f;
	float enemiesPerSecondIncrease = 0.01f;

	float enemiesPerSecondIncreasePlayTimeInterval = 1f;

	int nextKillsDecrease;
	int enemiesPerSecondDecreaseKillsInterval = 5;

	int spawnMinRadius = 20;
	int spawnMaxRadius = 50;

	void Start () {
		spawnSpeedTick = SpawnSpeed();
		playerScript = playerGameObject.GetComponent<PlayerScript> ();
		nextKillsDecrease = enemiesPerSecondDecreaseKillsInterval;
	}

	void Update () {
		currentPlayTime += Time.deltaTime;
		spawnSpeedTick += Time.deltaTime;

		if (spawnSpeedTick >= SpawnSpeed()) {
			SpawnEnemy ();
			spawnSpeedTick = 0f;
		}

		if (enemiesPerSecond <= maximumEnemiesPerSecond) {
			IncreaseSpawnRate ();
		}
	}

	void SpawnEnemy () {
		GameObject enemy = (GameObject) Instantiate (enemyPrefab, enemyRandomSpawnPosition(), Quaternion.identity);
		enemy.GetComponent<MoveTowardsTarget>().SetTarget(playerGameObject);
	}

	float SpawnSpeed() {
		return (1f / enemiesPerSecond);
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
		if (currentPlayTime - previousPlayTimeTick >= enemiesPerSecondIncreasePlayTimeInterval) {
			enemiesPerSecond = Mathf.Clamp (enemiesPerSecond + enemiesPerSecondIncrease, enemiesPerSecond, maximumEnemiesPerSecond);
			previousPlayTimeTick = currentPlayTime;
		}

		if (playerScript.player.EnemiesKilled() == nextKillsDecrease) {
			enemiesPerSecond = Mathf.Clamp (enemiesPerSecond - enemiesPerSecondIncrease, minimumEnemiesPerSecond, enemiesPerSecond);
			nextKillsDecrease += enemiesPerSecondDecreaseKillsInterval;
		}
	}
}
