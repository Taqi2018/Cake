using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

     public void PlayGame()
     {
          int SceneNumber = Random.Range(1, 3);
          SceneManager.LoadScene(SceneNumber);
     }

     public void QuitGame()
     {
          #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
          #endif
          Application.Quit();
     }

     public void PlayAgain()
     {
          SceneManager.LoadScene(0);
     }
}
