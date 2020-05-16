using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.TestMulti.SimpleHostile
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
    
        public void Awake()
        {
            /*La fonction Connect va se lancer pour essayer de connecter le joueur au serveur*/
            PhotonNetwork.AutomaticallySyncScene = true;
            Connect();
        }

        public override void OnConnectedToMaster()
        {
            /* lOrsque le joueur est connecté au serveur, la fonction Join va se lancer*/
            Debug.Log("CONNECTED");
            

            base.OnConnectedToMaster();
        }

        public override void OnJoinedRoom()
        {
            /* Lorsque le joueur a join une Room, la fonction StartGame va se lancer*/
            StartGame();

            base.OnJoinedRoom();
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            /*Si auacune Room n'est présente sur le serveur, le Join va fail
             et le script va lancer la fonction Create*/ 

            Create();

            base.OnJoinRandomFailed(returnCode, message);
        }

       public void Connect()
       {
           /*Le serveur va connecté le joueur sur la version indiquée du jeu*/
           Debug.Log("Trying to Connect...");
           PhotonNetwork.GameVersion = "0.0.0";
           PhotonNetwork.ConnectUsingSettings();
       }

       public void Join()
       {
           /*Le serveur va essayer de connecter le joueur à une Room*/
           PhotonNetwork.JoinRandomRoom();
       }
       
       public void Create()
       {
            //création d'une nouvelle Room
            PhotonNetwork.CreateRoom("");
       }

       public void StartGame()
       {
           /*Si un joueur est déjà connecté sur le level 3 alors le nouveau 
            joueur va être connecté sur le même level*/
           if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
           {
               PhotonNetwork.LoadLevel(1);
               
           }
       }
       
    }
}
