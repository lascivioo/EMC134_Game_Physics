﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    public Vector3 vectorVelocity;
    public Vector3 netForce;
    public bool NetForceTrue;
    public List<Vector3> forceVectorList = new List<Vector3>();
    void Start()
    {

    }

    void FixedUpdate()
    {
        AddForces();
        if (netForce == Vector3.zero)
        {
            transform.position += vectorVelocity * Time.deltaTime;
            NetForceTrue = false;
        }else{
            Debug.LogError("Unbalanced Force Detected");
            NetForceTrue = true;
        }
        //transform.position += vectorVelocity * Time.deltaTime;
    }

    void AddForces()
    {
        netForce = Vector3.zero;
        foreach (Vector3 forceVector in forceVectorList)
        {
            netForce += forceVector;
        }
    }
}


