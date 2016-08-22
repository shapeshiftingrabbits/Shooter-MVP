using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (Transform))]
[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

	public float movementSpeed = 5f;

	Transform playerTransform;
	Rigidbody playerRigidbody;

	// Use this for initialization
	void Start () {
		playerTransform = GetComponent<Transform> ();
		playerRigidbody = GetComponent<Rigidbody> ();
		ResetPosition ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float movementHorizontalAxisOffset = Input.GetAxis ("Horizontal");
		float movementVerticalAxisOffset = Input.GetAxis ("Vertical");

		float rotationHorizontalAxisOffset = Input.GetAxis ("RotateX");
		float rotationVerticalAxisOffset = Input.GetAxis ("RotateY");

		Move (movementHorizontalAxisOffset, movementVerticalAxisOffset);
		Rotate (rotationHorizontalAxisOffset, rotationVerticalAxisOffset);
	}

	void Move(float movementHorizontalAxisOffset, float movementVerticalAxisOffset) {
		Vector3 movement = new Vector3 (movementHorizontalAxisOffset * movementSpeed * Time.deltaTime,  0f, movementVerticalAxisOffset * movementSpeed * Time.deltaTime);

		playerRigidbody.MovePosition (playerTransform.position + movement);
	}

	void Rotate(float rotationHorizontalAxisOffset, float rotationVerticalAxisOffset) {
		playerTransform.eulerAngles = new Vector3 (0f, Mathf.Atan2(rotationHorizontalAxisOffset, rotationVerticalAxisOffset) * Mathf.Rad2Deg, 0f);
	}

	public void ResetPosition () {
		playerTransform.position = new Vector3 (0f, 0f, 0f);
	}

	public void Die () {
		SceneManager.LoadScene ("Main");
	}
}