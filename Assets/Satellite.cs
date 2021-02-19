using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{

    private GameObject planet;

    public string name;
    //public float distanceToPlanet; //in AU

    private Vector3 position;

    private Vector3 desiredPosition;
    private Transform center;
     public float orbitRadius = 10.0f;
     public float orbitDegreesPerSec = 180.0f;

    void Start()
    {
        planet = transform.parent.gameObject;
        //this.position = new Vector3(distanceToPlanet, 0, 0);
    }

    void Update() {}

    void LateUpdate()
    {
        transform.position = planet.transform.position + (transform.position - planet.transform.position).normalized * orbitRadius;
        transform.RotateAround(planet.transform.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
    }
}
