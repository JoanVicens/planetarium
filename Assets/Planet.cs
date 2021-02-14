using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public static float rescale = 30f;
    private Vector3 distanceToSunScalator;

    public string name;
    public float distanceToSun; //in AU

    private double x;
    private double y;

    private double xVelocity;
    private double yVelocity;

    public Vector3 updatePosition()
    {
        double radius = Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2));

        double newXVelocity = this.xVelocity - (4 * Math.Pow(Math.PI, 2) * this.x * SolarSystemOptions.dt) / (Math.Pow(radius, 3));
        double newYVelocity = this.yVelocity - (4 * Math.Pow(Math.PI, 2) * this.y * SolarSystemOptions.dt) / (Math.Pow(radius, 3));

        double newX = this.x + newXVelocity * SolarSystemOptions.dt;
        double newY = this.y + newYVelocity * SolarSystemOptions.dt;

        this.xVelocity = newXVelocity;
        this.yVelocity = newYVelocity;

        this.x = newX;
        this.y = newY;

        return new Vector3((float) newX, 0, (float) newY);
    }

    void Start()
    {
        distanceToSunScalator = new Vector3(distanceToSun * Planet.rescale, 0, distanceToSun * Planet.rescale);

        this.x = 1d;
        this.y = 0d;

        this.xVelocity = 0d;
        this.yVelocity = 4d;
    }

    void Update()
    {
        transform.position = Vector3.Scale(this.updatePosition(), distanceToSunScalator);
    }
}
