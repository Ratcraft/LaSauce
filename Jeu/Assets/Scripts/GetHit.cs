﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{

    public Damage dmgscript;
    public int Health;
    CapsuleCollider cc;
    Rigidbody rb;
    public bool Isdead = false;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0){
            Isdead = true;
            rb.freezeRotation = false;
        }
    }

    void OnTriggerEnter(Collider target){
        if (target.tag == "HitZone"){
            dmgscript = target.GetComponent<Damage>();
            Health -= dmgscript.realDamage;
        }
    }

}