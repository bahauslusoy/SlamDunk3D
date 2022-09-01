using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject platform;
    [SerializeField] private Image[] missions;
    [SerializeField] private Sprite missionComp;
    [SerializeField] private int requiredThrowBall;

    private int basketNumber;

    void Start()
    {
        for (int i = 0; i < requiredThrowBall; i++)
        {
            missions[i].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x - 0.3f,
            platform.transform.position.y, platform.transform.position.z), 0.1f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x + 0.3f,
            platform.transform.position.y, platform.transform.position.z), 0.1f);
        }
    }

    public void Basket()
    {
        basketNumber++;
        missions[basketNumber - 1].sprite = missionComp;
        if (basketNumber == requiredThrowBall)
        {

        }
    }

    public void Lose()
    {
        Debug.Log("lOse");
    }
}
