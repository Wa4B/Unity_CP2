using UnityEngine;
using System.Collections;

public class GuardCon : MonoBehaviour {


    public float speedSet;

    public bool RL;
    public string status;

    private float speed;
    private bool RLc;
    private Animator anit;

	// Use this for initialization
	void Start () {
        speed = speedSet;
        status = "IDLE";
	   if(transform.localScale.x < 0)
        {
            RL = true;
        }
        else
        {
            RL = false;
        }

        RLc = RL;
        anit = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        switch (status)
        {
            case "IDLE":
                anit.SetBool("walk", false);
                break;
            case "WALK":
                anit.SetBool("walk", false);
                break;
        }

        if (RL)
        {
            status = "WALK";
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0);
        }
        else
        {
            status = "WALK";
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, 0);
        }
        if (RL != RLc)
        {
            RLc = RL;
            Vector3 objscale = transform.localScale;
            objscale.x *= -1;
            transform.localScale = objscale;
        }

    }
}
