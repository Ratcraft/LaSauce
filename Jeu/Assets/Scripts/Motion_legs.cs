using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


namespace Com.TestMulti.SimpleHostil
{
    public class Motion_legs : MonoBehaviourPunCallbacks
    {

        private HingeJoint Hj;
        public Transform Myanim;
        public bool Invert;

        // Start is called before the first frame update
        void Start()
        {
            Hj = GetComponent<HingeJoint>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Myanim != null)
            {
                JointSpring js = Hj.spring;
                js.targetPosition = Myanim.localEulerAngles.x;      //Calcule l'angle de rotation des jambes
                if (js.targetPosition > 180)
                    js.targetPosition = js.targetPosition - 360;

                js.targetPosition = Mathf.Clamp(js.targetPosition, Hj.limits.min + 5, Hj.limits.max - 5);


                if (Invert)     //Permet d'inverser l'une des jambes
                {
                    js.targetPosition = js.targetPosition *= -1;
                }

                Hj.spring = js;
            }
        }
    }
}
