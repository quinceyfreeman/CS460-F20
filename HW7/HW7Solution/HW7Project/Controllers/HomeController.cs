﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW7Project.Models;
using Microsoft.Extensions.Configuration;

namespace HW7Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        public IActionResult GitUser()
        {
            GitAPI user = new GitAPI("https://api.github.com/user",_config["AJAX:GitToken"], "quinceyfreeman");
            User data = user.getUserData();
            return Json(data);
        }
        public IActionResult GitRepositories()
        {
            GitAPI repos = new GitAPI("https://api.github.com/user/repos",_config["AJAX:GitToken"], "quinceyfreeman");
            IEnumerable<Repository> repositories = repos.getUserRepos();
            return Json(repositories);
        }
        public IActionResult GitCommits(string user, string repo)
        {
            string url = "https://api.github.com/repos/" + user + "/" + repo + "/commits";
            GitAPI repos = new GitAPI(url,_config["AJAX:GitToken"], "quinceyfreeman");
            IEnumerable<Commit> commits = repos.getCommits();
            return Json(commits);
        }
        public IActionResult Index()
        {
            var model = new ViewModel();
            GitAPI user = new GitAPI("https://api.github.com/user",_config["AJAX:GitToken"], "quinceyfreeman");
            GitAPI repos = new GitAPI("https://api.github.com/user/repos",_config["AJAX:GitToken"], "quinceyfreeman");

            model.UserData = user.getUserData();
            model.Repositories = repos.getUserRepos();
            
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
