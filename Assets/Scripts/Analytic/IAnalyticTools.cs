using System.Collections.Generic;

namespace MobileGame.Analytic
{
    public interface IAnalyticTools
    {
        void SendMessage(string eventName, IDictionary<string, object> eventData = null);
    }
}