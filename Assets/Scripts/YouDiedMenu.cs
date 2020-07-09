using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDiedMenu : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    Cursor.lockState = CursorLockMode.None;
  }
  public void Retry()
  {
    SceneManager.LoadScene(1);
  }

  public void Menu()
  {
    SceneManager.LoadScene(0);
  }
}
