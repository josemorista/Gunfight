using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
  public float radius = 3f;
  public string type;

  public virtual void Interact()
  {

  }

  void onDrawGizmosSelected()
  {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, radius);
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
