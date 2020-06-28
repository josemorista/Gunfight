using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
  public int maxWeapons = 2;
  public float interactRange = 3f;
  public Transform cameraTransform;
  public GameObject AssaultGunTemplate;

  public int selectedWeapon = 0;
  void selectWeapon()
  {
    int i = 0;
    foreach (Transform weapon in transform)
    {
      if (i == selectedWeapon)
      {
        weapon.gameObject.SetActive(true);
      }
      else
      {
        weapon.gameObject.SetActive(false);
      }
      i++;
    }
  }

  public void InstantiateNewRifle()
  {
    GameObject newWeapon = Instantiate(AssaultGunTemplate, this.transform.position, this.transform.rotation);
    newWeapon.transform.parent = this.transform;
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Interact"))
    {
      RaycastHit hit;
      Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

      if (Physics.Raycast(ray, out hit, interactRange))
      {
        Interactable interactable = hit.collider.GetComponent<Interactable>();
        if (interactable != null)
        {
          if (interactable.type == "AssaultRifle")
          {
            InstantiateNewRifle();
          }
          interactable.Interact();
        }
      }
    }
  }
}
