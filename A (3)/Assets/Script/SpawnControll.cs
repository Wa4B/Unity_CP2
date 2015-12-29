using UnityEngine;
using System.Collections;

public class SpawnControll : MonoBehaviour {
	public GameObject ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("gamemanager").GetComponent<GameManager> ().status == "get") {
			Instantiate(ball,this.transform.position,this.transform.rotation);
			GameObject.Find ("gamemanager").GetComponent<GameManager> ().status = "set";
		}
	}
}
