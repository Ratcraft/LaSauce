using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{

    public KeyCode punch;
    public HingeJoint hj;
    public Transform anim;
    // Start is called before the first frame update
    void Start()
    {
        hj = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim != null){
            JointSpring js = hj.spring;
            js.targetPosition = anim.localEulerAngles.x;
            if (js.targetPosition > 90)
                js.targetPosition = 0;
            js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5);

            hj.spring = js;
        }
    }
}
