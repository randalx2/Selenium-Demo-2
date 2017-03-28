using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;


//Selenium Namespaces
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

//Special Support Classes for Selenium from Selenium.support package
using OpenQA.Selenium.Support.UI;

//Namespaces for getting the executable paths of the running processes
using System.IO;

namespace Selenium_Demo_2
{
    
    class Program
    {
        //Globals
        static IWebDriver driver = new FirefoxDriver();

        //Method used to check if element exists
        static bool isElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException e)
            {
                //MessageBox.Show(e.Message + "\n Could not find required element");
                return false;
            }
        }

        //Method to check for alerts
        /** static IAlert isAlertPresent()
         {
             try
             {
                 return driver.SwitchTo().Alert();
                
             }   // try 
             catch (NoAlertPresentException ex)
             {
                 //We can IGNORE this exception as it means there is no alert present...yet!
                 MessageBox.Show(ex.Message);
                 return null;
             }   // catch 

             //Other exceptions will be ignored and wind up the stack
         } **/

        static bool IsAlertShown(IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException e)
            {
                //MessageBox.Show(e.Message);
                return false;
            }
            //return true;
        }

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

            //Open a webpage
            

            //Java Script Executor to give the driver certain functions like opening another tab
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //Wait Object for the alert to pop up due to server issues
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            driver.Url = "http://www.demoqa.com";

            //Another Driver to test FB Automation
            //IWebDriver driver2 = new FirefoxDriver();
            //driver2.Url = "https://www.facebook.com/";

            /****NB USING ANOTHER DRIVER WILL OPEN UP A NEW INSTANCE OF THE BROWSER INSTEAD OF ANOTHER TAB*********************/

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
            //Try to click on the services link
            try
            {   //This method requires user knowing an HTML ID
                //driver.FindElement(By.XPath(".//*[@id='menu-item-155']/a")).Click();

                //This method involves trying to get to the element merely by name
                //driver.FindElement(By.Name("Services")).Click();

                //Best to access the link by using the LinkText criteria as we can't be sure what the internal HTML source is
                driver.FindElement(By.LinkText("Services")).Click();

            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message + "\n No Such element exists in Page Source");
                Console.WriteLine(ex.Message + "/n No Such element exists in Page Source");
            }

            //Now try and open up FB with the same driver
            //However we want to open this link in NEW TAB
            //The only way to open new tabs is to simulate the keyboard shortcuts

            /*********************************************************************************************************
             * AUTOMATING FACEBOOK
             * 
             *******************************************************************************************************/

            /*js.ExecuteScript("window.open()");
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
            driver.Navigate().GoToUrl("https://www.facebook.com/");

            //driver.Url = "https://www.facebook.com/";

            Console.WriteLine("Title: " + driver.Title + "Length: " + driver.Title.Length);
            Console.WriteLine("Source Length: " + driver.PageSource.Length);

            //At this point we should be in the default login page because we have not
            //given Portal access to any cookies yet

            //try and search for the login text boxes
            //Elements in textboxes that we need can be referenced by id, class, or name
            //So check if elements exist according to certain criteria

            //NB ON CERTAIN SITES EMAILS are referrenced as Email instead of email
            //Add in validation for this later on ==> make it case insensitive

            if(isElementPresent(By.Name("email")))
            {
                //if email box exists by name fill it out
                driver.FindElement(By.Name("email")).SendKeys("pmisthry@gmail.com");
            }
            else if(isElementPresent(By.Id("email")))
            {
                //if email box exists by id fill it out
                driver.FindElement(By.Id("email")).SendKeys("pmisthry@gmail.com");
            }
            else if(isElementPresent(By.ClassName("email")))
            {
                //if email box exists by a class name fill it out
                driver.FindElement(By.ClassName("email")).SendKeys("pmisthry@gmail.com");
            }
            else
            {
                //could not find the email box and prompt the user
                MessageBox.Show("Could not find email field to automate");
            }

            //NOW USE THE SAME PATTERN TO CHECK FOR THE PASSWORD BOX
            //NB ON CERTAIN SITES PASSWORDS ARE REFERRED TO AS password instead of pass
            //Some may also use Password or Pass ==> make the check case insensitive
            //Add in validation for this later on

            if (isElementPresent(By.Name("pass")))
            {
                //if email box exists by name fill it out
                driver.FindElement(By.Name("pass")).SendKeys("Solidsnakex2");
            }
            else if (isElementPresent(By.Id("pass")))
            {
                //if email box exists by id fill it out
                driver.FindElement(By.Id("pass")).SendKeys("Solidsnakex2");
            }
            else if (isElementPresent(By.ClassName("pass")))
            {
                //if email box exists by a class name fill it out
                driver.FindElement(By.ClassName("pass")).SendKeys("Solidsnakex2");
            }
            else
            {
                //could not find the email box and prompt the user
                MessageBox.Show("Could not find email field to automate");
            }

            //Now check for the login button ==> usually referred to as "submit" within the current form

            //The submit() method is used to submit a form. This is an alternative to clicking the form's submit button. 
            //You can use submit() on any element within the form, not just on the submit button itself. 
            //When submit() is used, WebDriver will look up the DOM to know which form the element belongs to, and then trigger its submit function.

            //using submit method on the password element
            if (isElementPresent(By.Name("pass")))
            {
                //if email box exists by name fill it out
                driver.FindElement(By.Name("pass")).Submit();
            }
            else if (isElementPresent(By.Id("pass")))
            {
                //if email box exists by id fill it out
                driver.FindElement(By.Id("pass")).Submit();
            }
            else if (isElementPresent(By.ClassName("pass")))
            {
                //if email box exists by a class name fill it out
                driver.FindElement(By.ClassName("pass")).Submit();
            }
            else
            {
                //could not find the email box and prompt the user
                MessageBox.Show("Could not find email field to automate");
            }

         */

            //Try automating Wavescape on a new window
            js.ExecuteScript("window.open()");
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
            driver.Navigate().GoToUrl("https://www.wavescape.co.za/");

            //Press the Login / Register Link
            //Do some checks first

            if (isElementPresent(By.Name("login")))
            {
                //if email box exists by name fill it out
                driver.FindElement(By.Name("login")).Click();
            }
            else if (isElementPresent(By.Id("login")))
            {
                //if email box exists by id fill it out
                driver.FindElement(By.Id("login")).Click();
            }
            else if (isElementPresent(By.ClassName("login")))
            {
                //if email box exists by a class name fill it out
                driver.FindElement(By.ClassName("login")).Click();
            }
            else
            {
                //could not find the email box and prompt the user
                MessageBox.Show("Could not find field to automate. Please use manual control");
            }

            //Wait and check for alert window
            var iwait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            try
            {
                iwait.Until(driver => IsAlertShown(driver));
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch(WebDriverTimeoutException ex)
            {
                //Forcing program to ignore this exception
                //MessageBox.Show(ex.Message);
            }
           

            //After checking for alert window check for username

            if (isElementPresent(By.Name("username")))
            {
                //if email box exists by name fill it out
                driver.FindElement(By.Name("username")).SendKeys("pcampion");
            }
            else if (isElementPresent(By.Id("username")))
            {
                //if email box exists by id fill it out
                driver.FindElement(By.Id("username")).SendKeys("pcampion");
            }
            else if (isElementPresent(By.ClassName("username")))
            {
                //if email box exists by a class name fill it out
                driver.FindElement(By.ClassName("username")).SendKeys("pcampion");
            }
            else
            {
                //could not find the email box and prompt the user
                MessageBox.Show("Could not find email field to automate");
            }

            //Checking for password
            if (isElementPresent(By.Name("password")))
            {
                //if email box exists by name fill it out
                driver.FindElement(By.Name("password")).SendKeys("lusaka1");
            }
            else if (isElementPresent(By.Id("password")))
            {
                //if email box exists by id fill it out
                driver.FindElement(By.Id("password")).SendKeys("lusaka1");
            }
            else if (isElementPresent(By.ClassName("password")))
            {
                //if email box exists by a class name fill it out
                driver.FindElement(By.ClassName("password")).SendKeys("lusaka1");
            }
            else
            {
                //could not find the email box and prompt the user
                MessageBox.Show("Could not find email field to automate");
            }

            //using submit method on the password element
            //This should effectively log us in

            if (isElementPresent(By.Name("password")))
            {
                //if email box exists by name fill it out
                driver.FindElement(By.Name("password")).Submit();
            }
            else if (isElementPresent(By.Id("password")))
            {
                //if email box exists by id fill it out
                driver.FindElement(By.Id("password")).Submit();
            }
            else if (isElementPresent(By.ClassName("password")))
            {
                //if email box exists by a class name fill it out
                driver.FindElement(By.ClassName("password")).Submit();
            }
            else
            {
                //could not find the email box and prompt the user
                MessageBox.Show("Could not find email field to automate");
            }

            //Once we are logged in --> directly access the durban cams via the ur directly

            //Switch control back to main form
            
            driver.FindElement(By.LinkText("Cam")).Click();

        }


    }
}
