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
        public IEnumerable<Repository> getUserRepos()
        {
            string json = SendRequest(Source, GitToken, Username);
            JToken data = JToken.Parse(json);
            List<Repository> output = new List<Repository>();
            int count = data.Count();
            for (int i = 0; i < count; i++)
            {
                output.Add(new Repository { Name = (string)data[i]["name"],
                                            Owner = (string)data[i]["owner"]["login"],
                                            HtmlURL = (string)data[i]["html_url"],
                                            FullName = (string)data[i]["full_name"],
                                            OwnerAvatarURL = (string)data[i]["owner"]["avatar_url"],
                                            LastUpdated = (DateTime)data[i]["pushed_at"]});
            }

            return output;
        }
        public IEnumerable<Commit> getCommits()
        {
            string json = SendRequest(Source, GitToken, Username);
            JToken data = JToken.Parse(json);
            List<Commit> output = new List<Commit>();
            int count = data.Count();
            for (int i = 0; i < count; i++)
            {
                output.Add(new Commit { Sha = (string)data[i]["sha"],
                                        Committer = (string)data[i]["commit"]["committer"]["name"],
                                        WhenCommitted = (DateTime)data[i]["commit"]["committer"]["date"],
                                        CommitMessage = (string)data[i]["commit"]["message"],
                                        HtmlURL = (string)data[i]["html_url"]});
            }

            return output;
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
