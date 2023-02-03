using System;
using System.Collections;
using System.Collections.Generic;
using TDTK;
using UnityEngine;

[RequireComponent(typeof(UnitTower))]
public class EnabledIndicator : MonoBehaviour
{
    private UnitTower tower;

    public Color activeColor;
    public Color inactiveColor;
    public string colorPropertyName;
    public Renderer[] towerParts;
    private void Start()
    {
        tower = GetComponent<UnitTower>();
    }

    private void Update()
    {
        if (tower.isActive)
        {
            foreach (var towerPart in towerParts)
            {
                towerPart.material.SetColor(colorPropertyName, activeColor);
            }
        }
        else
        {
            foreach (var towerPart in towerParts)
            {
                towerPart.material.SetColor(colorPropertyName, inactiveColor);
            }
        }
    }
}
