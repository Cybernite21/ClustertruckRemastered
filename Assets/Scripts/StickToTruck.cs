using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToTruck : MonoBehaviour
{
    public bool isPlatform = false;
    public GameObject otherObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlatform)
        {
            transform.position += otherObject.transform.parent.forward * otherObject.transform.parent.GetComponent<TruckMovement>().movementSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "truck")
        {
            isPlatform = true;
            otherObject = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isPlatform = false;   
    }
}
