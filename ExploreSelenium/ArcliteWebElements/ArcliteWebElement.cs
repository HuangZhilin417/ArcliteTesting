using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
namespace ExploreSelenium.ArcliteWebElements
{
    public class ArcliteWebElement : IArcliteWebElement
    {
        string _elementName;
        string _elementXPath;
        ArcliteWebElementType _elementType;

        public ArcliteWebElement(string name, string xPath)
        {
            _elementName = name;
            _elementXPath = xPath;
        }

        public string elementName { get => _elementName; set => _elementName = value; }
        public string elementXPath { get => _elementXPath; set => _elementXPath = value; }
        public ArcliteWebElementType elementType { get => _elementType; set => _elementType = value; }


            
        public void accept(IActionsVisitor visitor, InputVal input)
        {
            throw new System.NotImplementedException();
        }
    }
}
