using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Basket")
        {
            gameManager.Basket();
        }
        else if (other.gameObject.tag == "GameOver")
        {
            gameManager.Lose();
        }
    }
}
