using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour {

	public GameObject bulletPrefab;
    public GameObject bulletCasingPrefab;
    private float fireRate = 0.2f;
	private float lastShotInterval;
	private Vector3 bulletStartPosition = new Vector3(0f, 0.01375f, 0f);
    private Vector3 bulletCasingStartPosition = new Vector3(0.00134f, 0.02091f, -0.00174f);
    private float bulletCasingThrust = 10f;
    private Animator gunAnimator;

	void Start () {
		lastShotInterval = fireRate;
		gunAnimator = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		lastShotInterval += Time.deltaTime;

		if (Input.GetButton ("Fire") && lastShotInterval >= fireRate) {
			Fire ();
			gunAnimator.SetBool ("shotTriggered", true);
			lastShotInterval = 0f;
		}
	}

	void Fire () {
        Instantiate(bulletPrefab, gameObject.transform.TransformPoint(bulletStartPosition), BulletRotation());

        GameObject bulletCasing = (GameObject)Instantiate(bulletCasingPrefab, gameObject.transform.TransformPoint(bulletCasingStartPosition), BulletRotation());
        bulletCasing.GetComponent<Rigidbody>().AddForce(BulletCasingForceDirection() * bulletCasingThrust, ForceMode.Impulse);
        bulletCasing.GetComponent<Rigidbody>().AddTorque(-gameObject.transform.right);
    }

	Quaternion BulletRotation () {
		return Quaternion.FromToRotation(Vector3.up, gameObject.transform.forward);
	}

    Vector3 BulletCasingForceDirection() {
        return ((gameObject.transform.up / 2000) + (gameObject.transform.right / 6000));
    }
}
