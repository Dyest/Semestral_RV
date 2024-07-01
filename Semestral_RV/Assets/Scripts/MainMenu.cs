using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   private void Start()
   {
       ResetPlayerPrefs();
   }
   public void PlayGame()
   {
        SceneManager.LoadScene(1);
   }

   public void QuitGame()
   {
    Application.Quit();
   }

   public void mainMenu()
   {
        SceneManager.LoadScene(0);
   }

   private void ResetPlayerPrefs()
   {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
   }
}
