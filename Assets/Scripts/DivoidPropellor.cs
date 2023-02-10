using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivoidPropellor : MonoBehaviour
{
    public float propAngle; // z rotation of propellor object
    public Vector3 propAxis; // forward axis of divoid
    public Quaternion propQuaternion;
    public float propSpeed = 1.0f;
    
    // set up variables to use later
    void Start()
    {
        propAngle = 0.0f;
        // navigate to main divoid parent to get axis
        GameObject propBase = transform.parent.gameObject;
        GameObject divoidBase = propBase.transform.parent.gameObject;
        GameObject divoid = divoidBase.transform.parent.gameObject;
        propAxis = divoid.transform.forward;
        // set propellor location to initial state using quaternion
        propQuaternion = Quaternion.AngleAxis(propAngle, propAxis);
        transform.rotation = propQuaternion;
    }

    // spin the propellor gradually
    void Update()
    {
        propAngle += propSpeed;
        propQuaternion = Quaternion.AngleAxis(propAngle, propAxis);
        transform.rotation = propQuaternion;
    }
}