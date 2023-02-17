using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script rotates the divoid propellor on the back using kinematics (part 4).
public class DivoidPropellor : MonoBehaviour
{
    public float propAngle; // z rotation of propellor object
    public Vector3 propAxis; // forward axis of divoid
    public Quaternion propQuaternion;
    public float propSpeed = 1.0f;
    public GameObject propellor;
    
    // set up variables to use later
    void Start()
    {
        propAngle = 0.0f;

        // navigate to main divoid parent to get axis (this didn't work)
        // GameObject propBase = transform.parent.gameObject;
        // GameObject divoidBase = propBase.transform.parent.gameObject;
        // GameObject divoid = divoidBase.transform.parent.gameObject;
        // propAxis = divoid.transform.forward;

        // use forward (z direction) as axis
        propAxis = Vector3.forward;

        // set propellor location to initial state using quaternion
        propQuaternion = Quaternion.AngleAxis(propAngle, propAxis);
        propellor.transform.localRotation = propQuaternion;
    }

    // spin the propellor kinematically over time
    void Update()
    {
        propAngle += propSpeed;
        propQuaternion = Quaternion.AngleAxis(propAngle, propAxis);
        propellor.transform.localRotation = propQuaternion;
    }
}
