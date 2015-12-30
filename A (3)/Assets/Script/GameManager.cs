using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public string status;


    public int steal;
    public int stealMax;
    public SwitchCon[] steals;

    public int score;
    public int life;

	// Use this for initialization
	void Start () {
		status = "get";
        steals = new SwitchCon[stealMax];
	}
	
	// Update is called once per frame
	void Update () {
        
        switch (status)
        {
            case "get":
                steal = 0;
                break;
            case "set":
                if (Input.GetKey(KeyCode.Space))
                {
                    status = "start";
                }
                break;
            case "start":
                break;
            case "play":
                if(steal == stealMax)
                {
                    for(int i = 0; i < stealMax; i++)
                    {
                        steals[i].on = false;
                    }
                }


                break;
        }
       
		
	}
    public void Switch(string str)
    {
        switch (str)
        {
            case "steal":
                steal += 1;
                break;
        }
    }
    public void AddSwitch(string name, SwitchCon obj)
    {
        switch (name)
        {
            case "steal":
                for(int i = 0; i < stealMax; i++)
                {
                    if(steals[i]== null)
                    {
                        steals[i] = obj;
                    }
                }
                break;
        }
    }
}
