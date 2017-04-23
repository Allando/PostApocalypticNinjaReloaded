using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breadScript : MonoBehaviour
{

    public Transform head;
    public Transform[] segments;
    List<Vector3> breadcrumbs;

    Vector3 prevHeadPosition;
    float headDisplacement;
    public float segmentSpacing; //set controls the spacing between the segments,which is always constant.

    void Start()
    {
        //populate the first set of crumbs by the initial positions of the segments.
        breadcrumbs = new List<Vector3>();
        breadcrumbs.Add(head.position); //add head first, because that's where the segments will be going.
        for (int i = 0; i < segments.Length - 1; i++) // we don't want to the last segment to have a crumb.
            breadcrumbs.Add(segments[i].position);
        prevHeadPosition = head.position;
    }

    void Update()
    {

        Vector3 headMovement = head.position - prevHeadPosition;
        float headMovementMagnitude = headMovement.magnitude;
        headDisplacement += headMovementMagnitude;

        if (headDisplacement >= segmentSpacing)
        {
            breadcrumbs.RemoveAt(breadcrumbs.Count - 1); //remove the last breadcrumb
            breadcrumbs.Insert(0, head.position); // add a new one where head is.
            headDisplacement = 0;
        }
        if (headMovementMagnitude > 0)
        {
            Vector3 slerped;
            slerped = Vector3.Slerp(breadcrumbs[0], head.position, headDisplacement / segmentSpacing);
            //do the first segment outside the loop because it needs head.position instead of next breadcrumb for interpolation
            if ((breadcrumbs[0] - segments[0].position).sqrMagnitude > 0.01)
            {
                slerped = Vector3.Slerp(breadcrumbs[0], head.position, headDisplacement / segmentSpacing);
                segments[0].position += headMovementMagnitude * (slerped - segments[0].position).normalized;
                segments[0].LookAt(slerped);
            }
            for (int i = 1; i < segments.Length; i++)
            {
                if ((breadcrumbs[i] - segments[i].position).sqrMagnitude > 0.01)
                {
                    slerped = Vector3.Slerp(breadcrumbs[i], breadcrumbs[i - 1], headDisplacement / segmentSpacing);
                    segments[i].position += headMovementMagnitude * (slerped - segments[i].position).normalized;
                    segments[i].LookAt(slerped);
                }
            }
            prevHeadPosition = head.position;
        }
    }
}
