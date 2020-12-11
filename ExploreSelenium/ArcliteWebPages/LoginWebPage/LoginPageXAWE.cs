using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System.Collections.Generic;
using System.Linq;

namespace ExploreSelenium.ArcliteWebPages
{
    public class LoginPageXAWE : IArcliteData

    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;
        public KeyValuePair<string, IArcliteWebElement> username;
        public KeyValuePair<string, IArcliteWebElement> password;
        public KeyValuePair<string, IArcliteWebElement> signIn;

        public LoginPageXAWE(IArclitePage page)
        {
            this.initPage();
            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }

        public LoginPageXAWE()
        {
            this.initPage();
        }

        //Dictionary<element name, XPath>
        private void initPage()
        {
            elementXpaths = new Dictionary<string, IArcliteWebElement>();
            this.username = new KeyValuePair<string, IArcliteWebElement>("Username", new ArcliteTextBox("Username", "//input[@id='UserName']"));
            password = new KeyValuePair<string, IArcliteWebElement>("Password", new ArcliteTextBox("Password", "//input[@id='Password']"));
            signIn = new KeyValuePair<string, IArcliteWebElement>("Sign In", new ArcliteButton("Sign In", "//button[@id='btnlogin']"));
        }

        public void setElementXpaths()
        {
            this.elementXpaths.Add(username.Key, username.Value);
            this.elementXpaths.Add(password.Key, password.Value);
            this.elementXpaths.Add(signIn.Key, signIn.Value);
        }
    }
}