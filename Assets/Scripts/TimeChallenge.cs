using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeChallenge : MonoBehaviour
{

    public GameObject ball;
    public GameObject bar;
    public GameObject ballnet;
    public GameObject timesUp;
    public Rigidbody2D ballRb;
    public PolygonCollider2D goal;
    public CircleCollider2D coinColider;
    public EdgeCollider2D scoreCheck;
    public Text scoreText;
    public Text highscoreText;
    public Text highScoreTitle;
    public Text coinsText;
    public Text coinsTitle;
    public Text highScore;
    public Text threeSeconds;
    public Text thirtySeconds;
    public Text timeTitle;
    public Text timesUpScore;
    public Text shotsTakenText;
    public int score;
    public SpriteRenderer barLayer;
    public SpriteRenderer basketball;
    public SpriteRenderer net;
    public SpriteRenderer barMover;
    public SpriteRenderer coin;

    public int highscore;
    public static int scoreNum;
    public static int scoreTemp;
    public float tempPos;

    public static int coins;
    public int coinsCount;

    public byte red, red2, red3, red4;
    public byte green, green2, green3, green4;
    public byte blue, blue2, blue3, blue4;
    public bool highscoreMusic;

    public bool switchDirectionX;
    public bool switchDirectionY;

    public static bool moveNet;

    public float height;
    public float width;
    public float netWidth;

    public bool isHit = false;
    public bool startGame;

    public AudioClip goalSound;
    public AudioSource goalSource;
    public AudioClip loseSound;
    public AudioSource loseSource;
    public AudioClip coinSound;
    public AudioSource coinSource;
    public AudioClip highscoreSound;
    public AudioSource highscoreSource;

    public float startTimer;
    public float gameTimer;

    public int shotsTaken = 0;

    public Button retry;
    public Button mainMenu;

    public Material ballMaterial;
    public Color defaultBallColor;

    void Start()
    {
        StartCoroutine(ExecuteAfterTime(0.1f));
        startTimer = 3.2f;
        gameTimer = 30f;
        scoreNum = 0;
        scoreTemp = 0;
        coin.sortingOrder = -1;
        net.sortingOrder = -2;
        scoreText.text = PlayerPrefs.GetInt("TimeScore", 0).ToString();
        moveNet = true;
        highscoreMusic = true;
        highscoreText.text = PlayerPrefs.GetInt("TimeChallengeScore", 0).ToString();
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = PlayerPrefs.GetInt("Coins", 0).ToString();
        height = Camera.main.orthographicSize * 2.0f;
        width = height * Screen.width / Screen.height;
        netWidth = barMover.bounds.size.x;
        goalSource.clip = goalSound;
        loseSource.clip = loseSound;
        coinSource.clip = coinSound;
        highscoreSource.clip = highscoreSound;
        Button retryBtn = retry.GetComponent<Button>();
        retry.onClick.AddListener(RetryBtnClick);
        Button mainMenuBtn = mainMenu.GetComponent<Button>();
        mainMenu.onClick.AddListener(MainMenuBtnClick);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        defaultBallColor = ballMaterial.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer > 0.00f)
        {
            Swipe.swipeBall = false;
            scoreText.enabled = false;
            startGame = false;
            startTimer -= Time.deltaTime;
            threeSeconds.text = startTimer.ToString("f0");
        }
        else
        {
            Swipe.swipeBall = true;
            threeSeconds.enabled = false;
            scoreText.enabled = true;
            startGame = true;
            if (gameTimer > 0.01f)
            {
                gameTimer -= Time.deltaTime;
                if (gameTimer >= 10f)
                {
                    thirtySeconds.text = gameTimer.ToString("f1");
                }
                else
                {
                    thirtySeconds.text = gameTimer.ToString("f");
                }
            }
            else
            {
                thirtySeconds.text = "0.00";
                thirtySeconds.color = new Color32(245, 66, 66, 255);
                timeTitle.color = new Color32(245, 66, 66, 255);
                if (ball.transform.position.y <= -3.1f)
                {
                    moveNet = false;
                    Swipe.swipeBall = false;
                    timesUp.SetActive(true);
                    timesUpScore.text = PlayerPrefs.GetInt("TimeScore", 0).ToString();
                    shotsTakenText.text = shotsTaken.ToString();
                }
            }
        }
        coin.transform.Rotate(0, 1, 0);
        red = (byte)Random.Range(0, 255);
        green = (byte)Random.Range(0, 255);
        blue = (byte)Random.Range(0, 255);
        red2 = (byte)Random.Range(0, 255);
        green2 = (byte)Random.Range(0, 255);
        blue2 = (byte)Random.Range(0, 255);
        red3 = (byte)Random.Range(0, 255);
        green3 = (byte)Random.Range(0, 255);
        blue3 = (byte)Random.Range(0, 255);
        red4 = (byte)Random.Range(0, 255);
        green4 = (byte)Random.Range(0, 255);
        blue4 = (byte)Random.Range(0, 255);
        score = scoreNum;
        PlayerPrefs.SetInt("TimeScore", score);
        scoreText.text = score.ToString();

        if (barLayer.sortingLayerName == "New Layer")
        {
            goal.GetComponent<PolygonCollider2D>().enabled = true;
        }
        else
        {
            goal.GetComponent<PolygonCollider2D>().enabled = false;
            scoreCheck.GetComponent<EdgeCollider2D>().enabled = true;
            isHit = false;
        }

        if (ball.transform.position.y > -1)
        {
            scoreCheck.GetComponent<EdgeCollider2D>().enabled = false;
        }
        if (ball.transform.position.y > 3.55)
        {
            if (coinsCount == 10)
            {
                coin.GetComponent<CircleCollider2D>().enabled = true;
            }
            else
            {
                coin.GetComponent<CircleCollider2D>().enabled = false;
            }
        }

        if (coinsCount == 10)
        {
            coin.gameObject.SetActive(true);
        }
        else
        {
            coin.gameObject.SetActive(false);
        }
        if ((ball.transform.position.y < -8 || ball.transform.position.x > 5 || ball.transform.position.x < -5)
            && scoreTemp != scoreNum)
        {
            scoreTemp = scoreNum;
            shotsTaken++;
            loseSource.Play();
            if (coin.gameObject.activeSelf)
            {
                coinsCount = 0;
            }
        }
        if (scoreNum > PlayerPrefs.GetInt("TimeChallengeScore", 0))
        {
            PlayerPrefs.SetInt("TimeChallengeScore", scoreNum);
            highscoreText.text = scoreNum.ToString();
            if (highscoreMusic)
            {
                highscoreSource.Play();
                highscoreMusic = false;
            }
        }
        if (moveNet == true && startGame == true)
        {
            switchDirectionX = true;
            if (ballnet.transform.position.y > 2.47 &&
                ballnet.transform.position.x > -((width / 2) - (netWidth / 2)) &&
                switchDirectionX == true)
            {
                ballnet.gameObject.transform.position -= new Vector3(0.035f, 0f, 0f);
                bar.gameObject.transform.position -= new Vector3(0.035f, 0f, 0f);
                coin.gameObject.transform.position -= new Vector3(0.035f, 0f, 0f);

                if (ballnet.transform.position.x < -((width / 2) - (netWidth / 2)))
                {
                    switchDirectionY = true;
                    switchDirectionX = false;
                }
            }
            if (ballnet.transform.position.y > 1.8 &&
                ballnet.transform.position.x < -((width / 2) - (netWidth / 2)) &&
                switchDirectionY == true)
            {
                ballnet.gameObject.transform.position -= new Vector3(0f, 0.035f, 0f);
                bar.gameObject.transform.position -= new Vector3(0f, 0.035f, 0f);
                coin.gameObject.transform.position -= new Vector3(0f, 0.035f, 0f);

                if (ballnet.transform.position.y < 1.8)
                {
                    switchDirectionY = false;
                    switchDirectionX = true;
                }
            }
            if (ballnet.transform.position.y < 1.8 &&
                ballnet.transform.position.x < ((width / 2) - (netWidth / 2)) &&
                switchDirectionX == true)
            {
                ballnet.gameObject.transform.position += new Vector3(0.035f, 0f, 0f);
                bar.gameObject.transform.position += new Vector3(0.035f, 0f, 0f);
                coin.gameObject.transform.position += new Vector3(0.035f, 0f, 0f);

                if (ballnet.transform.position.x > ((width / 2) - (netWidth / 2)))
                {
                    switchDirectionY = true;
                    switchDirectionX = false;
                }
            }
            if (ballnet.transform.position.y < 2.47 &&
               ballnet.transform.position.x > (width / 2) - (netWidth / 2) &&
               switchDirectionY == true)
            {

                ballnet.gameObject.transform.position += new Vector3(0f, 0.035f, 0f);
                bar.gameObject.transform.position += new Vector3(0f, 0.035f, 0f);
                coin.gameObject.transform.position += new Vector3(0f, 0.035f, 0f);

                if (ballnet.transform.position.y > 2.47)
                {
                    switchDirectionY = false;
                    switchDirectionX = true;
                }
            }
            
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "TimeChallengeBar" && !isHit)
        {
            goalSource.Play();
            ballMaterial.color = new Color32(red, green, blue, 255);
            Camera.main.backgroundColor = new Color32(red2, green2, blue2, 255);
            net.color = new Color32(red3, blue3, green3, 255);
            barMover.color = new Color32(red3, blue3, green3, 255);
            scoreText.color = new Color32(red4, green4, blue4, 255);
            highScoreTitle.color = new Color32(red4, green4, blue4, 255);
            highScore.color = new Color32(red4, green4, blue4, 255);
            coinsText.color = new Color32(red4, green4, blue4, 255);
            coinsTitle.color = new Color32(red4, green4, blue4, 255);
            if (gameTimer > 0.00f) { 
                thirtySeconds.color = new Color32(red4, green4, blue4, 255);
                timeTitle.color = new Color32(red4, green4, blue4, 255);
            }
            scoreNum++;
            coinsCount++;
            shotsTaken++;
            if (coinsCount == 11)
            {
                coins++;
                coinSource.Play();
                PlayerPrefs.SetInt("Coins", coins);
                coinsText.text = coins.ToString();
                coinsCount = 0;
            }

            isHit = true;

        }
        if (col.gameObject.tag == "Coin")
        {
            coinSource.Play();
            coins++;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();
            coinsCount = 0;
        }
        if (col.gameObject.tag == "TimeChallengeScoreCheck")
        {
            scoreTemp++;
        }
    }
    void RetryBtnClick()
    {
        SceneManager.LoadScene(3);
    }
    void MainMenuBtnClick()
    {
        SceneManager.LoadScene(0);
    }
}
