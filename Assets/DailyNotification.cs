using System;
using UnityEngine;
using Unity.Notifications.Android;

public class DailyNotification : MonoBehaviour
{
    private string[] notificationMessages = new string[]
    {
        "Raise your IQ!",
        "The next puzzles will surprise you.",
        "The difficulty level increases the further you go!",
        "Have you solved the hidden level yet?"
    };

    void Start()
    {
        ScheduleDailyNotification();
    }

    void ScheduleDailyNotification()
    {
        AndroidNotificationCenter.CancelAllScheduledNotifications();

        var notificationChannel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        // Pobierz losowy tekst z listy
        string message = notificationMessages[UnityEngine.Random.Range(0, notificationMessages.Length)];

        // Ustaw czas powiadomienia na 19:00 lokalnego czasu
        var notificationTime = DateTime.Today.AddHours(19);
        if (notificationTime < DateTime.Now)
        {
            notificationTime = notificationTime.AddDays(1);
        }

        // Utwórz powiadomienie
        var notification = new AndroidNotification
        {
            Title = "Train your brain",
            Text = message,
            SmallIcon = "small",
            LargeIcon = "large",
            FireTime = notificationTime,
            RepeatInterval = new TimeSpan(24, 0, 0)
        };

        // Wyślij powiadomienie
        AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }
}
