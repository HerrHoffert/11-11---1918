//Attach this script to an object to make it constantly move in a straight line. Adjust the floats to activate it.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomoveCam : MonoBehaviour
{

    //HOT CODE
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    //HOT CODE

    public float xspeed = 0f;

    public float yspeed = 0f;

    public float zspeed = 0f;

	void FixedUpdate ()
    {

        transform.Translate(xspeed, yspeed, zspeed);

        //HOT CODE BELOW


            Vector3 targetPosition = new Vector3(target.position.x,
                                                 target.position.y,
                                                 transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                           minPosition.x,
                                           maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                           minPosition.y,
                                           maxPosition.y);

            transform.position = Vector3.Lerp(transform.position,
                                              targetPosition, smoothing);




    }
}
