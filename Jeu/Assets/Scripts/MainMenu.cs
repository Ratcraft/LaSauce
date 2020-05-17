using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.TestMulti.SimpleHostile
{
    public class MainMenu : MonoBehaviour
    {
        public Launcher launcher;

        public static int number;
        
        
        private void Start()
        {
            //WaitingMenue.wait = true;
            Pause.paused = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        
        }

        /*public void Set1(int x)
        {
            x = 1;
        }
         public void Set2(int x)
        {
            x = 2;
        }
         public void Set3(int x)
        {
            x = 3;
        }
         public void Set4(int x)
        {
            x = 4;
        }*/

        public void JoinMatch1()
        {
            MainMenu.number = 1;
            launcher.Join();
        }
        public void JoinMatch2()
        {
            MainMenu.number = 2;
            launcher.Join();
        }
        public void JoinMatch3()
        {
            MainMenu.number = 3;
            launcher.Join();
        }
        public void JoinMatch4()
        {
            MainMenu.number = 4;
            launcher.Join();
        }
        /*public void JoinMatch5()
        {
            MainMenu.number = 5;
            launcher.Join();
        }*/
        
        public void JoinSolo()
        {
            SceneManager.LoadScene("Solo");
        }

        public void CreateMatch()
        {
            launcher.Create();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
