using UnityEngine;
using System.Collections;

public class TriggerControll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<AreaEffector2D> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("gamemanager").GetComponent<GameManager> ().status == "start") {
			GetComponent<AreaEffector2D> ().enabled = true;
            GameObject.Find("gamemanager").GetComponent<GameManager>().status = "play";

        } else {
			GetComponent<AreaEffector2D> ().enabled = false;
		}
	}


}
