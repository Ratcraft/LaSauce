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
            cameraParent.SetActive(photonView.IsMine);/*Le joueur prends uniquement le contrôle de la caméra
                                                        du player qui lui ait assigné*/
            
            baseFOV = normalCam.fieldOfView;/*Initialisation du fov de la caméra*/
            Camera.main.enabled = false;
            rig = GetComponent<Rigidbody>();
        }

        void Update()
        { /*cette fonction permet de dédinir et d'update en fonction du temps 
            tout les éléments de mouvement du player */

            if(!photonView.IsMine) return;

            //Mouvement vertical et horizontal (avancé vers la gauche ou la droite)
            float t_hmove = Input.GetAxisRaw("Horizontal");
            float t_vmove = Input.GetAxisRaw("Vertical");

            //Initialisation des touches pour le jump et le sprint
            bool jump = Input.GetKeyDown(KeyCode.Space);
            bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            bool pause = Input.GetKeyDown(KeyCode.Escape);


            //Initialisation des variables de jump, de sprint et de sol
            bool IsGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, ground);//permet de savoir si le joueur touche le sol ou non
            bool IsJumping = jump && IsGrounded;
            bool IsSprinting = sprint && t_vmove > 0 && !IsJumping && IsGrounded;
            

            //Update de la vitesse du player si il sprint ou non
            float t_adjustedSpeed = speed;
            if(IsSprinting) t_adjustedSpeed *= sprintModifier;

            //Lorsque le player jump, il va être propulsé vers le haut avec une certaine force
            if(IsJumping)
            {
                rig.AddForce(Vector3.up * JumpForce);
            }

            //Initialisation du vecteur direction (avancer, reculer)
            Vector3 t_direction = new Vector3(t_hmove, 0, t_vmove);
            t_direction.Normalize();

            //Initialisation et update du vecteur sprint
            Vector3 t_targetVelocity = transform.TransformDirection(t_direction) * t_adjustedSpeed * Time.deltaTime;
            t_targetVelocity.y = rig.velocity.y;
            rig.velocity = t_targetVelocity;

            //Si le plqyer sprint, la fov de la caméra va changer
            if(IsSprinting)
            {
                normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV * sprintFOVModifier, Time.deltaTime * 8f);
            }
            else
            {
                normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV, Time.deltaTime * 8f);
            }
            if (pause)
            {
                GameObject.Find("Pause").GetComponent<Pause>().TogglePause();
            }

            if (Pause.paused)
            {
                t_hmove = 0f;
                t_vmove = 0f;
                sprint = false;
                jump = false;
                //crouch = false;
                pause = false;
                //isGrounded = false;
                //isJumping = false;
                //isSprinting = false;
                //isCrouching = false;
            }
        }
    }
}

