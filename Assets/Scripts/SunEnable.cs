using System;
using System.Collections;
using System.Collections.Generic;
using TDTK;
using UnityEngine;

public class SunEnable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var tower = other.gameObject.GetComponent<UnitTower>();
        if (tower)
        {
            tower.enabled = true;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        var tower = other.gameObject.GetComponent<UnitTower>();
        if (tower)
        {
            tower.enabled = false;
        }    
    }

}
