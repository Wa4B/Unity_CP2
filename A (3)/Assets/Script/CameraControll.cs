using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {
	GameObject ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("ball");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;
		Vector3 camerapos = Camera.main.transform.position;
		Vector3 target;
		if (pos.y < -2.8f) {
			target = new Vector3 (camerapos.x, -2.8f, camerapos.z);
		} else if (pos.y > 2.8f) {
			target = new Vector3 (camerapos.x, 2.8f, camerapos.z);
		} else {
			target = new Vector3 (camerapos.x, pos.y, camerapos.z);
		}
		Camera.main.transform.position = target;
	}
}
