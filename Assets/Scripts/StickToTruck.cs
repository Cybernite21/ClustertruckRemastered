using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToTruck : MonoBehaviour
{
    public bool isPlatform = false;
    public GameObject otherObject;
    public Rigidbody rb;

    public Vector3 offset;

    public float truckMoveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlatform)
        {
            //transform.position += -otherObject.transform.up * otherObject.transform.parent.GetComponent<TruckMovement>().movementSpeed * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (isPlatform)
        {
            //rb.MovePosition(transform.position + move * moveSpeed * Time.fixedDeltaTime+ -otherObject.transform.up * otherObject.transform.parent.GetComponent<TruckMovement>().movementSpeed * Time.fixedDeltaTime);
            //transform.position += -otherObject.transform.up * truckMoveSpeed*3/5 * Time.deltaTime;
            //rb.MovePosition(otherObject.transform.position + offset);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "truck")
        {
            isPlatform = true;
            otherObject = other.gameObject;
            truckMoveSpeed = otherObject.transform.parent.GetComponent<TruckMovement>().movementSpeed;
            offset = other.transform.position - transform.position;
            //rb.isKinematic = true;
            //transform.parent = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isPlatform = false;
        //rb.isKinematic = false;
        //transform.parent = null;
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "truck")
        {
            transform.parent = collision.transform;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        transform.parent = null;
    }
}
