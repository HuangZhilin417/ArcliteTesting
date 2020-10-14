using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages.LoginPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExploreSelenium.ArcliteWebPages
{
    //the login page of Arclite
    public class LoginPage : ArcliteWebPage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        private WebDriverWait _wait;
        public LoginPageXAWE pageInfo;
        IWebDriver _driver;
        public LoginPage(WebDriverWait driverWait, IWebDriver driver) : base()
        {
            _pageElements = new Dictionary<string, IArcliteWebElement>();
            pageInfo = new LoginPageXAWE(this);
            _pageTitle = "LoginPage";
            _driver = driver;
            
        }

        new public void runTests()
        {
            IActionsVisitor visitor = new ArcliteActionVisitor(_wait, _driver);
            _pageElements[pageInfo.username.Key].accept(visitor, "admin");
            _pageElements[pageInfo.password.Key].accept(visitor, "admin");
            _pageElements[pageInfo.signIn.Key].accept(visitor, "click");
        }


    }
}
