using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public float mouseSensitivityX = 80f;
  public float mouseSensitivityY = 80f;

  public Transform playerBody;
  private float aroundXRotation = 0f;

  // Start is called before the first frame update
  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
  }
  // Update is called once per frame
  void Update()
  {
    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

    aroundXRotation -= mouseY;
    aroundXRotation = Mathf.Clamp(aroundXRotation, -90f, 90f);

    transform.localRotation = Quaternion.Euler(aroundXRotation, 0f, 0f);
    playerBody.Rotate(Vector3.up * mouseX);

  }
}
