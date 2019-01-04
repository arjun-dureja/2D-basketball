using System.Collections;
using System.Collections.Generic;
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
    public Button play;
    public Button leaderboard;
    public Button rate;
    public Animator animator;


    void Start()
    {
        Time.timeScale = 1;
        Button playBtn = play.GetComponent<Button>();
        playBtn.onClick.AddListener(TaskOnClick);

        Button leaderboardBtn = leaderboard.GetComponent<Button>();
        leaderboardBtn.onClick.AddListener(TaskOnClick2);

        Button rateBtn = rate.GetComponent<Button>();
        rateBtn.onClick.AddListener(TaskOnClick3);

        #if UNITY_ANDROID
        #elif UNITY_IPHONE
            Social.localUser.Authenticate(ProcessAuthentication);
        #endif

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Time.fixedDeltaTime = 0.005f;

        if (r == 255 && g < 255 && b == 4)
        {
            g++;
            ball.color = (new Color32(r, g, b, 100));
        }
        if (r > 4 && g == 255 && b == 4)
        {
            r--;
            ball.color = (new Color32(r, g, b, 100));
        }
        if (r == 4 && g == 255 && b < 255)
        {
            b++;
            ball.color = (new Color32(r, g, b, 100));
        }
        if (r == 4 && g > 4 && b == 255)
        {
            g--;
            ball.color = (new Color32(r, g, b, 100));
        }
        if (r < 255 && g == 4 && b == 255)
        {
            r++;
            ball.color = (new Color32(r, g, b, 100));
        }
        if (r == 255 && g == 4 && b > 4)
        {
            b--;
            ball.color = (new Color32(r, g, b, 100));
        }
    }

    void TaskOnClick()
    {
        animator.SetTrigger("Fade");
    }

    void TaskOnClick2()
    {
        #if UNITY_ANDROID
        #elif UNITY_IPHONE
            GameCenterPlatform.ShowLeaderboardUI("com.ArjunDureja.Basketball2D", UnityEngine.SocialPlatforms.TimeScope.AllTime);
            ReportScore(PlayerPrefs.GetInt("Highscore"), "com.ArjunDureja.Basketball2D"); 
#endif
    }

    void TaskOnClick3()
    {
        #if UNITY_ANDROID
            Application.OpenURL("market://details?id=com.ArjunDureja.Basketball2D");
        #elif UNITY_IPHONE
            Application.OpenURL("itms-apps://itunes.apple.com/app/id1426185582");
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
        
        Social.ReportScore(score, leaderboardID, success => {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });
    }

    public void GameStarter()
    {
        SceneManager.LoadScene(1);
    }

}
