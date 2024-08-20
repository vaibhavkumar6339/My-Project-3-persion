using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{
   private GameObject ExitButton;

   public void GoToHomePage( )
   {
		  SceneManager.LoadScene(0);
		   
   }
   public void ToExitGame()
   {
		  Application.Quit();
		  
   }
}
