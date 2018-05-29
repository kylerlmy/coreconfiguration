using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OptionsBindConfig.Controllers
{
    public class HomeController : Controller
    {
        private readonly Class _myClass;

        //public HomeController(IOptions<Class> options)
        //{
        //    _myClass = options.Value;
        //}

        //实现配置热更新
        public HomeController(IOptionsSnapshot<Class> options)
        {
            _myClass = options.Value;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_myClass);
        }


        //在view层进行注入
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
