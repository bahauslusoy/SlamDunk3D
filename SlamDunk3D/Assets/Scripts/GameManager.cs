using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    enum State
    {
        preGame,

        inGame,

    }
    private State _currentState = State.preGame;

    public GameObject platform;
    public GameObject basket;
    public GameObject increaseBasket;
    public GameObject[] increaseBasketPoints;

    [SerializeField] private Image[] missions;
    [SerializeField] private Sprite missionComp;
    [SerializeField] private int requiredThrowBall;

    [SerializeField] private AudioSource[] sounds;
    [SerializeField] private ParticleSystem[] effects;
    [SerializeField] private TextMeshProUGUI levelNumber;

    public GameObject startPanel, failPanel, successPanel;

    float horSpeed;
    Vector3 endPos, FirstPos;



    private int basketNumber;

    void Start()
    {
        levelNumber.text = "LEVEL:" + SceneManager.GetActiveScene().name;
        startPanel.SetActive(true);


        for (int i = 0; i < requiredThrowBall; i++)
        {
            missions[i].gameObject.SetActive(true);
        }

        Time.timeScale = 0;
        // Invoke("IncreaseBasketItem",3f);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case State.preGame:
                if (Input.GetMouseButtonDown(0))
                {
                    Time.timeScale = 1;


                    startPanel.SetActive(false);

                    _currentState = State.inGame;


                }

                break;

            case State.inGame:

                if (Input.GetMouseButtonDown(0))
                {
                    FirstPos = Input.mousePosition;
                }
                else if (Input.GetMouseButton(0))
                {
                    endPos = Input.mousePosition;

                    float differenceX = (((endPos.x - FirstPos.x) * Time.deltaTime) * 1080 / Screen.width) * horSpeed;

                    horSpeed = 0.05f;
                    var currentPosition = platform.transform.position;
                    var targetPosition = new Vector3(currentPosition.x + differenceX, currentPosition.y, currentPosition.z);
                    platform.transform.position = targetPosition;
                }

                float Xpos = Mathf.Clamp(platform.transform.position.x,-1.62f, 1.62f);
                platform.transform.position = new Vector3(Xpos, platform.transform.position.y,platform.transform.position.z);


                break;
        }


        // for Keyboard

        /* if (Input.GetKey(KeyCode.LeftArrow))
         {
             platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x - 0.3f,
             platform.transform.position.y, platform.transform.position.z), 0.1f);
         }
         else if (Input.GetKey(KeyCode.RightArrow))
         {
             platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x + 0.3f,
             platform.transform.position.y, platform.transform.position.z), 0.1f);
         }*/
    }

    public void Basket(Vector3 poz)
    {
        basketNumber++;
        missions[basketNumber - 1].sprite = missionComp;
        effects[0].transform.position = poz;
        effects[0].gameObject.SetActive(true);
        sounds[3].Play();

        if (basketNumber == requiredThrowBall)
        {
            Win();
        }
        if (basketNumber == 1)
        {
            IncreaseBasketItem();
        }
    }

    public void IncreaseBasketItem()
    {
        int randomNumber = Random.Range(0, increaseBasketPoints.Length - 1);
        increaseBasket.transform.position = increaseBasketPoints[randomNumber].transform.position;
        increaseBasket.SetActive(true);
        ;



    }

    public void Lose()
    {
        sounds[1].Play();
        Debug.Log("lOse");
        failPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void BasketIncrease()
    {
        sounds[0].Play();
        basket.transform.localScale = new Vector3(70f, 70f, 70f);
    }
    public void Win()
    {
        sounds[2].Play();
        successPanel.SetActive(true);
        Time.timeScale = 0;
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        


    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
