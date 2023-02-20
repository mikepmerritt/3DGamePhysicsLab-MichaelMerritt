using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [Header("Set in Inspector and Ingame: Formation Mode")]
    public bool formationToggle = true; // true is following in a line, false is clustering based on the leader
    [Header("Set in Inspector: Button Text")]
    public TMP_Text buttonText;
    
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
        GameObject go;
        if (boids.Count < numBoids)
        {
            go = Instantiate(boidPrefab);
            Boid b = go.GetComponent<Boid>();
            b.transform.SetParent(boidAnchor);
            boids.Add(b);
            Invoke("InstantiateBoid", spawnDelay);
        }
        // additional code for spawning in ploids and divoids after all boids are spawned (part 3)
        else if (boids.Count < numBoids + numPloids)
        {
            go = Instantiate(ploidPrefab);
            Boid p = go.GetComponent<Boid>();
            p.transform.SetParent(boidAnchor);
            boids.Add(p);
            Invoke("InstantiateBoid", spawnDelay);
        }
        else if (boids.Count < numBoids + numPloids + numDivoids)
        {
            go = Instantiate(divoidPrefab);
            Boid d = go.GetComponent<Boid>();
            d.transform.SetParent(boidAnchor);
            boids.Add(d);
            Invoke("InstantiateBoid", spawnDelay);
        }

        // designate the first one spawned as the leader so the others can steal its velocity (part 1)
        if(boids.Count == 1) {
            boids[0].isLeader = true;
        }

        // give each boid a number as it is spawned
        boids[boids.Count - 1].number = boids.Count - 1;
    }

    // these functions are for the UI buttons
    public void CreateExtraBoid() 
    {
        GameObject go = Instantiate(boidPrefab);
        Boid b = go.GetComponent<Boid>();
        b.transform.SetParent(boidAnchor);
        boids.Add(b);
        boids[boids.Count - 1].number = boids.Count - 1;
    }

    public void CreateExtraPloid() 
    {
        GameObject go = Instantiate(ploidPrefab);
        Boid p = go.GetComponent<Boid>();
        p.transform.SetParent(boidAnchor);
        boids.Add(p);
        boids[boids.Count - 1].number = boids.Count - 1;
    }

    public void CreateExtraDivoid() 
    {
        GameObject go = Instantiate(divoidPrefab);
        Boid d = go.GetComponent<Boid>();
        d.transform.SetParent(boidAnchor);
        boids.Add(d);
        boids[boids.Count - 1].number = boids.Count - 1;
    }

    public void ToggleFormationType()
    {
        formationToggle = !formationToggle;
        if(formationToggle)
        {
            buttonText.text = "Formation: Lines";
        }
        else
        {
            buttonText.text = "Formation: Cluster";
        }
    }

}