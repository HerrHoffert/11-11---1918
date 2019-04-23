using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableobj : MonoBehaviour {

    public GameObject anyobj;

    public bool Enableobject;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Enableobject == true) anyobj.SetActive(true);
        else anyobj.SetActive(false);

    }
}
