using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float moveSpeed = 12f;

    public Transform playerBody;
    public CharacterController controller;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = playerBody.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = playerBody.right * moveX + playerBody.forward * moveZ;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}
