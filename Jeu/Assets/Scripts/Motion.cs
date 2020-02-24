using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.TestMulti.SimpleHostile
{
    

    public class Motion : MonoBehaviourPunCallbacks
    {
        public float speed;
        public float sprintModifier;
        public float JumpForce;
        public Camera normalCam;
        public GameObject cameraParent;
        public Transform groundDetector;
        public LayerMask ground;
        
        private Rigidbody rig;
        private float baseFOV;
        private float sprintFOVModifier = 1.25f;

        void Start()
        {
            cameraParent.SetActive(photonView.IsMine);
            
            baseFOV = normalCam.fieldOfView;
            Camera.main.enabled = false;
            rig = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if(!photonView.IsMine) return;

            float t_hmove = Input.GetAxisRaw("Horizontal");
            float t_vmove = Input.GetAxisRaw("Vertical");

            bool jump = Input.GetKeyDown(KeyCode.Space);
            bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            bool IsGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, ground);
            bool IsJumping = jump && IsGrounded;
            bool IsSprinting = sprint && t_vmove > 0 && !IsJumping && IsGrounded;
            

            
            float t_adjustedSpeed = speed;
            if(IsSprinting) t_adjustedSpeed *= sprintModifier;

            
            if(IsJumping)
            {
                rig.AddForce(Vector3.up * JumpForce);
            }

            Vector3 t_direction = new Vector3(t_hmove, 0, t_vmove);
            t_direction.Normalize();

            Vector3 t_targetVelocity = transform.TransformDirection(t_direction) * t_adjustedSpeed * Time.deltaTime;
            t_targetVelocity.y = rig.velocity.y;
            rig.velocity = t_targetVelocity;

            if(IsSprinting)
            {
                normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV * sprintFOVModifier, Time.deltaTime * 8f);
            }
            else
            {
                normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV, Time.deltaTime * 8f);
            }
        }
    }
}

