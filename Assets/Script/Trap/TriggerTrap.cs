using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    public GameObject[] grounds;

    void Start()
    {
        EnableScript(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            EnableScript(true);
        }
    }

    public void EnableScript(bool blval)
    {
        foreach(var item in grounds){
            item.GetComponent<TrapGround>().enabled = blval;
        }
    }
}
