using UnityEngine;
using System.Collections;

public class BatControll : MonoBehaviour {

    public string status;
    public float swingSpeed;
    public float backSpeed;
    public float maxAngle;
    public float minAngle;

    private HingeJoint2D hj;
    private JointMotor2D motor;
    private Rigidbody2D rigid;
    private Vector3 pos;

	// Use this for initialization
	void Start () {
        pos = transform.position;
        hj = GetComponent<HingeJoint2D>();
        rigid = GetComponent<Rigidbody2D>();
        motor = new JointMotor2D();

        minAngle = transform.localEulerAngles.z;

        status = "Idle";


        Physics2D.GetIgnoreLayerCollision(8, 9);
	}

	// Update is called once per frame

    void FixedUpdate()
    {
        switch (status)
        {
            case "Idle":

                if (Input.GetKey(KeyCode.Z))
                {
                    rigid.isKinematic = false;
                    status = "Swing";
                }
                break;
            case "Swing":
                motor.motorSpeed = -swingSpeed;
                motor.maxMotorTorque = swingSpeed;
                hj.motor = motor;
                status = "Swing_After";
                break;
            case "Swing_After":
                if (transform.localEulerAngles.z > maxAngle)
                {
                    rigid.isKinematic = true;
                    transform.localEulerAngles = new Vector3(0, 0, maxAngle);
                    status = "Swing_End";
                }
                break;
            case "Swing_End":
                if (!Input.GetKey(KeyCode.Z))
                {
                    rigid.isKinematic = false;
                    status = "BackSwing";
                }
                break;
            case "BackSwing":
                
                motor.motorSpeed = backSpeed;
                motor.maxMotorTorque = swingSpeed;
                hj.motor = motor;
                status = "Back_After";
                break;
            case "Back_After":
                if (Input.GetKey(KeyCode.Z))
                {
                    rigid.isKinematic = false;
                    status = "Swing";
                }
                if (transform.localEulerAngles.z < minAngle)
                {
                    rigid.isKinematic = true;
                    transform.localEulerAngles = new Vector3(0, 0, minAngle);
                    status = "Idle";
                }
                break;
        }
    }
    
	void Update () {

        //transform.position = pos;
        

	}
}
