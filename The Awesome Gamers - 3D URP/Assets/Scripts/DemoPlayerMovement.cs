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
    public float rotationSpeed;
   
    private float currentAngle;
    private float horizontalInput;

    public Transform playerTransform;
    public Transform sunTransform;
    private Vector3 sunPosition;
    private Vector3 playerPoistion;

    //DISTANCE
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        sunPosition = sunTransform.position;
        //sunTransform.SetParent(null, false);
        
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

        // Horizontal roll movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            currentAngle = Mathf.Clamp(currentAngle + -horizontalInput * rotationSpeed * Time.deltaTime, -15f, 15f);
        } else
        {
            currentAngle = Mathf.Lerp(currentAngle, 0, rotationSpeed / 10 * Time.deltaTime);
        }
        transform.GetChild(1).rotation = Quaternion.Euler(0, 0, currentAngle);

        playerPoistion = playerTransform.position;
        sunTransform.position = new Vector3(sunPosition.x, sunPosition.y, playerPoistion.z + 900);


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
