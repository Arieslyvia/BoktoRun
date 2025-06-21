using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    public Animator playeR;
    public Rigidbody bokTo;
    public float boktoSpeed;
    public float rotationSpeed;
    public Vector3 jump;
    //public GameObject gameOver;
    bool isJumping;

    Vector3 startPos;
    Vector3 lastPos;
    private CapsuleCollider playerCollider;
    public GameObject currentPath;


    private void Start()
    {
        playeR = this.GetComponent<Animator>();
        bokTo = this.GetComponent<Rigidbody>();
       playerCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {

        var x = Vector3.forward + Vector3.up * bokTo.velocity.y;
        transform.Translate(x * boktoSpeed * Time.deltaTime);

        /*Vector3 x = transform.forward * boktoSpeed;
        var YVel = bokTo.velocity.y;
        bokTo.velocity = new Vector3(x.x, YVel, x.z);*/
        //transform.Translate(x * boktoSpeed * Time.deltaTime);
        SwipeRL();

        if (transform.position.y < -5)
        {
            Handheld.Vibrate();
            //gameOver.SetActive(true);
            Invoke("Restart", 2);

        }
    }


    /*private void FixedUpdate()
    {
        Vector3 x = transform.forward * boktoSpeed;
        var YVel = bokTo.velocity.y;
        bokTo.MovePosition(new Vector3(x.x, transform.position.y, x.y));
    }*/

    void SwipeRL()
    {


        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouseButton
        {
            startPos = Input.mousePosition;


        }
        else if (Input.GetMouseButtonUp(0))
        {
            lastPos = Input.mousePosition;
            ShiftPosition();
        }

    }


    void ShiftPosition()
    {
        var xDisplace = startPos.x - lastPos.x;
        var yDisplace = startPos.y - lastPos.y;

        if (Mathf.Abs(xDisplace) > Mathf.Abs(yDisplace))
        {
            if (startPos.x - lastPos.x < 0)
            {
                playeR.transform.Rotate(new Vector3(0, 90, 0));

                //playeR.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90f, 0);
                //transform.Rotate(new Vector3(0f, 90f, 0f));
                //bokTo.velocity = new Vector3(boktoSpeed, bokTo.velocity.y, 0);
                playeR.SetFloat("Running", Mathf.Abs(xDisplace));
                Debug.Log("Swipe Right");

            }
            else
            {
                playeR.transform.Rotate(new Vector3(0, -90, 0));
                //playeR.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y -90f, 0);
                //transform.Rotate(new Vector3(0f, 90f, 0f));
                //bokTo.velocity = new Vector3(boktoSpeed, bokTo.velocity.y, 0);
                playeR.SetFloat("Running", Mathf.Abs(xDisplace));
                Debug.Log("Swipe Left");

            }
        }
        else
        {
            if (startPos.y - lastPos.y < 0)
            {
                Debug.Log("up");
                if (isJumping)
                {
                    isJumping = true;
                    playeR.SetTrigger("Jumping");
                    bokTo.AddForce(jump, ForceMode.Impulse);
                    isJumping = false;
                    Debug.Log("up");
                }
            }
            else
            {
                Debug.Log("down");
                playeR.SetTrigger("Slide");

            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {

            isJumping = true;
            //currentPath = collision.transform.parent.parent.gameObject;

            Debug.Log(currentPath);


        }
        /*if (collision.gameObject.CompareTag("obstacle"))
        {
            Handheld.Vibrate();

            gameObject.SetActive(false);

        }*/
    }

    public void Collider()
    {
        playerCollider.height = 0.03f;
        playerCollider.center = new Vector3(0, 0.02f, 0);

    }
    public void NormalCollider()
    {
        playerCollider.height = 0.8428271f;
        playerCollider.center = new Vector3(0, 0.5116022f, 0);
    }
    void Restart()
    {
        StartCoroutine(DelayAction());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameObject.SetActive(true);
        //gameOver.SetActive(false);
    }
    IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(3f);
    }
}


