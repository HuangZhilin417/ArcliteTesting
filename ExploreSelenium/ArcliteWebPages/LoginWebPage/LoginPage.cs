using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
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
    public class LoginPage : ArcliteWebPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public LoginPageXAWE pageInfo;
        IActionsVisitor _visitor;
        public LoginPage(IActionsVisitor visitor) : base()
        {
            base.pageTitle = "LoginPage";
            _visitor = visitor;
            pageInfo = new LoginPageXAWE(this);
            _pageElements = base.pageElements;


        }

        new public void runTests(ArcliteTestAction action)
        {
            _pageElements[pageInfo.username.Key].accept(_visitor, inputs.getInput(pageInfo.username.Key));
            _pageElements[pageInfo.password.Key].accept(_visitor, inputs.getInput(pageInfo.password.Key));
            _pageElements[pageInfo.signIn.Key].accept(_visitor, new InputVal());
        }


    }
}
