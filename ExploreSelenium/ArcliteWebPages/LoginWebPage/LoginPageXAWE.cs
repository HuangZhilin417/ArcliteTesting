using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
            
            elementXpaths = new Dictionary<string, IArcliteWebElement>();
            this.username = new KeyValuePair<string, IArcliteWebElement>("Username", new ArcliteTextBox("Username", "//input[@id='UserName']", ArcliteWebElementType.Textbox));
            password = new KeyValuePair<string, IArcliteWebElement>("Password", new ArcliteTextBox("Password", "//input[@id='Password']", ArcliteWebElementType.Textbox));
            signIn = new KeyValuePair<string, IArcliteWebElement>("Sign In", new ArcliteButton("Sign In", "//button[@id='btnlogin']", ArcliteWebElementType.Button));
            this.setElementXpaths();
            page.pageElements = elementXpaths;
        }
        //Dictionary<element name, XPath>
       

        public void setElementXpaths()
        {
            this.elementXpaths.Add(username.Key, username.Value);
            this.elementXpaths.Add(password.Key, password.Value);
            this.elementXpaths.Add(signIn.Key, signIn.Value);
        }


    }
}
