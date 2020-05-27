﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public KeyCode GrabInput;
    public GameObject MyGrabObj;
    public bool IsGrab = false;
    InputManager inputManager;

    Rigidbody Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        inputManager = GameObject.FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyGrabObj != null)
        {
            if (inputManager.GetButtonDown("Grab")/*Input.GetKey(GrabInput)*/)
            {
                if (!IsGrab)
                {
                    FixedJoint Fj = MyGrabObj.AddComponent<FixedJoint>();
                    Fj.connectedBody = Rb;
                    Fj.breakForce = 8000;
                    IsGrab = true;
                    MyGrabObj.tag = "HitZone";
                }
            }
            else if (inputManager.GetButtonDown("Grab")/*Input.GetKeyUp(GrabInput)*/)
            {
                if (MyGrabObj.CompareTag("Item"))
                {
                    Destroy(MyGrabObj.GetComponent<FixedJoint>());
                }
                MyGrabObj.tag = "Item";
                MyGrabObj = null;
                IsGrab = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            MyGrabObj = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            MyGrabObj = null;
        }
    }
}
