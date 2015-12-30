using UnityEngine;
using System.Collections;

public class MessageCon : MonoBehaviour {





    public Sprite homerun;
    public Sprite grand;
    public Sprite hit;
    public Sprite steal;
    public Sprite foul;
    public Sprite error;
    public Sprite out_;

    public Sprite solo;
    public Sprite two;
    public Sprite three;
    public Sprite inside;
    


    private SpriteRenderer subM;
    private SpriteRenderer mainM;

	// Use this for initialization
	void Start () {
        subM = GameObject.Find("sub").GetComponent<SpriteRenderer>();
        mainM = GameObject.Find("main").GetComponent<SpriteRenderer>();

        subM.sprite = null;
        mainM.sprite = null;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Massage(string str)
    {
        switch (str)
        {
            case "solo":
                subM.sprite = solo;
                break;
            case "two":
                subM.sprite = two;            
                break;
            case "three":
                subM.sprite = three;
                break;
            case "inside":
                subM.sprite = inside;              
                break;
            case "grand":
            case "steal":
            case "foul":
            case "hit":
            case "none":
                subM.sprite = null;            
                break;
        }
        switch (str)
        {
            case "solo":
            case "two":
            case "three":
            case "inside":
                mainM.sprite = homerun;
                break;
            case "grand":
                mainM.sprite = grand;
                break;
            case "hit":
                mainM.sprite = hit;
                break;
            case "foul":
                mainM.sprite = foul;
                break;
            case "steal":
                mainM.sprite = steal;
                break;
            case "error":
                mainM.sprite = error;
                break;
            case "out":
                mainM.sprite = out_;
                break;
            case "none":
                mainM.sprite = null;
                break;

        }
    }
}
