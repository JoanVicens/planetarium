using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{

    //var mass = 5.97237×10^24;
    private static float distanceToSun = 1; //AU
    private Vector3 distanceToSunScalator = new Vector3(distanceToSun * Planet.rescale, 0, distanceToSun * Planet.rescale);

    private Planet self;

    // Start is called before the first frame update
    void Start()
    {
        self = new Planet();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Scale(self.updatePosition(), distanceToSunScalator);
    }
}
