using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
  public void Play()
  {
    Debug.Log("Loading Scene!");
    SceneManager.LoadScene(1);
  }

  public void Quit()
  {
    Application.Quit();
  }
}
