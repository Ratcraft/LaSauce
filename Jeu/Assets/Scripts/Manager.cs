using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.TestMulti.SimpleHostile
{
    public class Manager : MonoBehaviourPunCallbacks
    {
        public string player_prefab;
        //public GameObject player_prefab;
        public Transform spawn_point;

        private void Start()
        {
            Spawn();
        }

        public void Spawn ()
        {
            PhotonNetwork.Instantiate(player_prefab, spawn_point.position, spawn_point.rotation);
            //Transform t_spawn = spawn_points[Random.Range(0, spawn_points.Length)];

            //if (PhotonNetwork.IsConnected)
            //{
           
            //}

            /*else
            {
                Debug.Log("WORKING");
                GameObject newPlayer = Instantiate(player_prefab, t_spawn.position, t_spawn.rotation) as GameObject;
            }*/
        }
    }
}
