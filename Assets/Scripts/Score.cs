using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_ANDROID
#elif UNITY_IPHONE
    using UnityEngine.iOS;
#endif
public class Score : MonoBehaviour {

    public GameObject ball;
    public GameObject bar;
    public GameObject ballnet;
    public PolygonCollider2D goal;
    public EdgeCollider2D scoreCheck;
    public Text scoreText;
    public Text highscoreText;
    public Text highScoreTitle;
    public Text levelTitle;
    public int score;
    public Text levelText;
    public int level;
    public int highscoreLevel;
    public int adCount;
    public SpriteRenderer ball2;
    public SpriteRenderer basketball;
    public SpriteRenderer net;

    public int highscore;
    public static int num;
    public static int temp;
    public float tempPos;

    public byte red, red2, red3, red4;
    public byte green, green2, green3, green4;
    public byte blue, blue2, blue3, blue4;

    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public AudioClip MusicClip2;
    public AudioSource MusicSource2;
    public AudioClip MusicClip3;
    public AudioSource MusicSource3;
    public AudioClip MusicClip4;
    public AudioSource MusicSource4;
    public bool highscoreMusic;

    public bool switchDirectionX = true;
    public bool switchDirectionY = false;
    public static bool moveNet;

    public float height;
    public float width;
    public float netWidth;

