using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[RequireComponent(typeof(DirectionalLight))]
public class SunMovement : MonoBehaviour
{
    private Transform sun;

    public bool rotateY = true;
    public float yAxisRotationTime = 10f;


    public bool rotateX = true;
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
        if (rotateX)
        {
            RotateX();
        }

        if (rotateY)
        {
            RotateY();
        }
    }

    private void RotateY()
    {
        yTween = LeanTween.rotateY(gameObject, 720, yAxisRotationTime).setRepeat(-1);
    }

    private void RotateX()
    {
        xTween = LeanTween.rotateX(gameObject, 180f - maxXRotation, xAxisRotationTime).setRepeat(-1);
    }

    private void Update()
    {
        if (updateTimes)
        {
            if (rotateX)
            {
                if (xTween == null)
                {
                    RotateX();
                }

                xTween.resume();
                xTween.setTime(xAxisRotationTime);
            }
            else
            {
                xTween.pause();
            }

            if (rotateY)
            {
                if (yTween == null)
                {
                    RotateY();
                }

                yTween.resume();
                yTween.setTime(yAxisRotationTime);
            }
            else
            {
                yTween.pause();
            }
            
            
        }
    }
}
