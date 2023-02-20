using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // obstacle class, simply has output on approach
    void OnTriggerEnter(Collider other) {
        // Debug.Log("Boid his entered the obstacle avoid box");
    }

    void OnTriggerExit(Collider other) {
        // Debug.Log("Boid his exited the obstacle avoid box");
    }
}
