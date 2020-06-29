using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGun : Interactable
{
  // Start is called before the first frame update
  Rigidbody myrigbody;

  public float lethalSpeed = 1.0f;
  public override void Interact()
  {
    base.Interact();
    Destroy(gameObject);
  }

  void OnCollisionEnter(Collision collision)
  {
    if (myrigbody.velocity.magnitude > lethalSpeed)
    {
      collision.transform.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
    }
  }

  void Start()
  {
    myrigbody = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {

  }
}
