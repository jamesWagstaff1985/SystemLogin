using System;
using System.Collections.Generic;

namespace SystemLogin.Model
{
    public class DataHandling
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool checkLogin()
        {
            var validData = new Dictionary<string, string>()
            {
                {"sergio", "mypassword" },    
                {"denis", "hispassword" },
                {"john", "wayne"},
                {"james", "jammmy" }
            };

            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
                return false;
            var userName = UserName.ToLowerInvariant();
            return validData.ContainsKey(userName) && validData[userName] == Password.ToLowerInvariant();
        }
    }
}
