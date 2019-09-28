using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AppLovinListener : MonoBehaviour
{
    public Button freeCoins;
    public Button freeCoinsTimer;
    public Text freeTimerText;
    public float timer;
    public bool startTimer = false;
    public int min;
    public int sec;
    DateTime currentDate;
    DateTime oldDate;
    public long temp;
    public float difference;

    void Start()
    {
        currentDate = System.DateTime.Now;
        temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));
        oldDate = DateTime.FromBinary(temp);
        difference = (float) currentDate.Subtract(oldDate).TotalSeconds;
        if(PlayerPrefs.GetFloat("CoinsTimer") > 0.00f)
        {
            PlayerPrefs.SetFloat("CoinsTimer", (PlayerPrefs.GetFloat("CoinsTimer") - difference));
            startTimer = true;
        }

        if (PlayerPrefs.GetFloat("CoinsTimer") > 0.00f)
        {
            startTimer = true;
        }
    }
    void onAppLovinEventReceived(string ev)
    {

        if (ev.Contains("HIDDENREWARDED"))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 5);
            PlayerPrefs.SetFloat("CoinsTimer", 3600);
            startTimer = true;
            AppLovin.LoadRewardedInterstitial();
        }
        if (ev.Contains("USERCLOSEDEARLY"))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 5);
        }
    }
    void Update()
    {
        freeCoinsTimer.interactable = false;
        min = Mathf.FloorToInt(PlayerPrefs.GetFloat("CoinsTimer") / 60);
        sec = Mathf.FloorToInt(PlayerPrefs.GetFloat("CoinsTimer") % 60);
        if (startTimer == true)
        {
            if (PlayerPrefs.GetFloat("CoinsTimer") > 0.00f)
            {
                freeCoins.gameObject.SetActive(false);
                freeCoinsTimer.gameObject.SetActive(true);
                freeTimerText.gameObject.SetActive(true);
                PlayerPrefs.SetFloat("CoinsTimer", PlayerPrefs.GetFloat("CoinsTimer") - Time.deltaTime);
                freeTimerText.text = min.ToString("00") + ":" + sec.ToString("00");
            }
            if (PlayerPrefs.GetFloat("CoinsTimer") <= 0.00f)
            {
                freeCoins.gameObject.SetActive(true);
                freeCoinsTimer.gameObject.SetActive(false);
                freeTimerText.gameObject.SetActive(false);
                startTimer = false;
            }
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
    }

}
