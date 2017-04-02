using UnityEngine;
using System.Collections;

public class ShootGun : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject bulletCasingPrefab;
    private float fireRate = 0.2f;
    private float lastShotInterval;
    private Vector3 bulletStartPosition = new Vector3(0f, 0.01375f, 0f);
    private Vector3 bulletCasingStartPosition = new Vector3(0.00134f, 0.02091f, -0.00174f);
    private float bulletThrust = 20f;
    private float bulletCasingThrust = 0.01f;
    private float bulletCasingMinimumThrustDirectionUp = 2f;
    private float bulletCasingMaximumThrustDirectionUp = 4f;
    private float bulletCasingMinimumThrustDirectionRight = 4f;
    private float bulletCasingMaximumThrustDirectionRight = 6f;
    private float bulletCasingMinimumThrustDirectionForward = -2f;
    private float bulletCasingMaximumThrustDirectionForward = -3f;
    private float bulletCasingMinimumTorqueRight = -0.5f;
    private float bulletCasingMaximumTorqueRight = -1.5f;
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
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, gameObject.transform.TransformPoint(bulletStartPosition), BulletRotation());
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.up * bulletThrust, ForceMode.Force);

        GameObject bulletCasing = (GameObject)Instantiate(bulletCasingPrefab, gameObject.transform.TransformPoint(bulletCasingStartPosition), BulletRotation());
        bulletCasing.GetComponent<Rigidbody>().AddForce(BulletCasingForce() * bulletCasingThrust, ForceMode.Impulse);
        bulletCasing.GetComponent<Rigidbody>().AddTorque(BulletCasingTorque());
    }

    Quaternion BulletRotation () {
        return Quaternion.FromToRotation(Vector3.up, gameObject.transform.forward);
    }

    Vector3 BulletCasingForce() {
        return (
            (
                (
                    gameObject.transform.up *
                    Random.Range(
                        bulletCasingMinimumThrustDirectionUp,
                        bulletCasingMaximumThrustDirectionUp
                    )
                )
            ) +
            (
                (
                    gameObject.transform.right *
                    gameObject.transform.localScale.x *
                    Random.Range(
                        bulletCasingMinimumThrustDirectionRight,
                        bulletCasingMaximumThrustDirectionRight
                    )
                )
            ) +
            (
                (
                    gameObject.transform.forward *
                    Random.Range(
                        bulletCasingMinimumThrustDirectionForward,
                        bulletCasingMaximumThrustDirectionForward
                    )
                )
            )
        );
    }

    Vector3 BulletCasingTorque() {
        return (
            gameObject.transform.right *
            Random.Range(bulletCasingMinimumTorqueRight, bulletCasingMaximumTorqueRight)
        );
    }
}