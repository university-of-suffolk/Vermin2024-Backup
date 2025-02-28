using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    private bool Released;
    public float detectionDistance = 10f;
    public float detectionAngle = 45f;
    public LayerMask detectionLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Released == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance, detectionLayer))
            {
                // Check if the hit object is within the detection angle
                Vector3 directionToTarget = hit.point - transform.position;
                float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);
                if (angleToTarget <= detectionAngle / 2f)
                {
                   Vector3 DogPos = transform.position;
                   Vector3 birdPos = hit.transform.position;
                   Vector3 direction = birdPos - DogPos;
                   Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                   transform.rotation = targetRotation;

                }
            }
        }
    }

    public void ReleaseDog()
    {
        Released = true;
    }

}

