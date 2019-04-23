using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script doesn't work yet.

public class cutscenecollider : MonoBehaviour
{

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag.Equals ("Finish"))
        {
            Debug.Log("THIS WORKS!");
        }
        
    }
}