using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

namespace Com.TestMulti.SimpleHostile
{
public class PauseSolo : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if(isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DesactivateMenu();
        }
    }

    public void ActivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
    }

   public void DesactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

}
}