    void Start () {
        if (PlayerPrefs.GetInt("HighscoreLevel") < 10)
        {
            num = 0;
            temp = 0;
        }
        if (PlayerPrefs.GetInt("HighscoreLevel") >= 10)
        {
            num = 10;
            temp = 10;
        }
        if (PlayerPrefs.GetInt("HighscoreLevel") >= 20)
        {
            num = 20;
            temp = 20;
        }
        level = 1;
        moveNet = true;
        highscoreMusic = true;
        scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        levelText.text = PlayerPrefs.GetInt("Level", 1).ToString();
        MusicSource.clip = MusicClip;
        MusicSource2.clip = MusicClip2;
        MusicSource3.clip = MusicClip3;
        MusicSource4.clip = MusicClip4;
        height = Camera.main.orthographicSize * 2.0f;
        width = height * Screen.width / Screen.height;
        netWidth = net.bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        red = (byte)Random.Range(0, 255);
        green = (byte)Random.Range(0, 255);
        blue = (byte)Random.Range(0, 255);

        if (score >= 10)
        {
            red2 = (byte)Random.Range(0, 255);
            green2 = (byte)Random.Range(0, 255);
            blue2 = (byte)Random.Range(0, 255);
        }

        if (score >= 20)
        {
            red3 = (byte)Random.Range(0, 255);
            green3 = (byte)Random.Range(0, 255);
            blue3 = (byte)Random.Range(0, 255);
        }

        if (score >= 30)
        {
            red4 = (byte)Random.Range(0, 255);
            green4 = (byte)Random.Range(0, 255);
            blue4 = (byte)Random.Range(0, 255);
        }

        score = num;
        PlayerPrefs.SetInt("Score", score);
        scoreText.text = score.ToString();

        PlayerPrefs.SetInt("Level", level);
        levelText.text = level.ToString();

        PlayerPrefs.SetInt("HighscoreLevel", highscoreLevel);

        if (ball2.sortingLayerName == "New Layer")
        {
            goal.GetComponent<PolygonCollider2D>().enabled = true;
        }

        if (ball.transform.position.y > -1)
        {
            scoreCheck.GetComponent<EdgeCollider2D>().enabled = false;
        }

        if ((ball.transform.position.y < -8 || ball.transform.position.x > 5 || ball.transform.position.x < -5)
            && temp != num)
        {
            if (score < 10)
            {
                num = 0;
                temp = 0;
            }
            if (score >= 10)
            {
                #if UNITY_ANDROID
                #elif UNITY_IPHONE
                    Device.RequestStoreReview();
                #endif
                num = 10;
                temp = 10;
            }
            if (score >= 20)
            {
                num = 20;
                temp = 20;
            }
            adCount++;
            if(adCount == 3)
            {
                AdTest.Instance.DisplayInterstitial();
                AdTest.Instance.createIad();
                adCount = 0;
            }
            highscoreMusic = true;
            MusicSource2.Play();
            basketball.color = new Color32(222, 101, 5, 255);
            net.color = new Color32(255, 255, 255, 255);
            Camera.main.backgroundColor = new Color32(255, 255, 248, 255);
            ballnet.gameObject.transform.position = new Vector3(0f, 2.474f, 0f);
            bar.gameObject.transform.position = new Vector3(0f, 1.9203f, 0f);
        }
        if (ball.transform.position.y < -8 || ball.transform.position.x > 5 || ball.transform.position.x < -5)
        {
            goal.GetComponent<PolygonCollider2D>().enabled = false;
            scoreCheck.GetComponent<EdgeCollider2D>().enabled = true;

        }
        if (num > PlayerPrefs.GetInt("Highscore", 0)) 
        {
            PlayerPrefs.SetInt("Highscore", num);
            highscoreText.text = num.ToString();
            if (highscoreMusic)
            {
                MusicSource4.Play();
                highscoreMusic = false;
            }
        }
        if (num > PlayerPrefs.GetInt("HighscoreLevel")){
            PlayerPrefs.SetInt("HighscoreLevel", num);
        }

        if (score >= 10 && score < 30)
        {
            if (moveNet == true)
            {
                if (ballnet.transform.position.x > -((width / 2) - (netWidth / 2)) && switchDirectionX == false)
                {
                    if (score < 20)
                    {
                        level = 2;
                        ballnet.gameObject.transform.position -= new Vector3(0.015f, 0f, 0f);
                        bar.gameObject.transform.position -= new Vector3(0.015f, 0f, 0f);
                    }
                    if (score >= 20)
                    {
                        level = 3;
                        ballnet.gameObject.transform.position -= new Vector3(0.025f, 0f, 0f);
                        bar.gameObject.transform.position -= new Vector3(0.025f, 0f, 0f);
                    }
                    if (ballnet.transform.position.x < -((width / 2) - (netWidth / 2)))
                    {
                        switchDirectionX = true;
                    }
                }
                if (ballnet.transform.position.x < ((width / 2) - (netWidth / 2)) && switchDirectionX == true)
                {
                    if (score < 20)
                    {
                        ballnet.gameObject.transform.position += new Vector3(0.015f, 0f, 0f);
                        bar.gameObject.transform.position += new Vector3(0.015f, 0f, 0f);
                    }
                    if (score >= 20)
                    {
                        ballnet.gameObject.transform.position += new Vector3(0.025f, 0f, 0f);
                        bar.gameObject.transform.position += new Vector3(0.025f, 0f, 0f);
                    }
                    if (ballnet.transform.position.x > ((width / 2) - (netWidth / 2)))
                    {
                        switchDirectionX = false;
                    }
                }
            }
        }
        if (score >= 30)
        {
            if (moveNet == true)
            {
                if (ballnet.transform.position.y > 1.8 &&
                    ballnet.transform.position.x > -((width / 2) - (netWidth / 2)) && 
                    switchDirectionX == true)
                {
                    if (score < 40)
                    {
                        level = 4;
                        ballnet.gameObject.transform.position -= new Vector3(0.015f, 0f, 0f);
                        bar.gameObject.transform.position -= new Vector3(0.015f, 0f, 0f);
                    }
                    if (score >= 40)
                    {
                        level = 5;
                        ballnet.gameObject.transform.position -= new Vector3(0.025f, 0f, 0f);
                        bar.gameObject.transform.position -= new Vector3(0.025f, 0f, 0f);
                    }
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
                    if (score < 40)
                    {
                        ballnet.gameObject.transform.position -= new Vector3(0f, 0.015f, 0f);
                        bar.gameObject.transform.position -= new Vector3(0f, 0.015f, 0f);
                    }
                    if (score >= 40)
                    {
                        ballnet.gameObject.transform.position -= new Vector3(0f, 0.025f, 0f);
                        bar.gameObject.transform.position -= new Vector3(0f, 0.025f, 0f);
                    }
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
                    if (score < 40)
                    {
                        ballnet.gameObject.transform.position += new Vector3(0.015f, 0, 0f);
                        bar.gameObject.transform.position += new Vector3(0.015f, 0, 0f);
                    }
                    if (score >= 40)
                    {
                        ballnet.gameObject.transform.position += new Vector3(0.025f, 0f, 0f);
                        bar.gameObject.transform.position += new Vector3(0.025f, 0f, 0f);
                    }
                    if(ballnet.transform.position.x > ((width / 2) - (netWidth / 2)))
                    {
                        switchDirectionY = true;
                        switchDirectionX = false;
                    }
                }
                if(ballnet.transform.position.y < 2.47 &&
                   ballnet.transform.position.x > (width / 2) - (netWidth / 2) &&
                   switchDirectionY == true)
                {
                    if (score < 40)
                    {
                        ballnet.gameObject.transform.position += new Vector3(0f, 0.015f, 0f);
                        bar.gameObject.transform.position += new Vector3(0f, 0.015f, 0f);
                    }
                    if (score >= 40)
                    {
                        ballnet.gameObject.transform.position += new Vector3(0f, 0.025f, 0f);
                        bar.gameObject.transform.position += new Vector3(0f, 0.025f, 0f);
                    }
                    if (ballnet.transform.position.y > 2.47f)
                    {
                        switchDirectionY = false;
                        switchDirectionX = true;
                    }
                }
            }
        }
    }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Bar")
            {
                basketball.color = new Color32(red, green, blue, 255);
                num++;
                if (num != 10 && num != 20)
                {
                    MusicSource.Play();
                }
                if (num == 10 || num == 20)
                {
                    MusicSource3.Play();
                }
                if (num >= 10)
                {
                    net.color = new Color32(red2, green2, blue2, 255);
                }
                if (num >= 20)
                {
                    Camera.main.backgroundColor = new Color32(red3, green3, blue3, 255);
                }
                if (num >= 30)
                {
                    scoreText.color = new Color32(red4, green4, blue4, 255);
                    levelText.color = new Color32(red4, green4, blue4, 255);
                    highscoreText.color = new Color32(red4, green4, blue4, 255);
                    levelTitle.color = new Color32(red4, green4, blue4, 255);
                    highScoreTitle.color = new Color32(red4, green4, blue4, 255);
                }
            }
            if (col.gameObject.tag == "ScoreCheck")
            {
                temp++;
            }
        }
    }
