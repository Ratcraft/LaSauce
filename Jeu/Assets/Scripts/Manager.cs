using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.TestMulti.SimpleHostile
{
    public class Manager : MonoBehaviourPunCallbacks
    {
        public string Player1;
        public string Player2;
        public string Player3;
        public string Player4;
        //public string Player5;

        public MainMenu mainMenu;
        public Transform spawn_point;

        private void Start()
        {
            if(MainMenu.number == 1)
            {
                Spawn1();
            }
            if(MainMenu.number == 2)
            {
                Spawn2();
            }
            if(MainMenu.number == 3)
            {
                Spawn3();
            }
            if(MainMenu.number == 4)
            {
                Spawn4();
            }
            /*if(MainMenu.number == 5)
            {
                Spawn5();
            }*/
            
        }

        public void Spawn1 ()
        {
            PhotonNetwork.Instantiate(Player2, spawn_point.position, spawn_point.rotation);
            
        }
        public void Spawn2 ()
        {
            PhotonNetwork.Instantiate(Player1, spawn_point.position, spawn_point.rotation);
            
        }
        public void Spawn3 ()
        {
            PhotonNetwork.Instantiate(Player3, spawn_point.position, spawn_point.rotation);
            
        }
        public void Spawn4 ()
        {
            PhotonNetwork.Instantiate(Player4, spawn_point.position, spawn_point.rotation);
            
        }
        /*public void Spawn5 ()
        {
            PhotonNetwork.Instantiate(Player5, spawn_point.position, spawn_point.rotation);
            
        }*/
        
    }
}
