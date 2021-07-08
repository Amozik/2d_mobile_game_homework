using System;
using System.Drawing;
using System.Threading;
using Unity.Notifications.Android;
using Unity.Notifications.iOS;
using UnityEngine;
using Color = UnityEngine.Color;

namespace MobileGame.Notifications
{
    public class NotificationsService
    {
        private const string ANDROID_DEFAULT_CHANEL = "android_notifier_id";
        private const string IOS_ID = "ios_notifier_id";
        
        private static readonly Lazy<NotificationsService> _instance = 
            new Lazy<NotificationsService>(() => new NotificationsService(), LazyThreadSafetyMode.ExecutionAndPublication);
        
        public static NotificationsService Instance => _instance.Value;
        
        private NotificationsService()
        {
#if UNITY_ANDROID            
            var androidSettingsChanel = new AndroidNotificationChannel
            {
                Id = ANDROID_DEFAULT_CHANEL,
                Name = "Game Notifier",
                Importance =  Importance.High,
                CanBypassDnd = true,
                CanShowBadge = true,
                Description = "Common Chanel",
                EnableLights = true,
                EnableVibration = true,
                LockScreenVisibility = LockScreenVisibility.Public
            };
            
            AndroidNotificationCenter.RegisterNotificationChannel(androidSettingsChanel);
#endif            
        }

        public void Send(string text, Color? color = null)
        {
#if UNITY_ANDROID
            var androidSettingsNotification = new AndroidNotification
            {
                Title = "Cars game",
                Text = text,
                Color = color ?? Color.black,
            };

            AndroidNotificationCenter.SendNotification(androidSettingsNotification, ANDROID_DEFAULT_CHANEL);
#elif UNITY_IOS
            var iosSettingsNotification = new iOSNotification
            {
                Identifier = IOS_ID,
                Title = "Cars game",
                Body = text,
            };
      
            iOSNotificationCenter.ScheduleNotification(iosSettingsNotification);
#endif
        }
    }
}