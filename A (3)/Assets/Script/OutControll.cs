using UnityEngine;
using System.Collections;

public class OutControll : MonoBehaviour {
	public GameObject outline;
	// Use this for initialization
	void Start () {
		outline = GameObject.Find ("out");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < outline.transform.position.y) {
			Destroy(this.gameObject);
			GameObject.Find ("gamemanager").GetComponent<GameManager> ().status = "get";
		}
	}

}
