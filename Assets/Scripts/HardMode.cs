using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HardMode : MonoBehaviour
{

    public GameObject ball;
    public GameObject bar;
    public GameObject ballnet;
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

    public bool switchDirectionX = true;
    public bool switchDirectionY = false;
    public bool leftDiag = false;
    public bool rightDiag = false;
    public static bool moveNet;

    public float height;
    public float width;
    public float netWidth;

    public float verticalSpeed = 0.0175f;
    public float verticalDiagSpeed = 0.00342f;
    public float horizontalDiagSpeed = 0.0147f;

    public float speedMultiplier;

    public bool isHit = false;

    public AudioClip goalSound;
    public AudioSource goalSource;
    public AudioClip loseSound;
    public AudioSource loseSource;
    public AudioClip coinSound;
    public AudioSource coinSource;
    public AudioClip highscoreSound;
    public AudioSource highscoreSource;

    public Material ballMaterial;
    public Color defaultBallColor;

    void Start()
    {
        StartCoroutine(ExecuteAfterTime(0.1f));
        scoreNum = 0;
        scoreTemp = 0;
        coin.sortingOrder = -1;
        net.sortingOrder = -2;
        scoreText.text = PlayerPrefs.GetInt("HardScore", 0).ToString();
        moveNet = true;
        highscoreMusic = true;
        highscoreText.text = PlayerPrefs.GetInt("HardModeScore", 0).ToString();
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = PlayerPrefs.GetInt("Coins", 0).ToString();
        height = Camera.main.orthographicSize * 2.0f;
        width = height * Screen.width / Screen.height;
        netWidth = barMover.bounds.size.x;
        goalSource.clip = goalSound;
        loseSource.clip = loseSound;
        coinSource.clip = coinSound;
        highscoreSource.clip = highscoreSound;
        InvokeRepeating("ChangeSpeed", 1.5f, 1f);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        defaultBallColor = ballMaterial.color;
    }

    // Update is called once per frame
    void Update()
    {
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
        PlayerPrefs.SetInt("HardScore", score);
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
            scoreNum = 0;
            scoreTemp = 0;
            loseSource.Play();
            if (coin.gameObject.activeSelf)
            {
                coinsCount = 0;
            }
            highscoreMusic = true;
            ballMaterial.color = defaultBallColor;
            net.color = new Color32(255, 255, 255, 255);
            barMover.color = new Color32(255, 255, 255, 255);
            Camera.main.backgroundColor = new Color32(255, 255, 248, 255);
            scoreText.color = new Color32(103, 103, 103, 255);
            highscoreText.color = new Color32(103, 103, 103, 255);
            highScoreTitle.color = new Color32(103, 103, 103, 255);
            coinsText.color = new Color32(103, 103, 103, 255);
            coinsTitle.color = new Color32(103, 103, 103, 255);
            ballnet.gameObject.transform.position = new Vector3(0f, 2.474f, 0f);
            bar.gameObject.transform.position = new Vector3(0f, 1.9203f, 0f);
            coin.gameObject.transform.position = new Vector3(0f, 2.374f, 0f);
            switchDirectionX = true;
            rightDiag = false;
            leftDiag = false;
            switchDirectionY = false;
        }
        if (scoreNum > PlayerPrefs.GetInt("HardModeScore", 0))
        {
            PlayerPrefs.SetInt("HardModeScore", scoreNum);
            highscoreText.text = scoreNum.ToString();
            if (highscoreMusic)
            {
                highscoreSource.Play();
                highscoreMusic = false;
            }
        }
        if (moveNet == true)
        {
            if (moveNet == true)
            {
                if (ballnet.transform.position.y > 2.47 &&
                    ballnet.transform.position.x > -((width / 2) - (netWidth / 2)) &&
                    switchDirectionX == true && rightDiag == false)
                {
                    ballnet.gameObject.transform.position -= new Vector3(verticalSpeed, 0f, 0f);
                    bar.gameObject.transform.position -= new Vector3(verticalSpeed, 0f, 0f);
                    coin.gameObject.transform.position -= new Vector3(verticalSpeed, 0f, 0f);

                    if (ballnet.transform.position.x < -((width / 2) - (netWidth / 2)))
                    {
                        switchDirectionY = true;
                        leftDiag = true;
                    }
                }
                if ((ballnet.transform.position.y > 1.8 || ballnet.transform.position.x < ((width / 2) - (netWidth / 2)))
                    && switchDirectionY == true && switchDirectionX == true && leftDiag == true)
                {
                    ballnet.gameObject.transform.position += new Vector3(horizontalDiagSpeed, -verticalDiagSpeed, 0f);
                    bar.gameObject.transform.position += new Vector3(horizontalDiagSpeed, -verticalDiagSpeed, 0f);
                    coin.gameObject.transform.position += new Vector3(horizontalDiagSpeed, -verticalDiagSpeed, 0f);

                    if (ballnet.transform.position.y < 1.8 && ballnet.transform.position.x > ((width / 2) - (netWidth / 2)))
                    {
                        switchDirectionX = false;
                        leftDiag = false;
                    }
                }
                if (ballnet.transform.position.y < 2.47 &&
                    switchDirectionX == false)
                {

                    ballnet.gameObject.transform.position += new Vector3(0f, verticalSpeed, 0f);
                    bar.gameObject.transform.position += new Vector3(0f, verticalSpeed, 0f);
                    coin.gameObject.transform.position += new Vector3(0f, verticalSpeed, 0f);

                    if (ballnet.transform.position.y > 2.47)
                    {
                        switchDirectionX = true;
                        if (ballnet.transform.position.x > ((width / 2) - (netWidth / 2)))
                        {
                            rightDiag = true;
                        }
                        if (ballnet.transform.position.x < -((width / 2) - (netWidth / 2)))
                        {
                            leftDiag = true;
                        }

                    }
                }

                if (ballnet.transform.position.x > -(width / 2) - (netWidth / 2) &&
                   switchDirectionX == true && rightDiag == true)
                {
                    ballnet.gameObject.transform.position -= new Vector3(horizontalDiagSpeed, verticalDiagSpeed, 0f);
                    bar.gameObject.transform.position -= new Vector3(horizontalDiagSpeed, verticalDiagSpeed, 0f);
                    coin.gameObject.transform.position -= new Vector3(horizontalDiagSpeed, verticalDiagSpeed, 0f);

                    if (ballnet.transform.position.x < -((width / 2) - (netWidth / 2)))
                    {
                        switchDirectionX = false;
                        rightDiag = false;
                    }
                }
            }
        }
    }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "HardModeBar" && !isHit)
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
                scoreNum++;
                coinsCount++;
                if (coinsCount == 11)
                {
                    coins+=2;
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
                coins+=2;
                PlayerPrefs.SetInt("Coins", coins);
                coinsText.text = coins.ToString();
                coinsCount = 0;
            }
            if (col.gameObject.tag == "HardModeScoreCheck")
            {
                scoreTemp++;
            }
        }
    void ChangeSpeed()
    {
        speedMultiplier = (float)Random.Range(1,7);
        verticalSpeed = speedMultiplier * 0.0175f;
        verticalDiagSpeed = speedMultiplier * 0.00342f;
        horizontalDiagSpeed = speedMultiplier * 0.0147f;
    }
}
