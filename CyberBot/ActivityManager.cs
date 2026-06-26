using System;
using System.Collections.Generic;
using System.Text;

namespace CyberBot
{
    
        public class ActivityManager
        {
            private List<Activity> activities;

            public ActivityManager()
            {
                activities = new List<Activity>();
                AddActivity("Chatbot started.");
            }

            public void AddActivity(string description)
            {
                activities.Add(new Activity
                {
                    Time = DateTime.Now,
                    Description = description
                });
            }

            public string GetActivityLog()
            {
                if (activities.Count == 0)
                {
                    return "No activities recorded.";
                }

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("===== Cyberbot Activity Log =====");
                sb.AppendLine();

                foreach(Activity activity in activities)
                {
                    sb.AppendLine($"{activity.Time:HH:mm:ss} - {activity.Description}");
                }

                return sb.ToString();
            }
        }
    
}
