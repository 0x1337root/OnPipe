using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    Rigidbody rb;

    private float circleScale = 0.55f;

    private bool started = false;

    private void Start()
    {
        FindObjectOfType<ScoreController>().Play(started);
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Keyboard Control
        if (Input.GetKey("space"))
        {
            started = true;
            FindObjectOfType<ScoreController>().Play(started);
        }

        // Touch Control
        /*if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began)
            {
                started = true;
                FindObjectOfType<ScoreController>().Play(started);
            }
        }*/

        if (started)
        {
            // Keyboard Control
            if (Input.GetKey("space"))
            {
                transform.localScale = new Vector3(circleScale, circleScale, 3.5f);
            }

            if (Input.GetKeyUp("space"))
            {
                transform.localScale = new Vector3(1.5f, 1.5f, 2.5f);
            }

            // Touch Control
            /*if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    transform.localScale = new Vector3(circleScale, circleScale, 2.5f);
                }
            }
            else
            {
                transform.localScale = new Vector3(1.5f, 1.5f, 2.5f);
            }*/
        }
    }

    private void FixedUpdate()
    {
        if (started)
        {
            transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == null)
        {
            circleScale = 0.55f;
        }
        else if(other.tag == "Block")
        {
            circleScale = 0.35f;
        }
        else if(other.tag == "Safe")
        {
            FindObjectOfType<ScoreController>().GameOver();
            FindObjectOfType<SceneManage>().SetBool(false, true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == null)
        {
            circleScale = 0.55f;
        }
        else if (other.tag == "Block")
        {
            circleScale = 0.35f;
        }
        else if (other.tag == "Safe")
        {
            FindObjectOfType<ScoreController>().GameOver();
            FindObjectOfType<SceneManage>().SetBool(false, true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Block")
        {
            circleScale = 0.55f;
        }

        else if(other.tag == "Finish")
        {
            FindObjectOfType<ScoreController>().Victory();
            FindObjectOfType<SceneManage>().SetBool(true,false);
            Destroy(gameObject);
        }
    }
}