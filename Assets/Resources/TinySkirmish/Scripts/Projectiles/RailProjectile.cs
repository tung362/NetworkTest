﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class RailProjectile : NetworkBehaviour
{
    //Direction of the projectile
    public Vector3 Direction = new Vector3(0, 0, 1);
    public float Speed = 1000;

    private Rigidbody TheRigidbody;

    void Start()
    {
        TheRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!isServer) return;
        transform.LookAt(transform.position + Direction);

        TheRigidbody.velocity = Direction * Speed * Time.fixedDeltaTime;
    }
}
