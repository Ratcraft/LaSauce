using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloPlayerMovement : MonoBehaviour
{
   
    public float Speed;

    
   void Update()
   {
       PlayerMovement();
   }
   
   
   void PlayerMovement()
   {
       //Initialisation des variabe de mouvment horizontale et verticale
       float hor = Input.GetAxis("Horizontal");
       float ver = Input.GetAxis("Vertical");

       //Initialisation et update du vecteur mouvement du player
       Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
       transform.Translate(playerMovement, Space.Self);
        
   }
}
