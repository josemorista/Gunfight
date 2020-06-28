using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGun : Interactable
{
  // Start is called before the first frame update

  public override void Interact()
  {
    base.Interact();
    Destroy(gameObject);
  }

  void OnCollisionEnter(Collision collision)
  {
    collision.transform.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
  }

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
