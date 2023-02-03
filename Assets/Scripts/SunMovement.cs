using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[RequireComponent(typeof(DirectionalLight))]
public class SunMovement : MonoBehaviour
{
    private Transform sun;

    public float yAxisRotationTime = 10f;
    
    public float xAxisRotationTime = 10f;

    public float maxXRotation = 10f;

    public bool updateTimes = false;

    private LTDescr xTween;

    private LTDescr yTween;
    // Start is called before the first frame update
    void Start()
    {
        sun = transform;
        sun.eulerAngles = new Vector3(maxXRotation, 0, 0);
        // xTween = LeanTween.rotateX(gameObject, 180f - maxXRotation, xAxisRotationTime).setRepeat(-1);
        yTween = LeanTween.rotateY(gameObject, 3600, yAxisRotationTime);
    }

    private void Update()
    {
        if (updateTimes)
        {
            yTween.setTime(yAxisRotationTime);
            if(xTween != null)            xTween.setTime(xAxisRotationTime);
        }
    }
}
