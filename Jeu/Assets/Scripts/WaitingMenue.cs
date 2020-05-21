using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

namespace Com.TestMulti.SimpleHostile
{
    public class WaitingMenue : MonoBehaviour
    {
        public static bool wait = true;

        public void Disable()
        {
            if(wait == false)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
