using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncreaseBasket : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private int startTime;

    public GameManager gameManager;


    void Start()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        timer.text = startTime.ToString();

        while (true)
        {
            yield return new WaitForSeconds(1f);
            startTime--;
            timer.text = startTime.ToString();
            if (startTime == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        gameManager.BasketIncrease();

    }
}
