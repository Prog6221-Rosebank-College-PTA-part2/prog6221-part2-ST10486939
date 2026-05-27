using System;
using System.Collections.Generic;

namespace CyberBot
{
    public class CSChatBot
    {
        

        //RANDOM OBJECT
        private Random random = new Random();

        //CYBERBOT RESPONSES 
        public string GetResponse(string userInput, string userName)
        {
            userInput = userInput.ToLower().Trim();

            //CHATBOT GREETING
            if(userInput.Contains("hello") || userInput.Contains("hi"))
            {
                return "Hello " + userName + "! How can I help you stay safe online?";
            }

            //GENERIC QUESTIONS
            else if(userInput.Contains("how are you"))
            {
                return "I am excited to teach you how to be safe online";
            }

            else if(userInput.Contains("what is your purpose"))
            {
                return "My purpose is to teach you about cybersecurity so you can stay safe whilst online.";
            }

            //PASSWORD SAFETY
            else if (userInput.Contains("password"))
            {
                return userName + ", your password should never be easily guessable. A strong password has at least 12 characters " +
                    "that includes upper and lowercase letters, numbers and special symbols.";
            }


            //PHISHING
            else if(userInput.Contains("phishing"))
            {
                return "Phishing is a cyber attck that uses fraudulent emails, text messages, phone calls, or websites to trick people " +
                    "into sharing sensitive information.";
            }

            //SAFE BROWSING
            else if(userInput.Contains("browsing"))
            {
                return "Safe browsing starts with awareness. " + userName + ", use a strong unique password for every account. Be cautious" +
                    " with links and attchments. Pay attention to websites credibility.";
            }

            //GOODBYE
            else if (userInput.Contains("bye"))
            {
                return "Goodbye " + userName + "! I hope you stay safe online.";
            }

            else
            {
                return "I'm not sure about that. Try asking another question related to cybersecurity or type 'bye' to end our conversation.";
            }
        }
    }
}