using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody rb;
    public Animator Anim;
    CapsuleCollider cap;

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
        rb = GetComponent<Rigidbody>();     //Trouve les composants
        cap = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)        //Permet de sauter
        {
            rb.AddForce(new Vector3(0, JumpForce* 100, 0), ForceMode.Impulse);
            IsGround = false;

        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        horizontalRaw = Input.GetAxisRaw("Horizontal");
        verticalRaw = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(horizontal , 0, vertical);
        Vector3 inputraw = new Vector3(horizontalRaw , 0, verticalRaw);

        if (input.sqrMagnitude > 1f)
            input.Normalize();

        if (inputraw != Vector3.zero)
            targetRotation = Quaternion.LookRotation(input).eulerAngles;

        rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation.x,
            Mathf.Round(targetRotation.y / 45) * 45, targetRotation.z),Time.deltaTime * Rotationspeed);

        if (inputraw.sqrMagnitude != 0)         //Permet d'arreter ou non l'animation
            Anim.enabled = true;
        else if (inputraw.sqrMagnitude == 0)
            Anim.enabled = false;

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.relativeVelocity.magnitude> Outvalue)
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
