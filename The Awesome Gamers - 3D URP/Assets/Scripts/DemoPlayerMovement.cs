using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayerMovement : MonoBehaviour
{

    private float horizontalInput = 0;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float forwardSpeed;
    private Rigidbody rigidbody;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {

        // Forward Movement

        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed, Space.World);     

        // Horizontal Movement
        horizontalInput = Input.GetAxis("Horizontal");
        movement = new Vector3(Input.GetAxis("Horizontal"), 0 ,0);
             
    }


    // Änderungen an Rigidbody werden in Fixed Update gemacht
    private void FixedUpdate() {
        rigidbody.velocity = movement * horizontalSpeed;
    }

    
}
