using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DemoPlayerMovement : MonoBehaviour
{

    [SerializeField] float horizontalSpeed;
    [SerializeField] float forwardSpeed;
    private Rigidbody rigidbody;
    private Vector3 movement;

    //DISTANCE
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        //DISTANCE
        StartCoroutine(distanceTracker());
    }

    // Update is called once per frame
    void Update()
    {
        // Forward Movement
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed, Space.World);
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
    }


    // Änderungen an Rigidbody werden in Fixed Update gemacht
    private void FixedUpdate() {
        rigidbody.velocity = movement * horizontalSpeed;
    }

    //DISTANCE
    private IEnumerator distanceTracker() {
        while(true){
            //S = V * t
            distance = Mathf.Round(forwardSpeed * Time.deltaTime);
            Highscore.inst.increaseScore(distance);
            yield return new WaitForSeconds(1.0f);
        }
    }

}
