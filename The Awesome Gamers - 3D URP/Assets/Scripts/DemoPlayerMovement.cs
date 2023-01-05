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
    public Text distanceText;
    public Text highscoreText;
    public Text usernameText;
    public GameController gc;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        highscoreText.text = "Highscore:" + " " + PlayerPrefs.GetFloat("Highscore", 0).ToString();
        //usernameText.text = "Username" + " " + PlayerPrefs.GetString("Username");
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
            distance+= forwardSpeed * Time.deltaTime;
            //round to second decimal so that the distance can be displayed properly
            distance = Mathf.Round(distance * 100f) / 100f;
            distanceText.text = "Distance" + " " + distance.ToString();

            if(distance > PlayerPrefs.GetFloat("Highscore", 0)){
                PlayerPrefs.SetFloat("Highscore", distance);
                highscoreText.text = "Highscore:" + " " + distance.ToString();
            }

            Debug.Log(distance);
            yield return new WaitForSeconds(1.0f);
        }
    }

    
}