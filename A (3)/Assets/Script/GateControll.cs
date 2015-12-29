using UnityEngine;
using System.Collections;

public class GateControll : MonoBehaviour {
	private GameObject gout;
	// Use this for initialization
	void Start () {
		gout = GameObject.Find ("outgate");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "ball") {

			col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			col.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			col.gameObject.transform.position = gout.transform.position;

		}
	}
}
