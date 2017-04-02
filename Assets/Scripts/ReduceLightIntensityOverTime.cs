using UnityEngine;

public class ReduceLightIntensityOverTime : MonoBehaviour {

	public float speed = 1f;
	private Light lightComponent;

	void Start () {
		lightComponent = gameObject.GetComponent<Light>();
	}
	
	void Update () {
		if (lightComponent.intensity > 0f) {
			lightComponent.intensity -= speed * Time.deltaTime;
		}
	}
}
