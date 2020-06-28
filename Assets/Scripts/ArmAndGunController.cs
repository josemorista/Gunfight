using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAndGunController : MonoBehaviour
{
  public Rigidbody projectile;
  public float projectileSpeed = 30f, timeToThrow = 2.0f;
  private float throwingTime = 0f;
  private bool hasThrowed = false;
  Animator animator;

  private bool throwing = false;
  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponentInChildren<Animator>();
  }

  void Shoot()
  {
    Rigidbody newProjectile = Instantiate(projectile, transform.position, transform.rotation);
    newProjectile.transform.Rotate(new Vector3(0f, 90f, 0f));
    newProjectile.velocity = transform.right * 0 + transform.up * 0 + transform.forward * projectileSpeed;
  }

  // Update is called once per frame
  void Update()
  {
    if (!hasThrowed && Input.GetButtonDown("Fire1"))
    {
      throwing = true;
      hasThrowed = true;
      animator.SetTrigger("Throw");
      throwingTime = timeToThrow + Time.time;
    }

    if (throwing && Time.time > throwingTime)
    {
      throwing = false;
      Shoot();
      Destroy(gameObject, 0.2f);
    }
  }
}
