using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (Transform))]
[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

	private float movementSpeed = 10f;
	private float rotationSpeed = 10f;
	private float movementDeadzone = 0.25f;
	private float rotationDeadzone = 0.25f;

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
		Vector2 movementInput = stickInput ("Horizontal", "Vertical");
		if (movementInput.magnitude >= movementDeadzone) {
			Move (movementInput);
		}

		Vector2 rotationInput = stickInput ("RotateX", "RotateY");
		if (rotationInput.magnitude >= rotationDeadzone) {
			Rotate (rotationInput, Time.deltaTime);
		}
	}

	Vector2 stickInput(string XAxisName, string YAxisName) {
		return new Vector2 (Input.GetAxis (XAxisName), Input.GetAxis (YAxisName));
	}

	void Move(Vector2 movementInput) {
		Vector3 movement = new Vector3 (movementInput.x * movementSpeed * Time.deltaTime,  0f, movementInput.y * movementSpeed * Time.deltaTime);

		playerRigidbody.MovePosition (playerTransform.position + movement);
	}

	void Rotate(Vector2 rotationInput, float deltaTime) {
		float angle = Mathf.Atan2(rotationInput.x, rotationInput.y) * Mathf.Rad2Deg;

		playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, Quaternion.Euler(0f, angle, 0f), deltaTime * rotationSpeed);
	}

	public void ResetPosition () {
		playerTransform.position = new Vector3 (0f, 0f, 0f);
	}
}