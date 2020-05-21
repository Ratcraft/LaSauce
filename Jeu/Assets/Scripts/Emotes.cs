using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotes : MonoBehaviour
{

    public KeyCode Emote1; //Leve les bras
    public KeyCode Emote2; //T-pose
    Rigidbody rb;
    public Rigidbody reference;
    public bool Invert;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Emote1))
            rb.AddForce(0, 180, 0);
        if (Input.GetKey(Emote2)){
            if (Invert)
                rb.AddForce(-180,0,0);
            else
                rb.AddForce(180,0,0);
        }
        if (Input.GetKey("r"))
            rb.AddForce(0,75,-150);
    }
}
