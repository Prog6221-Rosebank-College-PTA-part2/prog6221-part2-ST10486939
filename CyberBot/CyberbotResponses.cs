using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CyberBot
{
    public class CyberbotResponses
    {
        //QUIZ VARIABLES
        private bool quizActive = false;
        private int currentQuestion = 0;
        private int score = 0;

        //questions
        private List<string> quizQuestions = new List<string>
        {
            //1
            "True or false: Sharing your password with friends is safe",
            //2
            "Which is a phishing attack?" +
            "\nA) Fake email asking for you password" +
            "\nB) Updating windows" +
            "\nC) Using a VPN" +
            "\nD) Creating a strong password",
            //3
            "True or False: Two-factor authentication imrpoves security.",
            //4
            "What does VPN stand for?" +
            "\nA) Virtual Password Network" +
            "\nB) Virtual Private Network" +
            "\nC) Verified Public Network" +
            "\nD) Virtual Protection Node",
            //5
            "True or False: Clicking unknown links can be dangerous.",
            //6
            "Which one of these is the best example of multi-factor authentication" +
            "\nA) Username + a long password" +
            "\nB) Password + a one-time code sent to your phone" +
            "\nC) Security question + your date of birth" +
            "\nD) PIN + fingerprint scan on the same device",
            //7
            "True or False: Using the same password for all your accounts is safe",
            //8
            "Under POPIA, what must a South African company do within 72 hours if personal info gets breached?" +
            "\nA) Post about it on social media" +
            "\nB) Notify the Information Regulator and affected data subjects" +
            "\nC) Change all passwords in the company" +
            "\nD) Wait until their annual audit to report it",
            //9
            "True or False: Multi-factor authentication adds an extra layer of security by requiring two or more forms of proof to login",
            //10
            "True or False: Under POPIA, organisations can share your personal info with any other company as long as it's for 'business purposes'"
        };

        private List<string> quizAnswers = new List<string>
        {
            //1
            "false",
            //2
            "a",
            //3
            "true",
            //4
            "b",
            //5
            "true",
            //6
            "b",
            //7
            "false",
            //8
            "b",
            //9
            "true",
            //10
            "false"
        };

        //TASKMANAGER
        private TaskManager taskManager = new TaskManager();

        //PHISHING TIPS LIST
        private List<string> phishingTips = new List<string>
        {
            "Avoid clicking on suspicious email links.",
            "Make sure to always verify the sender's email address.",
            "Never download unexpected attachments.",
            "Enable multi-factor authentication for extra security."
        };

        //SENTIMENT LISTS
        private List<string> worry = new List<string>
        {
            "worried",
            "scared",
            "afraid",
            "nervous",
            "anxious"
        };
        private List<string> curiosity = new List<string>
        {
            "curious",
            "interested",
            "wondering"
        };

        //MEMORY 
        private string lastTopic = "";
        private int lastPhishingTipIndex = -1;

        //RANDOM OBJECT
        private Random random = new Random();

        //SENTIMENT METHOD
        private string SentimentDetection(string userInput)
        {
            foreach (string word in worry)
            {
                if (userInput.Contains(word))
                {
                    return "worried";
                }
            }

            foreach (string word in curiosity)
            {
                if (userInput.Contains(word))
                {
                    return "curios";
                }
            }

            return "neutral";
        }

        

        //CYBERBOT RESPONSES
        public string GetResponse(string userInput, string userName)
        {
            userInput = userInput.ToLower().Trim();

            //QUIZ ANSWERS
            if (quizActive)
            {
                string response = "";

                if (userInput == quizAnswers[currentQuestion])
                {
                    score++;
                    response = "Correct!\n\n";
                }
                else
                {
                    response = $"Incorrect. The correct answer was: {quizAnswers[currentQuestion]}\n\n";
                }

                currentQuestion++;

                if (currentQuestion >= quizQuestions.Count)
                {
                    quizActive = false;

                    response += $"Quiz Complete!\n" +
                                $"Final Score: {score}/{quizQuestions.Count}";

                    return response;
                }
                return response + quizQuestions[currentQuestion];
            }

            //start quiz
            if (userInput == "start quiz")
            {
                quizActive = true;
                currentQuestion = 0;
                score = 0;

                return "Cybersecurity Quiz Started!\n\n" + quizQuestions[currentQuestion];
            }

            //SENTIMENT DETECTION
            string sentiment = SentimentDetection(userInput);

           
            //Detect task requests
            if (userInput.StartsWith("add task") ||
                userInput.StartsWith("create task") ||
                userInput.StartsWith("remind me to"))
            {
                return CreateNaturalTask(userInput);
            }


            //PASSWORDS
            if (userInput.Contains("password"))
            {
                lastTopic = "password";

                if (sentiment == "worried")
                {
                    return "Strong passwords are one of the best ways to protect your sensitive information.";
                }
                else if (sentiment == "curious")
                {
                    return userName + ", your password should never be guessable and should have at least 12 characters and include " +
                        "uppercase and lowercase letters, numbers and special symbols.";
                }
                return userName + ", always remember to use a strong password to protect your sensitive information";
            }
            //SAFE BROWSING
            else if (userInput.Contains("browsing"))
            {
                lastTopic = "browsing";

                return "Safe browsing starts with awareness, " + userName + ". Use a strong, unique password for every account. Be cautious " +
                    "with links and attachments. Pay attention to a website's credibility.";
            }
            //PHISHING TIPS
            else if (userInput == "phishing tip")
            {
                int index = random.Next(phishingTips.Count);

                lastPhishingTipIndex = index;
                lastTopic = "phishing tip";

                return userName + " here is a phishing tip: " + phishingTips[index];
            }
            //PHISHING
            else if (userInput.Contains("phishing"))
            {
                lastTopic = "phishing";

                if (sentiment == "worried")
                {
                    return "I understand your concern, " + userName + ". Phishing scams can be dangerous as it could lead to attackers " +
                        "having your private information.";
                }
                else if (sentiment == "curious")
                {
                    return "Great question, " + userName + "! Phishing is a cyber attck that uses fraudulent emails, text messages, phone " +
                        "calls or websites to trick people into sharing sensitive information.";
                }
                return "Be careful, " + userName + ". Phishing scams trick users into revealing sensitivr information.";
            }
            //ADD INFORMATION
            else if (userInput.Contains("tell me more") || userInput.Contains("more information"))
            {
                if (lastTopic == "password")
                {
                    return "Try to use different passwords for different accounts in case any of your accounts are compromised, the other accounts" +
                        " wont be at risk.";
                }
                else if (lastTopic == "browsing")
                {
                    return "When browsing the web, ensure to use a VPN and try to not make use of the 'remember my password' function.";
                }
                else if (lastTopic == "phishing")
                {
                    return "To avoid phishing scams, check the spelling and grammar, check if there is an urgent call to action or threats.";
                }
            }
            //ADDITIONAL TIP
            else if (userInput.Contains("another tip"))
            {
                int index;

                do
                {
                    index = random.Next(phishingTips.Count);
                } while (index == lastPhishingTipIndex);

                lastPhishingTipIndex = index;

                return "Here is another phishing tip: " + phishingTips[index];
            }
            //Parse task input
            else if(userInput.Contains("|"))
            {
                string[] parts = userInput.Split("|");

                if(parts.Length >= 2)
                {
                    string title = parts[0].Trim();
                    string description = parts[1].Trim();
                    DateTime? reminder = null;

                    if(parts.Length >= 3)
                    {
                        DateTime date;

                        if (DateTime.TryParse(parts[2].Trim(), out date))
                        {
                            reminder = date;
                        }
                    }

                    taskManager.AddTask(title, description, reminder);

                    return "Task added successfully.";
                }
            }
            //display tasks
            else if(userInput == "show tasks")
            {
                var tasks = taskManager.GetTasks();

                if(tasks.Count ==0)
                {
                    return "No cybersecurity tasks found.";
                }

                string response = "Cybersecurity Tasks: \n\n";

                foreach(var task in tasks)
                {
                    response += $"{task.TaskId}. {task.Title}\n";

                    response += $"Description: {task.Description}\n";

                    response += $"Status: {task.Status}\n";

                    if (task.ReminderDate != null)
                    {
                        response += $"Reminder: {task.ReminderDate:d}\n";
                    }
                    response += "\n";
                }
                return response;
            }
            //DEFAULT RESPONSE
            else
            {
                return "I'm not sure about that. Try asking another question related to cybersecurity or type 'bye' to end our conversation.";
            }

            return "Could you please specify which topic you want more information about?";
        }

        private string CreateNaturalTask(string userInput)
        {
            string title = userInput;

            title = title.Replace("add task", "");
            title = title.Replace("create task", "");
            title = title.Replace("remind me to", "");

            title = title.Trim();

            DateTime? reminder = null;

            if(title.Contains("tomorrow"))
            {
                reminder = DateTime.Today.AddDays(1);
                title = title.Replace("tomorrow", "").Trim();
            }
            else if (title.Contains("next week"))
            {
                reminder = DateTime.Today.AddDays(7);
                title = title.Replace("next week", "").Trim();
            }
            else if (title.Contains("next month"))
            {
                reminder = DateTime.Today.AddMonths(1);
                title = title.Replace("next month", "").Trim();
            }

            taskManager.AddTask(title, $"Cybersecurity task: {title}", reminder);

            return $"Task added successfully.\n\n" +
                    $"Title: {title}\n" +
                    $"Reminder: {(reminder.HasValue ? reminder.Value.ToShortDateString() : "None")}";
        }
    }
}
