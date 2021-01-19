using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float moveSpeed = 12f;
    public float groundDistance = 0.4f;
    public float jumpPower = 4f;

    public LayerMask groundMask;

    public Transform playerBody;

    public Rigidbody rb;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = playerBody.GetComponent<Rigidbody>();
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
        //rb.MovePosition(playerBody.position + move * moveSpeed * Time.deltaTime);
        playerBody.position += move * moveSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(playerBody.transform.up * jumpPower, ForceMode.Impulse);
        }
    }
}
