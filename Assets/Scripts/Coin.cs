using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int playerScore;
    private int savesStore;
    public GameObject manager;
    public float speed;
    //Scores playerScore;

    private void Start()
    {
        manager = GameObject.Find("GameManager");
    }
    void FixedUpdate()
    {
        RotationSpeed(speed);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Lilac"))
        {
            gameObject.SetActive(false);
            AudioManager.instance.ScoreSound();


        }
        manager.GetComponent<GameManager>().IncrementScore();
    }
    public void RotationSpeed(float rotationSpeed)
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0 );

    }

}
