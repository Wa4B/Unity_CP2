using UnityEngine;
using System.Collections;

public class CharactorCon : MonoBehaviour {

	public float speed;
    public float jumpPowerset;

	public string status;
    public GameObject weapon;

    public bool RL;
	

    public int jumpcnt;
    public bool grounded;


	private bool RLc;

    private float jumpPower;
    private GameObject myweapon;
    private Animator anit;
	private Vector3 objscale;
    private Rigidbody2D rigid;

    private GameManagerCon GM;
	// Use this for initialization
	void Start () {
		status = "IDLE";
		anit = GetComponent<Animator> ();
		RL = false;
		RLc = false;
		objscale = transform.localScale;
        rigid = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("GameManager").GetComponent<GameManagerCon>();
	}

    // Update is called once per frame
    void Update()
    {
        if (!GM.isPause&&status != "JUMP")
        {          
            if (grounded)
            {
                status = "AIR";
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    status = "WALK";
                    RL = false;
                   // transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, 0);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    status = "WALK";
                    RL = true;
                   // transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0);
                }
                else if (Input.GetKey(KeyCode.Space))
                {
                    status = "ATTACK";
                    if (myweapon == null)
                    {
                        attack();
                    }
                }
                else
                {
                    status = "IDLE";
                }
            }
            else
            {
                status = "AIR";
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    status = "AIRWALK";
                    RL = false;              
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    status = "AIRWALK";
                    RL = true;  
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && jumpcnt > 0)
            {
                jumpcnt -= 1;
                if (grounded)
                {
                    status = "JUMP";
                    jumpPower = jumpPowerset;
                }
                else
                {
                    status = "JUMP";
                    jumpPower = jumpPowerset*4/5;
                }
            }

            //=================Animation============================

            switch (status)
            {
                case "IDLE":
                    anit.SetInteger("status", 0);
                    break;
                case "WALK":
                    anit.SetInteger("status", 1);
                    break;
                case "JUMP":
                case "JUMPED":
                case "AIR":
                case "AIRWALK":
                    anit.SetInteger("status", 2);
                    break;
                default:
                    anit.SetInteger("status", 0);
                    break;

            }

            //=================


            if (myweapon != null && status != "ATTACK")
            {
                Destroy(myweapon);
            }
            if (RL != RLc)
            {
                RLc = RL;
                objscale.x *= -1;
                transform.localScale = objscale;
            }
        }
	}

    void FixedUpdate()
    {
        switch (status)
        {
            case "JUMP":
                rigid.velocity = new Vector2(rigid.velocity.x, jumpPower * Time.deltaTime);
                status = "JUMPED";
                break;
            case "WALK":
            case "AIRWALK":
                if (RL)
                {
                   // rigid.velocity = new Vector2(speed * Time.deltaTime, rigid.velocity.y);
                   transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0);
                }
                else
                {
                   // rigid.velocity = new Vector2(speed*-1 * Time.deltaTime, rigid.velocity.y);
                   transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, 0);
                }
                break;
        }
    }

    void attack()
    {
        Vector3 pos = transform.position;
        pos.x = pos.x - transform.localScale.x/5;

        GameObject wp =(GameObject) Instantiate(weapon, transform.position, transform.rotation);

        if (RL)
        {
            Vector3 scales = wp.gameObject.transform.localScale;
            scales.x *= -1;
            wp.gameObject.transform.localScale = scales;
            wp.GetComponent<WeaponCon>().setR(true);
            

        }
        myweapon = wp;

    }

    //==============
     


    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.tag == "ground")
        {
            jumpcnt = 1;
            grounded = true;
        }
    }

   

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            grounded = false;
        }
    }

}
