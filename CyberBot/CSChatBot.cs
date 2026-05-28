using System;
using System.Collections.Generic;

namespace CyberBot
{
    public class CSChatBot
    {
        //PHISHING TIPS LIST
        private List<string> phishingTips = new List<string>
        {
            "Avoid clicking on suspicious email links.",
            "Make sure to always verify the sender's email address.",
            "Never download unexpected attachments.",
            "Enable multi-factor authentication for extra security."
        };

        //RANDOM OBJECT
        private Random random = new Random();

        //CYBERBOT RESPONSES
        public string GetResponse(string userInput, string userName)
        {
            userInput = userInput.ToLower().Trim();

            //PASSWORDS
            if (userInput.Contains("password"))
            {
                return userName + ", your password should never be guessable. A strong password should have at least 12 characters " +
                    "and include uppercase and lowercase letters, numbers and special symbols.";
            }
            //SAFE BROWSING
            else if (userInput.Contains("browsing"))
            {
                return "Safe browsing starts with awareness, " +userName+ ". Use a strong, unique password for every account. Be cautious " +
                    "with links and attachments. Pay attention to a website's credibility.";
            }
            //PHISHING TIPS
            else if (userInput == "phishing tip")
            {
                int index = random.Next(phishingTips.Count);

                return userName + " here is a phishing tip: " + phishingTips[index];
            }
            //PHISHING
            else if (userInput.Contains("phishing"))
            {
                return "Phishing is a cyber attack that uses fraudulent emails, text messages, phone calls or websites to trick people into " +
                    "sharing sensitive information.";
            }
            else
            {
                return "I'm not sure about that. Try asking another question related to cybersecurity or type 'bye' to end our conversation.";
            }
        }
    }
}