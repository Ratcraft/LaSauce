using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    HingeJoint hj;
    public KeyCode key;
    public HingeJoint hjcoude;
    InputManager inputManager;

    AudioSource HitSound;

    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        hj = GetComponent<HingeJoint>();
        HitSound = GetComponent<AudioSource>();
        inputManager = GameObject.FindObjectOfType<InputManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        JointSpring js = hjcoude.spring;
        if (Input.GetKey(key)/*inputManager.GetButtonDown("Hit")*/){ 
            
            go.tag = "HitZone";
            hj.useSpring = true;
            js.targetPosition = -90;
            HitSound.Play();
        }
        else{
            go.tag = "Hitbox";
            hj.useSpring = false;
            js.targetPosition = 0;
        }
        hjcoude.spring = js;
    }
}
