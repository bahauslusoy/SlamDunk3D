using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource ballSound;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Basket")
        {
            gameManager.Basket(transform.position);
        }
        else if (other.gameObject.tag == "GameOver")
        {
            gameManager.Lose();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        ballSound.Play();
    }
}
