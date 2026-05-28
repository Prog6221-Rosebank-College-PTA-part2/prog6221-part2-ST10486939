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

        //MEMORY VARIABLES
        private string lastTopic = "";
        private int lastPhishingTipIndex = -1;

        //CYBERBOT RESPONSES
        public string GetResponse(string userInput, string userName)
        {
            userInput = userInput.ToLower().Trim();

            //PASSWORDS
            if (userInput.Contains("password"))
            {
                lastTopic = "password";

                return userName + ", your password should never be guessable. A strong password should have at least 12 characters " +
                    "and include uppercase and lowercase letters, numbers and special symbols.";
            }
            //SAFE BROWSING
            else if (userInput.Contains("browsing"))
            {
                lastTopic = "browsing";

                return "Safe browsing starts with awareness, " +userName+ ". Use a strong, unique password for every account. Be cautious " +
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

                return "Phishing is a cyber attack that uses fraudulent emails, text messages, phone calls or websites to trick people into " +
                    "sharing sensitive information.";
            }
            //ADD INFORMATION
            else if(userInput.Contains("tell me more") || userInput.Contains("more information"))
            {
                if(lastTopic == "password")
                {
                    return "Try to use different passwords for different accounts in case any of your accounts are compromised, the other accounts" +
                        " wont be at risk.";
                }
                else if(lastTopic == "browsing")
                {
                    return "When browsing the web, ensure to use a VPN and try to not make use of the 'remember my password' function.";
                }
                else if(lastTopic == "phishing")
                {
                    return "To avoid phishing scams, check the spelling and grammar, check if there is an urgent call to action or threats.";
                }
            }
            //ADDITIONAL TIP
            else if(userInput.Contains("another tip"))
            {
                int index;

                do
                {
                    index = random.Next(phishingTips.Count);
                } while (index == lastPhishingTipIndex);

                lastPhishingTipIndex = index;

                return "Here is another phishing tip: " + phishingTips[index];
            }
            //DEFAULT RESPONSE
            else
            {
                return "I'm not sure about that. Try asking another question related to cybersecurity or type 'bye' to end our conversation.";
            }

            return "Could you please specify which topic you want more information about?";
        }
    }
}