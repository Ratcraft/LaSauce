using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.TestMulti.SimpleHostile
{
    public class Manager : MonoBehaviourPunCallbacks
    {
        public string Player;
       
        public Transform spawn_point;

        private void Start()
        {
            Spawn();
        }

        public void Spawn ()
        {
            PhotonNetwork.Instantiate(Player, spawn_point.position, spawn_point.rotation);
            
        }
    }
}
