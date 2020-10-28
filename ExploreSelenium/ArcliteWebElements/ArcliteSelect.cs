using ExploreSelenium.ArcliteInputs;
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
        public string _optionFirst;
        public string _optionSecond;
        ArcliteWebElementType _elementType;
  
        public ArcliteSelect(string name, string dropDownXpath,string selectXPath) : base(name, selectXPath)
        {
            _elementName = base.elementName;
            _selectXPath = base.elementXPath;
            _dropDownXpath = dropDownXpath;
            _optionFirst = null;
            _optionSecond = null;
            _elementType = ArcliteWebElementType.Select;
        }
        public ArcliteSelect(string name, string dropDownXpath, string selectXPath, string optionFirst, string optionSecond) : base(name, selectXPath)
        {
            _elementName = base.elementName;
            _selectXPath = base.elementXPath;
            _optionFirst = optionFirst;
            _optionSecond = optionSecond;
            _dropDownXpath = dropDownXpath;
            _elementType = ArcliteWebElementType.Select;
        }



        new public void accept(IActionsVisitor visitor, InputVal input)
        { 
            visitor.visitSelect(this, input);
        }
    }
}
