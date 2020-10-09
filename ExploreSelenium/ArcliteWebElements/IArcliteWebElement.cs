using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebElements
{
    public enum ArcliteWebElementType
    {
        Input,
        Dropdown,
        Button
    }


    public interface IArcliteWebElement
    {
        string elementName { get; set; }
        string elementXPath { get; set; }
        ArcliteWebElementType elementType { get; set; }
        IWebElement webElement { get; set; }

    }
}
