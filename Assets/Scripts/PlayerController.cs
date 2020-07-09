using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  CharacterController playerController = null;
  Animator animator;
  public float playerVelocity = 5.0f, gravity = 9.8f, jumpHeight = 1f;
  private float xMovement = 0f, yMovement = 0f, zMovement = 0f;
  // Start is called before the first frame update
  void Start()
  {
    playerController = GetComponent<CharacterController>();
  }

  void Die()
  {
    SceneManager.LoadScene(2);
  }

  // Update is called once per frame
  void Update()
  {
    bool isRunning = false;
    float movementSpeed = playerVelocity;

    if (playerController.isGrounded)
    {
      xMovement = Input.GetAxis("Horizontal");
      zMovement = Input.GetAxis("Vertical");
      if (Input.GetButtonDown("Jump"))
      {
        yMovement = Mathf.Sqrt(jumpHeight * 2 * gravity);
      }
      if (Input.GetButton("Run"))
      {
        isRunning = true;
        movementSpeed = playerVelocity + 1;
      }
    }
    else
    {
      yMovement -= gravity * Time.deltaTime;
    }

    Vector3 moveDirection = transform.right * xMovement + transform.up * yMovement + transform.forward * zMovement;
    playerController.Move(moveDirection * movementSpeed * Time.deltaTime);

    if (!animator)
    {
      animator = GetComponentInChildren<Animator>();
    }

    if (animator)
    {
      if (playerController.velocity.magnitude != 0)
      {
        if (isRunning)
        {
          animator.SetFloat("MovementSpeed", 1.0f, .1f, Time.deltaTime);
        }
        else
        {
          animator.SetFloat("MovementSpeed", 0.5f, .1f, Time.deltaTime);
        }
      }
      else
      {
        animator.SetFloat("MovementSpeed", 0, .1f, Time.deltaTime);
      }
    }
  }
}
