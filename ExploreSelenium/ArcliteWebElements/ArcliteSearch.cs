using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebElements
{
    public class ArcliteSearch : ArcliteWebElement, IArcliteWebElement
    {
        string _elementName;
        public string _searchInputXPath;
        public string _searchButtonXpath;
        ArcliteWebElementType _elementType;
        public ArcliteSearch(string name, string searchInputXPath, string searchButtonXpath) : base(name, searchInputXPath)
        {
            _elementName = name;
            _searchButtonXpath = searchButtonXpath;
            _searchInputXPath = base.elementXPath;
            _elementType = ArcliteWebElementType.Search;
        }

        new public void accept(IActionsVisitor visitor, InputVal input)
        {
            visitor.visitSearch(this, input);
        }
    }
}
