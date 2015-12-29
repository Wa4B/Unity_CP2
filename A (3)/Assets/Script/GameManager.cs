using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public string status;


    public int steal;
    public int stealMax;
	// Use this for initialization
	void Start () {
		status = "get";
	}
	
	// Update is called once per frame
	void Update () {
        if( status == "get")
        {
            steal = 0;
        }
		if (Input.GetKey (KeyCode.Space)&& status == "set") {
			status = "start";
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
}
