using UnityEngine;
using System.Collections;

public class WeaponCon : MonoBehaviour {

    

    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void setR(bool Right)
    {
        GetComponent<Animator>().SetBool("right", Right);
    }
    public void end()
    {
        Destroy(gameObject);
    }

}
