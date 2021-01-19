using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float movementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = Random.Range(movementSpeed, movementSpeed + 5);
        transform.GetChild(0).GetComponent<Rigidbody>().drag = Random.Range(0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * movementSpeed * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(transform.position += transform.forward * movementSpeed * Time.deltaTime);
    }
}
