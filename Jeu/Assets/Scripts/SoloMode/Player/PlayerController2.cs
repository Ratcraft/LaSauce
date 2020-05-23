using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


namespace Com.TestMulti.SimpleHostile
{
    public class PlayerController2 : MonoBehaviourPunCallbacks
    {
        Rigidbody rb;
        public Animator Anim;
        CapsuleCollider cap;

        PhotonView pv;
        GetHit getHitscript;
        AudioSource JumpSound;
        InputManager inputManager;

        float vertical;
        float horizontal;
        float verticalRaw;
        float horizontalRaw;
        Vector3 targetRotation;
        public float Rotationspeed = 10;
        public float Speed = 100;

        public float JumpForce = 7;
        bool IsGround = true;

        

        public float Outvalue = 10;

        void Start()
        {
            pv = GetComponentInParent<PhotonView>();
            rb = GetComponent<Rigidbody>();     //Trouve les composants
            cap = GetComponent<CapsuleCollider>();
            getHitscript = GetComponent<GetHit>();
            JumpSound = GetComponent<AudioSource>();
            inputManager = GameObject.FindObjectOfType<InputManager>();
        }

        void Update()
        {
            //if (!pv.IsMine) return;
            bool pause = Input.GetKeyDown(KeyCode.Escape);
            
            if (inputManager.GetButtonDown("Jump") && IsGround && !getHitscript.Isdead)       //Permet de sauter
            {
                JumpSound.Play();
                rb.AddForce(new Vector3(0, JumpForce * 100, 0), ForceMode.Impulse);
                IsGround = false;
            }
            if (pause)
            {
                GameObject.Find("Pause").GetComponent<Pause>().TogglePause();
            }

            if (Pause.paused)
            {
                horizontal = 0f;
                horizontal = 0f;
                horizontalRaw = 0f;
                verticalRaw = 0f;
                pause = false;
                
            }
            
        }

        void FixedUpdate()
        {
            //if (!pv.IsMine) return;
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            horizontalRaw = Input.GetAxisRaw("Horizontal");
            verticalRaw = Input.GetAxisRaw("Vertical");


            Vector3 input = new Vector3(horizontal, 0, vertical);
            Vector3 inputraw = new Vector3(horizontalRaw, 0, verticalRaw);

            if (input.sqrMagnitude > 1f)
                input.Normalize();

            if (inputraw != Vector3.zero)
                targetRotation = Quaternion.LookRotation(input).eulerAngles;

            rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation.x,
                Mathf.Round(targetRotation.y / 45) * 45, targetRotation.z), Time.deltaTime * Rotationspeed);

            if (inputraw.sqrMagnitude != 0)         //Permet d'arreter ou non l'animation
                Anim.enabled = true;
            else if (inputraw.sqrMagnitude == 0)
                Anim.enabled = false;
            if (Pause.paused)
            {
                horizontal = 0f;
                horizontal = 0f;
                horizontalRaw = 0f;
                verticalRaw = 0f;
             

            }
            
        }

        void OnCollisionEnter(Collision other)
        {
            if (other.relativeVelocity.magnitude > Outvalue)
            {
                StartCoroutine(Out());
            }

            if (other.gameObject.CompareTag("Plane"))       //Verifie si le personnage est sur le sol
                IsGround = true;
        }

        IEnumerator Out()
        {
            rb.constraints = RigidbodyConstraints.None;
            cap.enabled = false;
            yield return new WaitForSeconds(2);         //Remet le personnage en place 
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            cap.enabled = true;
        }
    }
}
