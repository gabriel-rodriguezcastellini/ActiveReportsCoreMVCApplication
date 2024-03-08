using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace ActiveReportsCoreMVCApplication
{
    [Route("/")]
    public class HomeController : Controller
    {
        public object Index() => View("Index");

    }
}
