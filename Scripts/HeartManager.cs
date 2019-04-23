using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{

    public Image[] hearts;
    public Sprite fullLuck;
    public Sprite halfFullLuck;
    public Sprite emptyLuck;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;


    // Use this for initialization
    void Start ()
    {

        InitHearts();

	}
	
    public void InitHearts()
    {
        for(int i = 0; i < heartContainers.initialValue; i ++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullLuck;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.RuntimeValue / 2;
        for (int i = 0; i < heartContainers.initialValue; i ++)
        {
            if (i <= tempHealth-1)
            {
                //Full Luck
                hearts[i].sprite = fullLuck;
            }
            else if (i >= tempHealth)
            {
                //No Luck
                hearts[i].sprite = emptyLuck;
            }
            else
            {
                //Half Luck
                hearts[i].sprite = halfFullLuck;
            }
        }
    }

}
