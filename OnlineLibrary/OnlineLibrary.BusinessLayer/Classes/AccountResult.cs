using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLibrary.BusinessLayer.Classes
{
    public class AccountResult
    {
        public bool Succeeded { get; }
        public string Token { get; }
        public string Error { get; }

        public AccountResult(bool succeeded, string token)
        {
            Succeeded = succeeded;
            Token = token;
        }

        public AccountResult(string error)
        {
            Error = error;
        }
    }
}
