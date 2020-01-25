using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject player;
    /*
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            player.GetComponent<Rigidbody>().AddForce(player.transform.forward *100);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            player.GetComponent<Rigidbody>().AddForce(-player.transform.forward*100);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.GetComponent<Rigidbody>().AddForce(-player.transform.right*100);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.GetComponent<Rigidbody>().AddForce(player.transform.right*100);
        }
    }
    */
    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;

    private float rotation;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rotation = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
        Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
        //transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
    }
}
