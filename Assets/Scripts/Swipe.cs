using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Swipe: MonoBehaviour
{

    Vector2 startPos, endPos, direction, newDirection, newEndPos;
    public GameObject ball;
    public Sprite ballSize;
    public CircleCollider2D ballCollider;
    public PhysicsMaterial2D mat;
    public AudioClip MusicClip;
    public AudioSource MusicSource;

    public Transform ballPos;
    public Camera cam;

    public float height;
    public float width;

    public Button pause;
    public GameObject pauseMenu;
    public GameObject restartMenu;
    public Button resume;
    public Button mainMenu;
    public Button reset;
    public Button continueButton;
    public Button close;
    public Button mute;
    public Button unmute;

    public static bool swipeBall;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        swipeBall = true;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        height = Camera.main.orthographicSize * 2.0f;
        width = height * Screen.width / Screen.height;
        ball = GameObject.FindGameObjectWithTag("Ball");
        MusicSource.clip = MusicClip;
        Camera cam2 = cam.GetComponent<Camera>();
        Button pauseBtn = pause.GetComponent<Button>();
        pause.onClick.AddListener(PauseButtonClick);
        Button resumeBtn = resume.GetComponent<Button>();
        resume.onClick.AddListener(ResumeButtonClick);
        Button mainMenuBtn = mainMenu.GetComponent<Button>();
        mainMenu.onClick.AddListener(MainMenuButtonClick);
        Button resetBtn = reset.GetComponent<Button>();
        reset.onClick.AddListener(ResetButtonClick);
        Button continueBtn = continueButton.GetComponent<Button>();
        continueButton.onClick.AddListener(ContinueButtonClick);
        Button closeBtn = close.GetComponent<Button>();
        close.onClick.AddListener(CloseButtonClick);
        Button muteBtn = mute.GetComponent<Button>();
        mute.onClick.AddListener(MuteButtonClick);
        Button unmuteBtn = unmute.GetComponent<Button>();
        unmute.onClick.AddListener(UnmuteButtonClick);

        if(AudioListener.volume == 0)
        {
            mute.gameObject.SetActive(false);
            unmute.gameObject.SetActive(true);
        }

    }

    bool TouchOnBall()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(ballPos.position);
        if (startPos.x > (screenPos.x - (ballSize.rect.width / 4) - 150) && startPos.x < (screenPos.x + (ballSize.rect.width / 4) + 150)
            && startPos.y > (screenPos.y - (ballSize.rect.height / 2) - 150) && startPos.y < (screenPos.y + (ballSize.rect.height / 4) + 150))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (swipeBall == true)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Time.fixedDeltaTime = 0.001f;
                startPos = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endPos = Input.GetTouch(0).position;
            }
            if (TouchOnBall() && ball.transform.position.y < -3f && ball.gameObject.transform.localScale == new Vector3(0.28f, 0.28f, 0f))
            {
                ballCollider.sharedMaterial = null;
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    startPos = Input.GetTouch(0).position;
                }

                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    endPos = Input.GetTouch(0).position;
                    if (endPos != startPos)
                    {
                        newEndPos = new Vector2(endPos.x, endPos.y + 1000);
                        direction = newEndPos - startPos;
                        newDirection = direction / direction.magnitude;
                        GetComponent<Rigidbody2D>().velocity = newDirection * 30.8f;
                        MusicSource.Play();
                    }
                }
            }
            else
            {
                ballCollider.sharedMaterial = mat;
            }
        }
    }

    void PauseButtonClick()
    {
        Time.timeScale = 0;
        Score.moveNet = false;
        HardMode.moveNet = false;
        TimeChallenge.moveNet = false;
        BarCollider.shrinkBall = false;
        pauseMenu.SetActive(true);
    }
    void ResumeButtonClick()
    {
        Time.timeScale = 1;
        Score.moveNet = true;
        HardMode.moveNet = true;
        TimeChallenge.moveNet = true;
        BarCollider.shrinkBall = true;
        pauseMenu.SetActive(false);
    }
    void MainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
    void ResetButtonClick()
    {
        if (SceneManager.GetActiveScene().name == "Basketball")
        {
            restartMenu.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == "TimeChallenge")
        {
            SceneManager.LoadScene(3);
        }
    }
    void ContinueButtonClick()
    {
        PlayerPrefs.SetInt("HighscoreLevel", 0);
        Score.num = 0;
        SceneManager.LoadScene(0);
    }
    void CloseButtonClick()
    {
        restartMenu.SetActive(false);
    }
    void MuteButtonClick()
    {
        AudioListener.volume = 0;
        mute.gameObject.SetActive(false);
        unmute.gameObject.SetActive(true);
    }
    void UnmuteButtonClick()
    {
        AudioListener.volume = 1;
        unmute.gameObject.SetActive(false);
        mute.gameObject.SetActive(true);
    }
}
