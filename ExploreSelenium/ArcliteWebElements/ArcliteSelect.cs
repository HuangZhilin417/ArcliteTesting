using ExploreSelenium.ArcliteWebElementActionsVisitor;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebElements
{
    public class ArcliteSelect : ArcliteWebElement, IArcliteWebElement
    {
        string _elementName;
        public string _dropDownXpath;
        public string _selectXPath;
        IWebElement _element;
        ArcliteWebElementType _elementType;
  
        public ArcliteSelect(string name, string dropDownXpath,string selectXPath) : base(name, selectXPath)
        {
            _elementName = base.elementName;
            _selectXPath = base.elementXPath;
            _dropDownXpath = dropDownXpath;
            _elementType = ArcliteWebElementType.Select;
        }


        new public void accept(IActionsVisitor visitor, string wanted) { 
      
            visitor.visitSelect(this, wanted);
        }
    }
}
