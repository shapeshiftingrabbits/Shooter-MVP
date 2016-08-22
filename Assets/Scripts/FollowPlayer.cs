using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Transform))]
public class FollowPlayer : MonoBehaviour {
	public GameObject player;
	Transform cameraTransform;

	void Start () {
		cameraTransform = GetComponent<Transform> ();
	}

	void Update () {
		cameraTransform.position = new Vector3 (player.transform.position.x, cameraTransform.position.y, player.transform.position.z);
	}
}
