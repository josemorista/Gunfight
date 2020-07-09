using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : Interactable
{
  public override void Interact()
  {
    SceneManager.LoadScene(3);
  }
}