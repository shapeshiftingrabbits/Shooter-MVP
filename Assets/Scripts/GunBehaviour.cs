using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour {

	public GameObject bulletPrefab;
	private float fireRate = 0.2f;
	private float lastShotInterval;
	private Vector3 bulletStartPosition = new Vector3(0f, 0.01375f, 0f);

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
		Instantiate (bulletPrefab, gameObject.transform.TransformPoint(bulletStartPosition), BulletRotation());
	}

	Quaternion BulletRotation () {
		return Quaternion.FromToRotation(Vector3.up, gameObject.transform.forward);
	}
}
