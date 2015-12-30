using UnityEngine;
using System.Collections;

public class SwitchCon : MonoBehaviour {

    public string objName;
    public int number;
    public bool on;

    public Sprite onSprite;
    public Sprite offSprite;

    private GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("gamemanager").GetComponent<GameManager>();
        gm.AddSwitch(objName, this);
	}
	
	// Update is called once per frame
	void Update () {
        if (on)
        {
            GetComponent<SpriteRenderer>().sprite = onSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = offSprite;
        }
        if(gm.status == "get")
        {
            on = false;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ball"&&!on)
        {
            on = true;
            gm.Switch(objName);
        }
    }
}
