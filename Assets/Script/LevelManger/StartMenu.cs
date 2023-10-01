using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string LevelBeta1;
   public void PlayGame()
    { 
        SceneManager.LoadScene(LevelBeta1);
    }
   
}
