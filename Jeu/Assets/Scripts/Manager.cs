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
        public Transform spawn_point2;
        public Transform spawn_point3;
        public Transform spawn_point4;
         public Transform spawn_point5;

        public List<Transform> position = new List<Transform> ();

       
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
            int res = UnityEngine.Random.Range(0,3);
            if(res == 0)
            {
                PhotonNetwork.Instantiate(Player1, spawn_point.position, spawn_point.rotation);
            }
            if(res == 1)
            {
                PhotonNetwork.Instantiate(Player1, spawn_point2.position, spawn_point.rotation);
            }
            if(res == 2)
            {
                PhotonNetwork.Instantiate(Player1, spawn_point3.position, spawn_point.rotation);
            }
            if(res == 3)
            {
                PhotonNetwork.Instantiate(Player1, spawn_point4.position, spawn_point.rotation);
            }
            
            
            /*if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                WaitingMenue.wait = false;
                PhotonNetwork.Instantiate(Player2, spawn_point.position, spawn_point.rotation);
                GameObject.Find("Waiting").GetComponent<WaitingMenue>().Disable();
                
            }
            else
            {
                 WaitingMenue.wait = true;
                 PhotonNetwork.Instantiate(Player2, spawn_point.position, spawn_point.rotation);
                GameObject.Find("Waiting").GetComponent<WaitingMenue>().Disable();
            }*/
            
            
            
        }
        public void Spawn2 ()
        {
            int res2 = UnityEngine.Random.Range(0,3);
            if(res2 == 0)
            {
                PhotonNetwork.Instantiate(Player2, spawn_point.position, spawn_point.rotation);
            }
            if(res2 == 1)
            {
                PhotonNetwork.Instantiate(Player2, spawn_point2.position, spawn_point.rotation);
            }
            if(res2 == 2)
            {
                PhotonNetwork.Instantiate(Player2, spawn_point3.position, spawn_point.rotation);
            }
            if(res2 == 3)
            {
                PhotonNetwork.Instantiate(Player2, spawn_point4.position, spawn_point.rotation);
            }
            //PhotonNetwork.Instantiate(Player2, spawn_point.position, spawn_point.rotation);
            /*if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                WaitingMenue.wait = false;
                PhotonNetwork.Instantiate(Player1, spawn_point.position, spawn_point.rotation);
                GameObject.Find("Waiting").GetComponent<WaitingMenue>().Disable();
                
            }
            else
            {
                 WaitingMenue.wait = true;
            }*/
            
        }
        public void Spawn3 ()
        {
            int res3 = UnityEngine.Random.Range(0,3);
            if(res3 == 0)
            {
                PhotonNetwork.Instantiate(Player3, spawn_point.position, spawn_point.rotation);
            }
            if(res3 == 1)
            {
                PhotonNetwork.Instantiate(Player3, spawn_point2.position, spawn_point.rotation);
            }
            if(res3 == 2)
            {
                PhotonNetwork.Instantiate(Player3, spawn_point3.position, spawn_point.rotation);
            }
            if(res3 == 3)
            {
                PhotonNetwork.Instantiate(Player3, spawn_point4.position, spawn_point.rotation);
            }
            //PhotonNetwork.Instantiate(Player3, spawn_point.position, spawn_point.rotation);
            /*if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                WaitingMenue.wait = false;
                PhotonNetwork.Instantiate(Player3, spawn_point.position, spawn_point.rotation);
                GameObject.Find("Waiting").GetComponent<WaitingMenue>().Disable();
                
            }
            else
            {   
                 WaitingMenue.wait = true;
            }*/
            
        }
        public void Spawn4 ()
        {
            int res4 = UnityEngine.Random.Range(0,3);
            if(res4 == 0)
            {
                PhotonNetwork.Instantiate(Player4, spawn_point.position, spawn_point.rotation);
            }
            if(res4 == 1)
            {
                PhotonNetwork.Instantiate(Player4, spawn_point2.position, spawn_point.rotation);
            }
            if(res4 == 2)
            {
                PhotonNetwork.Instantiate(Player4, spawn_point3.position, spawn_point.rotation);
            }
            if(res4 == 3)
            {
                PhotonNetwork.Instantiate(Player4, spawn_point4.position, spawn_point.rotation);
            }
            //PhotonNetwork.Instantiate(Player4, spawn_point.position, spawn_point.rotation);
            /*if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                WaitingMenue.wait = false;
                PhotonNetwork.Instantiate(Player4, spawn_point.position, spawn_point.rotation);
                GameObject.Find("Waiting").GetComponent<WaitingMenue>().Disable();
                
            }
            else
            {
                 WaitingMenue.wait = true;
            }*/
            

        }
        
    }
}
