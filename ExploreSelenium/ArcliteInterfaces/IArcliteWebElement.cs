using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebElements
{

    public enum ArcliteWebElementType{
        Textbox,
        Select,
        Calender,
        Button,
        Table,
        Search

        }

    // repersents each interactive web element in Arclite
    public interface IArcliteWebElement
    {
        string elementName { get; set; }
        string elementXPath { get; set; }
        ArcliteWebElementType elementType{get; set;}
        void accept(IActionsVisitor visitor, InputVal input);

    }
}
