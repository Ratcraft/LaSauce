using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MainMenu : MonoBehaviourPunCallbacks
{
    private bool test = false;
    // Start is called before the first frame update
    

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();    
    }
    
    public void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Connect();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("CONNECTED");
        Join();

        base.OnConnectedToMaster();
    }

    public override void OnJoinedRoom()
    {
        StartGame();

        base.OnJoinedRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Create();

        base.OnJoinRandomFailed(returnCode, message);
    }

    public void Connect()
    {
        Debug.Log("Trying to Connect...");
        PhotonNetwork.GameVersion = "0.0.0";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Join()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void Create()
    {
        PhotonNetwork.CreateRoom("");
    }

    public void StartGame()
    {
        if (test)
        {
            PhotonNetwork.LoadLevel(1);
        }
    }
    public void PlayGameSolo()
    {
        SceneManager.LoadScene(2);
    }
    
    public void PlayGameMulti()
    {
        Awake();
        OnConnectedToMaster();
        OnJoinedRoom();
        Connect();
        Join();
        Create();
        test = true;
        StartGame();
    }
       
}

