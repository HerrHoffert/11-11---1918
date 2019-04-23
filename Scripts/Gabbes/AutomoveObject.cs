//Attach this script to an object to make it constantly move in a straight line. Adjust the floats to activate it.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomoveObject : MonoBehaviour
{



    public float xspeed = 0f;

    public float yspeed = 0f;

    public float zspeed = 0f;

	void FixedUpdate ()
    {

        transform.Translate(xspeed, yspeed, zspeed);

    }
}
