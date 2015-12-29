using UnityEngine;
using System.Collections;

public class GameManagerCon : MonoBehaviour {

    public bool isPause;

	// Use this for initialization
	void Start () {
        isPause = false;
        
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
	
	}
    public void pause(bool botton)
    {
        if (botton)
        {
            Time.timeScale = 0;
            isPause = true;
        }
        else
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }
    public void pause()
    {
        if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
        }
        else
        {
            Time.timeScale = 0;
            isPause = true;
        }
    }
}
