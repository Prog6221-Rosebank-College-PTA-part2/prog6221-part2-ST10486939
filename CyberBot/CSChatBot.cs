using System;
using System.Collections.Generic;

namespace CyberBot
{
    public class CSChatBot
    {
        private CyberbotResponses cyberbotResponses = new CyberbotResponses();

        public string GetResponse(string userInput, string userName)
        {
            return cyberbotResponses.GetResponse(userInput, userName);
        }
    }
}