using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Selenium Namespaces
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace Selenium_Demo_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Selenium to open up Firefox

            //Use GeckoDriver to resolve problems with Firefox
            //NB To Work copy the geckodriver.exe to the same directory as the project executable
            //....in this case /../Selenium Demo/bin/Debug

            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.demoqa.com";

            //Try other browsers
            //Install WebDriver.Chromedriver from Nuget packages manager by Selenium

            driver = new ChromeDriver();
            driver.Url = "http://toolsqa.com/";

            driver = new InternetExplorerDriver();
            driver.Url = "http://stackoverflow.com/";
        }
    }
}
