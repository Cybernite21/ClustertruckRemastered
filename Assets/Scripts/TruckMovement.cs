using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float rot = 0;
    public float rotAmplitude = 2;
    float turn = 4f;
    float driftTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = Random.Range(movementSpeed, movementSpeed + 5);
        //transform.GetChild(0).GetComponent<Rigidbody>().drag = Random.Range(0.1f, 1f);
        Invoke("startDrift", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        //transform.GetChild(1).transform.localRotation = Quaternion.Euler(new Vector3(transform.GetChild(1).transform.localRotation.x, transform.GetChild(1).transform.localRotation.y, transform.GetChild(1).transform.localRotation.z + Random.Range(-.1f, .1f)));
        rot += Random.Range(-rotAmplitude, rotAmplitude) * Time.deltaTime * 2;
        rot = Mathf.Clamp(rot, -3f, 3f);
        //transform.GetChild(1).transform.Rotate(0, rot, 0);
        transform.GetChild(1).transform.localRotation = Quaternion.Euler(new Vector3(-90, 0, rot));
        //transform.position += -transform.GetChild(1).transform.up * movementSpeed * Time.deltaTime;
        transform.GetChild(1).GetComponent<Rigidbody>().MovePosition(transform.GetChild(1).transform.position + -transform.GetChild(1).transform.up * movementSpeed * Time.deltaTime);
    }

    void startDrift()
    {
        //StartCoroutine(drifting());
    }

    //drifting
    IEnumerator drifting()
    {

        while (true)
        {
            float time = driftTime;
            float timer = 0f;
            int dir = Mathf.RoundToInt(Random.value);

            Quaternion originRot = transform.GetChild(1).transform.localRotation;

            while (timer <= time/2f)
            {
                if(dir == 0)
                {
                    transform.GetChild(1).transform.localRotation = Quaternion.Lerp(originRot, Quaternion.Euler(originRot.x, originRot.y, originRot.z - turn), timer/(time/2f));
                }
                else
                {
                    transform.GetChild(1).transform.localRotation = Quaternion.Lerp(originRot, Quaternion.Euler(originRot.x, originRot.y, originRot.z + turn), timer / (time/2f));
                }
                timer += Time.deltaTime;
                yield return null;
            }
            timer = 0;
            while (timer <= time/2f)
            {
                if (dir == 0)
                {
                    transform.GetChild(1).transform.localRotation = Quaternion.Lerp(Quaternion.Euler(originRot.x, originRot.y, originRot.z - turn), originRot, timer / (time / 2f));
                }
                else
                {
                    transform.GetChild(1).transform.localRotation = Quaternion.Lerp(Quaternion.Euler(originRot.x, originRot.y, originRot.z + turn), originRot, timer / (time / 2f));
                }
                timer += Time.deltaTime;
                yield return null;
            }
        }

        yield return null;
    }
}
