using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ShadowCalc : MonoBehaviour
{
    private Transform sun;

    public Transform shadowColliderPosition;
    public BoxCollider shadowCollider;
    
    public float maxShadowColliderLength = 4;

    public float maxShadowAngleThreshold = 20;
    // Start is called before the first frame update
    void Start()
    {
        var obj = GameObject.FindWithTag("Sun");
        sun = obj.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (shadowCollider)
        {
            var sunDir = Vector3.ProjectOnPlane(sun.forward, Vector3.up);
            shadowColliderPosition.forward = sunDir;

            var sunXAngle = sun.eulerAngles.x;
            var lengthPercentage = 0f;
            if (sunXAngle > 90)
            {
                lengthPercentage = Mathf.InverseLerp(90, 180 - maxShadowAngleThreshold, sun.eulerAngles.x);
            }
            else
            {
                lengthPercentage = Mathf.InverseLerp(90, 0 + maxShadowAngleThreshold, sun.eulerAngles.x);
            }

            shadowCollider.size = new Vector3(
                shadowCollider.size.x,
                shadowCollider.size.y,
                maxShadowColliderLength * lengthPercentage);
            shadowCollider.center = new Vector3(
                shadowCollider.center.x,
                shadowCollider.center.y,
                maxShadowColliderLength * lengthPercentage * 0.5f);
        }
    }
}
