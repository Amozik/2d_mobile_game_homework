using System.Collections.Generic;
#if ENABLE_CLOUD_SERVICES_ANALYTICS
using UnityEngine.Analytics;
#endif

namespace MobileGame.Analytic
{
    public class UnityAnalyticTools : IAnalyticTools
    {
        public void SendMessage(string eventName, IDictionary<string, object> eventData = null)
        {
            eventData ??= new Dictionary<string, object>();
#if ENABLE_CLOUD_SERVICES_ANALYTICS
            Analytics.CustomEvent(eventName, eventData);
#else
            Debug.Log("eventName")
#endif
        }
    }
}