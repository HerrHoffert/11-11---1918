//Attach this script to an object to make it constantly move in a straight line. Adjust the floats to activate it.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAutomoveObject : MonoBehaviour {

    private float xspeed = 0f;

    private float yspeed = 0f;

    private float zspeed = 0f;

    //These floats will change the range of the randomness if an axis is set to "Random"

    public float xrangemin = 0.1f;

    public float xrangemax = 3.0f;

    public float yrangemin = 0.1f;

    public float yrangemax = 3.0f;

    public float zrangemin = 0.1f;

    public float zrangemax = 3.0f;



    // Use this for initialization
    void Start()
    {

        //These are the rules for random number generation

       
            xspeed = Random.Range(xrangemin, xrangemax);
        
              
            yspeed = Random.Range(yrangemin, yrangemax);
        

            zspeed = Random.Range(zrangemin, zrangemax);
       

    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(xspeed, yspeed, zspeed);

        
	}
}
