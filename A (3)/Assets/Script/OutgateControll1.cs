using UnityEngine;
using System.Collections;

public class OutgateControll1 : MonoBehaviour {

	public bool shotch;

	private AreaEffector2D effec;

	// Use this for initialization
	void Start () {
		effec = this.GetComponent<AreaEffector2D> ();
		shotch = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (shotch == true) {
			//effec.enabled = true;
		
		} else {
			effec.enabled = false;
		}
	
		int adf =	aaaaa ();

	}
	void OnTriggerExit2D (Collider2D col){
		if (col.tag == "ball") {
			shotch = false;
		}



	}
	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "ball"&&shotch == false) {
			shotch = true;
			Quaternion a = Quaternion.Euler(0,0,0);
			col.gameObject.transform.rotation = a;
			col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(50,-10));
		}
		
		
		
	}

	int aaaaa(){
//		Debug.Log ("Aaaa");
		return 2;
	}

}
