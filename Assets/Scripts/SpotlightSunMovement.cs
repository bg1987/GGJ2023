using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpotlightSunMovement : MonoBehaviour
{
    public float moveTime = 10f;
    public Transform[] waypoints;
    // Start is called before the first frame update
    void Start()
    {
        var path = new LTBezierPath(ToVectors(waypoints));
        LeanTween.move(gameObject, path, moveTime).setLoopType(LeanTweenType.pingPong);
    }

    void OnDrawGizmos()
    {
        if (waypoints != null && waypoints.Length > 0)
        {
            var path = new LTBezierPath(ToVectors(waypoints));
            path.gizmoDraw();
        }
    }

    private Vector3[] ToVectors(Transform[] transforms)
    {
        var res = new Vector3[transforms.Length];
        for (int i = 0; i < transforms.Length; i++)
        {
            res[i] = transforms[i].position;
        }
        return res;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
