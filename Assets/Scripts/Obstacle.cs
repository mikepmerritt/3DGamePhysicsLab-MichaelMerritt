using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector3 startPoint; // starting point, used to move with slider

    void Start()
    {
        startPoint = transform.position;
    }

    // obstacle class, simply has output on approach
    void OnTriggerEnter(Collider other) {
        // Debug.Log("Boid his entered the obstacle avoid box");
    }

    void OnTriggerExit(Collider other) {
        // Debug.Log("Boid his exited the obstacle avoid box");
    }

    // code for UI buttons
    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void MoveObstacleOnAxis(float sliderValue)
    {
        transform.position = startPoint + new Vector3(sliderValue, 0, -sliderValue);
    }
}
