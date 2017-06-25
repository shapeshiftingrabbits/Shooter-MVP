using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColorOverTime : MonoBehaviour {
	public Color destinationColor;
	public float changeSpeed = 1f;
	Color originalColor;
	float lerpPosition = 0f;
	Renderer gameObjectRenderer;
	Color newColor;

	void Start () {
		gameObjectRenderer = gameObject.GetComponent<Renderer>();
		originalColor = gameObjectRenderer.material.color;
	}
	
	void Update () {
		lerpPosition += Time.deltaTime * changeSpeed;

		newColor = Color.Lerp(originalColor, Color.black, lerpPosition);
		gameObjectRenderer.material.SetColor("_Color", newColor);
	}
}
