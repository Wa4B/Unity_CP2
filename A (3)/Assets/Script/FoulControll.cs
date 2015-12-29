using UnityEngine;
using System.Collections;

public class FoulControll : MonoBehaviour {


    public float power;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "ball") {
			Quaternion a = Quaternion.Euler(0,0,0);
			col.gameObject.transform.rotation = a;
            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, power);

		}
	}
}
