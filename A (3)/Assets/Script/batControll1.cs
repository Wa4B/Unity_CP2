using UnityEngine;
using System.Collections;

public class batControll1 : MonoBehaviour {

	public int ch;
	public float swingspeed;
	public float backspeed;
    public float maxAngle;
    public float bounceForce;
    public Vector3 setRotation;
	HingeJoint2D hinge ;

	// Use this for initialization
	void Start () {
		ch = 0;
        setRotation = transform.localEulerAngles;
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}
	void Update(){
      

        switch (ch)
        {
            case 0:
                if (Input.GetKey(KeyCode.X))
                {
                    ch = 1;
                }
                break;
            case 1:

                transform.Rotate(Vector3.forward*swingspeed*Time.deltaTime);
                if (transform.localEulerAngles.z >= maxAngle)
                {
                    ch = 2;
                }
                break;
            case 2:
                transform.Rotate(Vector3.back * backspeed * Time.deltaTime);

                if (transform.localEulerAngles.z <= setRotation.z)
                {
                    ch = 0;
                }
                break;
        }
        

	}


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ball" && ch == 1)
        {
            Vector2 v2 = new Vector2();
            v2.x = Mathf.Sin(transform.rotation.z) * bounceForce;
            v2.y = Mathf.Cos(transform.rotation.z) * bounceForce;

            col.gameObject.GetComponent<Rigidbody2D>().AddForce(v2);
            
        }
    }
    void OnTriggerExit2D(Collider2D col){
		if (col.tag == "ball") {
            
        }
	}

}
