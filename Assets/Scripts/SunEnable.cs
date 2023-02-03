using System;
using System.Collections;
using System.Collections.Generic;
using TDTK;
using UnityEngine;

public class SunEnable : MonoBehaviour
{
    public bool shouldEnable = true;
    public GameObject self;

    private void OnTriggerEnter(Collider other)
    {
        var tower = other.gameObject.GetComponent<UnitTower>();
        if (tower && other.gameObject != self)
        {
            tower.isActive = shouldEnable;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        var tower = other.gameObject.GetComponent<UnitTower>();
        if (tower && other.gameObject != self)
        {
            tower.isActive = !shouldEnable;
        }    
    }

}
