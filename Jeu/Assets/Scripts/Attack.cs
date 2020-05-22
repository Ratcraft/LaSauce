using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    HingeJoint hj;
    public KeyCode key;
    public HingeJoint hjcoude;

    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        hj = GetComponent<HingeJoint>();
        
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring js = hjcoude.spring;
        if (Input.GetKey(key)){ 
            go.tag = "HitZone";
            hj.useSpring = true;
            js.targetPosition = -90;
        }
        else{
            go.tag = "Hitbox";
            hj.useSpring = false;
            js.targetPosition = 0;
        }
        hjcoude.spring = js;
    }
}
