#if UNITY_ANDROID
#elif UNITY_IPHONE
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using NotificationServices = UnityEngine.iOS.NotificationServices;
using NotificationType = UnityEngine.iOS.NotificationType;
using System;
public class Notifications : MonoBehaviour
{
    bool tokenSent;
    public int sendNotif;

    void Start()
    {
        sendNotif = 7;
        tokenSent = false;

        NotificationServices.RegisterForNotifications(
            NotificationType.Alert |
            NotificationType.Badge |
            NotificationType.Sound);
    }

    void Update()
    {
        if (!tokenSent)
        {
            byte[] token = NotificationServices.deviceToken;
            if (token != null)
            {
                // send token to a provider
                string hexToken = "%" + System.BitConverter.ToString(token).Replace('-', '%');
                UnityWebRequest.Get("http:/example.com?token=" + hexToken).SendWebRequest();
                tokenSent = true;
            }
        }
        if (UnityEngine.iOS.NotificationServices.localNotificationCount > 0)
        {
            Debug.Log(UnityEngine.iOS.NotificationServices.localNotifications[0].alertBody);
            UnityEngine.iOS.NotificationServices.ClearLocalNotifications();
        }
    }

    void OnApplicationQuit()
    {
        UnityEngine.iOS.LocalNotification notif = new UnityEngine.iOS.LocalNotification();
        notif.fireDate = DateTime.Now.AddDays(sendNotif);
        notif.alertBody = "Come back and play some 2D Basketball!";
        UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(notif);
    }
}
#endif