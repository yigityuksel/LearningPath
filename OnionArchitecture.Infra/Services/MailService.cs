﻿using System;
using OnionArchitecture.Core.Interfaces.Services;

namespace OnionArchitecture.Infra.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(string willSendMailAddress, string content)
        {
            Console.WriteLine($"The mail has been sended");
            return true;
        }
    }
}