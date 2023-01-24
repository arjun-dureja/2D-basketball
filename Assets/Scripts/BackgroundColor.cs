using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_ANDROID
#elif UNITY_IPHONE
    using UnityEngine.SocialPlatforms.GameCenter;
#endif

public class BackgroundColor : MonoBehaviour
{
    public Image background;
    public byte r = 255;
    public byte b = 4;
    public byte g = 4;
    public Image ball;
    public Image net;
    public Image floor;
    public Button play;
    public Button leaderboard;
    public Button rate;
    public Button classic;
    public Button time;
    public Button hard;
    public Button back;
    public Button customize;
    public Animator animator;
    public Rigidbody2D rotateBall;
    public int mode;

    public Sprite[] ballSkins;
    public Sprite basketBall;
    public Sprite tennisBall;
    public Sprite soccerBall;
    public Sprite bowlingBall;
    public Sprite volleyBall;

    public Sprite[] netSkins;
    public Sprite netOne;
    public Sprite netTwo;
    public Sprite netThree;
    public Sprite netFour;
    public Sprite netFive;

    public Sprite[] floorSkins;
    public Sprite floorOne;
    public Sprite floorTwo;
    public Sprite floorThree;
    public Sprite floorFour;
    public Sprite floorFive;

    public Material ballMaterial;

    void Start()
    {
        if (PlayerPrefs.HasKey("BallAvailability") && PlayerPrefs.HasKey("NetAvailability") && PlayerPrefs.HasKey("FloorAvailability")) { }
        else
        {
            PlayerPrefs.SetInt("BallAvailability", 1);
            PlayerPrefs.SetInt("NetAvailability", 1);
            PlayerPrefs.SetInt("FloorAvailability", 1);
        }

        ballSkins = new Sprite[5];
        ballSkins[0] = basketBall;
        ballSkins[1] = tennisBall;
        ballSkins[2] = soccerBall;
        ballSkins[3] = bowlingBall;
        ballSkins[4] = volleyBall;
        ball.sprite = ballSkins[PlayerPrefs.GetInt("CurrentBall")];

        netSkins = new Sprite[5];
        netSkins[0] = netOne;
        netSkins[1] = netTwo;
        netSkins[2] = netThree;
        netSkins[3] = netFour;
        netSkins[4] = netFive;
        net.sprite = netSkins[PlayerPrefs.GetInt("CurrentNet")];

        floorSkins = new Sprite[5];
        floorSkins[0] = floorOne;
        floorSkins[1] = floorTwo;
        floorSkins[2] = floorThree;
        floorSkins[3] = floorFour;
        floorSkins[4] = floorFive;
        floor.sprite = floorSkins[PlayerPrefs.GetInt("CurrentFloor")];
        Time.timeScale = 1;
        Button playBtn = play.GetComponent<Button>();
        playBtn.onClick.AddListener(PlayButtonClick);

        Button leaderboardBtn = leaderboard.GetComponent<Button>();
        leaderboardBtn.onClick.AddListener(LeaderboardButtonClick);

        Button rateBtn = rate.GetComponent<Button>();
        rateBtn.onClick.AddListener(RateButtonClick);

        Button classicBtn = classic.GetComponent<Button>();
        classic.onClick.AddListener(ClassicButtonClick);

        Button timeBtn = time.GetComponent<Button>();
        time.onClick.AddListener(TimeButtonClick);

        Button hardBtn = hard.GetComponent<Button>();
        hard.onClick.AddListener(HardButtonClick);

        Button backBtn = back.GetComponent<Button>();
        back.onClick.AddListener(BackButtonClick);

        Button customizeBtn = customize.GetComponent<Button>();
        customize.onClick.AddListener(CustomizeButtonClick);

#if UNITY_ANDROID
            leaderboardBtn.gameObject.SetActive(false);
#elif UNITY_IPHONE
        Social.localUser.Authenticate(ProcessAuthentication);
#endif

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Time.fixedDeltaTime = 0.005f;

        rotateBall.freezeRotation = false;
        rotateBall.transform.Rotate(0, 0, -50 * Time.deltaTime);
        if (r == 255 && g < 255 && b == 4)
        {
            g++;
            ballMaterial.color = (new Color32(r, g, b, 255));
        }
        if (r > 4 && g == 255 && b == 4)
        {
            r--;
            ballMaterial.color = (new Color32(r, g, b, 255));
        }
        if (r == 4 && g == 255 && b < 255)
        {
            b++;
            ballMaterial.color = (new Color32(r, g, b, 255));
        }
        if (r == 4 && g > 4 && b == 255)
        {
            g--;
            ballMaterial.color = (new Color32(r, g, b, 255));
        }
        if (r < 255 && g == 4 && b == 255)
        {
            r++;
            ballMaterial.color = (new Color32(r, g, b, 255));
        }
        if (r == 255 && g == 4 && b > 4)
        {
            b--;
            ballMaterial.color = (new Color32(r, g, b, 255));
        }
    }

    void PlayButtonClick()
    {
        play.gameObject.SetActive(false);
        rate.gameObject.SetActive(false);
        leaderboard.gameObject.SetActive(false);
        customize.gameObject.SetActive(false);
        classic.gameObject.SetActive(true);
        time.gameObject.SetActive(true);
        hard.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
    }

    void LeaderboardButtonClick()
    {
#if UNITY_ANDROID

#elif UNITY_IPHONE
        GameCenterPlatform.ShowLeaderboardUI("com.ArjunDureja.Basketball2D", UnityEngine.SocialPlatforms.TimeScope.AllTime);
        ReportScore(PlayerPrefs.GetInt("Highscore"), "com.ArjunDureja.Basketball2D");
        ReportScore(PlayerPrefs.GetInt("TimeChallengeScore"), "time_challenge_score");
        ReportScore(PlayerPrefs.GetInt("HardModeScore"), "hard_mode_score");
#endif
    }

    void RateButtonClick()
    {
    #if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.ArjunDureja.Basketball2D");
    #elif UNITY_IPHONE
        Application.OpenURL("itms-apps://itunes.apple.com/app/id1426185582");
    #endif
    }

    void CustomizeButtonClick()
    {
        SceneManager.LoadScene(4);
    }

    void ClassicButtonClick()
    {
        mode = 0;
        animator.SetTrigger("Fade");
    }

    void TimeButtonClick()
    {
        mode = 3;
        animator.SetTrigger("Fade");
    }

    void HardButtonClick()
    {
        mode = 2;
        animator.SetTrigger("Fade");
    }

    void BackButtonClick()
    {
        play.gameObject.SetActive(true);
        rate.gameObject.SetActive(true);
        customize.gameObject.SetActive(true);
        classic.gameObject.SetActive(false);
        time.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        #if UNITY_ANDROID

        #elif UNITY_IPHONE
            leaderboard.gameObject.SetActive(true);
        #endif
    }

    void ProcessAuthentication(bool success)
    {
        if (success)
        {
            Debug.Log("success");

        }
        else
            Debug.Log("Failed to authenticate");
    }

    void ReportScore(int score, string leaderboardID)
    {

        Social.ReportScore(score, leaderboardID, success =>
        {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });
    }

    public void GameStarter()
    {
        if (mode == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if (mode == 2)
        {
            SceneManager.LoadScene(2);
        }
        else if (mode == 3)
        {
            SceneManager.LoadScene(3);
        }

    }

}
