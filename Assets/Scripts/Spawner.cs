using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //This is a Singleton of the BoidSpawner. there is only one instance 
    // of BoidSpawner, so we can store it in a static variable named s.
    static public Spawner       S;
    static public List<Boid>    boids;

    // These fields allow you to adjust the spawning behavior of the boids
    [Header("Set in Inspector: Spawning")]
    public GameObject           boidPrefab;
    public Transform            boidAnchor;
    public int                  numBoids = 100;
    public float                spawnRadius = 100f;
    public float                spawnDelay = 0.1f;

    // These fields allow you to adjust the flocking behavior of the boids
    [Header("Set in Inspector: Boids")]
    public float                velocity = 30f;
    public float                neighborDist = 30f;
    public float                collDist = 4f;
    public float                velMatching = 0.25f;
    public float                flockCentering = 0.2f;
    public float                collAvoid = 2f;
    public float                attractPull = 2f;
    public float                attractPush = 2f;
    public float                attractPushDist = 5f;

    // Additional fields for spawning in ploids and divoids (part 3)
    [Header("Set in Inspector: Ploids and Divoids")]
    public GameObject           ploidPrefab;
    public GameObject           divoidPrefab;
    public int                  numPloids = 2;
    public int                  numDivoids = 3;
    
    // Some variables to use for the formation of the boids (part 1)
    public float                boidTargetHeight = 2f;
    public float                ploidTargetHeight = 5f;
    public float                divoidTargetHeight = -2f;
    
    void Awake()
    {
        //Set the Singleton S to be this instance of BoidSpawner
        S = this;
        //Start instantiation of the Boids
        boids = new List<Boid>();
        InstantiateBoid();
    }

    public void InstantiateBoid()
    {
        if (boids.Count < numBoids)
        {
            GameObject go = Instantiate(boidPrefab);
            Boid b = go.GetComponent<Boid>();
            b.transform.SetParent(boidAnchor);
            boids.Add(b);
            Invoke("InstantiateBoid", spawnDelay);
        }
        // additional code for spawning in ploids and divoids after all boids are spawned
        // TODO: separate boids, ploids, and divoids when they get unique behaviors
        else if (boids.Count < numBoids + numPloids)
        {
            GameObject go = Instantiate(ploidPrefab);
            Boid p = go.GetComponent<Boid>();
            p.transform.SetParent(boidAnchor);
            boids.Add(p);
            Invoke("InstantiateBoid", spawnDelay);
        }
        else if (boids.Count < numBoids + numPloids + numDivoids)
        {
            GameObject go = Instantiate(divoidPrefab);
            Boid d = go.GetComponent<Boid>();
            d.transform.SetParent(boidAnchor);
            boids.Add(d);
            Invoke("InstantiateBoid", spawnDelay);
        }
    }
}