using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace HW7Project.Models
{
    public class GitAPI
    {
        public string Source { get; set; }
        public string GitToken { get; set; }
        public string Username { get; set; }
        public GitAPI(string endpoint, string credentials, string username)
        {
            Source = endpoint;
            GitToken = credentials;
            Username = username;
        }
        public User getUserData()
        {
            string jsonResponse = SendRequest(Source, GitToken, Username);
            JObject data = JObject.Parse(jsonResponse);

            User user = (new User { Username = (string)data["login"],
                                    AvatarURL = (string)data["avatar_url"],
                                    HtmlURL = (string)data["html_url"],
                                    Name = (string)data["name"],
                                    Company = (string)data["company"],
                                    Location = (string)data["location"],
                                    Email = (string)data["email"]});
            

            return user;
        }

        private static string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }
    
    }
}
