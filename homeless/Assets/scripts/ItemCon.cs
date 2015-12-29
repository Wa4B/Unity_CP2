using UnityEngine;
using System.Collections;

public class ItemCon : MonoBehaviour {

    public string itmeName;
    public float toHeightSet;
    public float speed;

    private float fromHeight;
    private float toHeight;
    private bool up;

	// Use this for initialization
	void Start () {
        up = true;
        fromHeight = transform.position.y;
        toHeight = toHeightSet + fromHeight;
	}
	
	// Update is called once per frame
	void Update () {

        if (up)
        {
            Vector3 pos = transform.position;
            pos.y += ((toHeight-pos.y)+speed) * Time.deltaTime;

            if (pos.y > toHeight)
            {
                up = false;
                pos.y = toHeight;

            }

            transform.position = pos;

        }else
        {
            Vector3 pos = transform.position;
            pos.y -= ((pos.y - fromHeight) + speed )* Time.deltaTime;
            

            if (pos.y < fromHeight)
            {
                up = true;
                pos.y = fromHeight;

            }

            transform.position = pos;
        }


    }
}
