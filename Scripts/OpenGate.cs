using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class OpenGate : MonoBehaviour
{

    public bool gateOpen = true;
    public bool playerInRange;
    Animator gateAnim;

    // Use this for initialization
    void Start ()
    {
        gateAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("interact") && playerInRange)
        {
            gateOpens();
            StartCoroutine(GateTime());
        }
    }

    private IEnumerator GateTime()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("GateCollider").GetComponent<BoxCollider2D>().enabled = false;
    }

    public void gateOpens()
    {
        gateAnim.SetBool("Opens", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }


     


}
