using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour {

	public GameObject bulletPrefab;
	private float fireRate = 1f;
	private float lastShotInterval;

	// Use this for initialization
	void Start () {
		lastShotInterval = fireRate;
	}

	void Update () {
		lastShotInterval += Time.deltaTime;

		if (Input.GetButton ("Fire") && lastShotInterval >= fireRate) {
			Fire ();
			lastShotInterval = 0f;
		}
	}

	void Fire () {
		Instantiate (bulletPrefab,  gameObject.transform.position, gameObject.transform.rotation);
	}
}
