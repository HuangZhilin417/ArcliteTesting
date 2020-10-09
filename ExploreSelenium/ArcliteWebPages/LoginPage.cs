using ExploreSelenium.ArcliteWebElements;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages
{
    //the login page of Arclite
    class LoginPage : ArcliteWebPage
    {
        private string _pageTitle;
        private Dictionary<string, IArcliteWebElement> _pageElements;
        private WebDriverWait _wait;
        public LoginPage(WebDriverWait driverWait) : base()
        {
            _wait = driverWait;
            _pageTitle = "LoginPage";
            _pageElements = base.pageElements;
            setElements();
        }

        new public void setElements()
        {
            IArcliteWebElement username = new ArcliteWebElement("Username", "//input[@id='UserName']", ArcliteWebElementType.Input, _wait);
            IArcliteWebElement password = new ArcliteWebElement("Password", "//input[@id='Password']", ArcliteWebElementType.Input, _wait);
            IArcliteWebElement signIn = new ArcliteWebElement("Sign In", "//button[@id='btnlogin']", ArcliteWebElementType.Button, _wait);
            _pageElements.Add(username.elementName, username);
            _pageElements.Add(password.elementName, password);
            _pageElements.Add(signIn.elementName, signIn);
        }

    }
}
