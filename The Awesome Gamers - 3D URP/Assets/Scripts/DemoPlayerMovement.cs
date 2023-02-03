using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DemoPlayerMovement : MonoBehaviour
{

    [SerializeField] float horizontalSpeed;
    [SerializeField] float forwardSpeed;
    private Rigidbody rigidbody;
    private Vector3 movement;
    private float rotation;
    private float rotationSpeed = 1f;
    private Quaternion originalRotation;
    private Quaternion qTo;


    //DISTANCE
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        originalRotation = transform.GetChild(1).rotation;
        qTo = transform.GetChild(1).rotation;

        rigidbody = transform.GetComponent<Rigidbody>();

        //DISTANCE
        StartCoroutine(distanceTracker());
    }

    // Update is called once per frame
    void Update()
    {
        // Forward Movement
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed, Space.World);

        // Vertical/horizontal movement
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        // Horizontal movement rotation
        rotation += Input.GetAxis("Horizontal");
        rotation = Mathf.Clamp(rotation, -10f, 10f);
        transform.GetChild(1).localEulerAngles = new Vector3(0, 0, -rotation);

        var zQuaternion = Quaternion.AngleAxis(rotation, Vector3.forward);
        qTo = originalRotation * zQuaternion;

        if (Input.GetAxis("Horizontal") == 0)
        {
            //transform.GetChild(1).rotation = Quaternion.identity;
            //Debug.Log("Halloooooooo");
            var step = rotationSpeed * Time.deltaTime;
            transform.GetChild(1).rotation = Quaternion.Slerp(transform.GetChild(1).rotation, qTo, step);
        }
    }


    // Änderungen an Rigidbody werden in Fixed Update gemacht
    private void FixedUpdate()
    {
        rigidbody.velocity = movement * horizontalSpeed;
    }

    //DISTANCE
    private IEnumerator distanceTracker()
    {
        while (true)
        {
            //S = V * t
            //distance = Mathf.Round(forwardSpeed * Time.deltaTime);
            Highscore.inst.increaseScore(1.0f);
            yield return new WaitForSeconds(1.0f);
        }
    }

}
