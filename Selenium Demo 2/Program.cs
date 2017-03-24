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

            /*IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.demoqa.com";

            //Try other browsers
            //Install WebDriver.Chromedriver from Nuget packages manager by Selenium

            driver = new ChromeDriver();
            driver.Url = "http://toolsqa.com/";

            driver = new InternetExplorerDriver();
            driver.Url = "http://stackoverflow.com/";*/

            //TOOLS QA Test Eg

            //Launch the Firefox Browser
            IWebDriver driver = new FirefoxDriver();

            //Open a webpage
            driver.Url = "http://www.demoqa.com";

            //Get the page title and page length
            string Title = driver.Title;
            int length = Title.Length;

            //Display length to screen
            Console.WriteLine("Title: " + Title + " Length: " + length);

            //Display the URL and the URL length to screen
            Console.WriteLine("URL: " + driver.Url.ToString() + " URL Length: " + driver.Url.ToString().Length);

            String source = driver.PageSource; //Store the HTML source

            //Print out the source length
            Console.WriteLine("Source Length: " + source.Length);

            //Close all instances associated with the driver for the browser
            //driver.Quit();

            //Inspect some HTML and click on an element
            driver.FindElement(By.XPath(".//*[@id='tabs-1']/div/p/a")).Click();

        }
    }
}
