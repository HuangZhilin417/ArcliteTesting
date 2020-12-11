using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;

namespace ExploreSelenium.ArcliteWebElements
{
    /*
     * Repersents a Search element on ArcLite
     */

    public class ArcliteSearch : ArcliteWebElement, IArcliteWebElement
    {
        private string _elementName;
        public string _searchInputXPath;
        public string _searchButtonXpath;

        /*
         * Creates a Search variable with its specific name and xpath
         */

        public ArcliteSearch(string name, string searchInputXPath, string searchButtonXpath) : base(name, searchInputXPath)
        {
            _elementName = name;
            _searchButtonXpath = searchButtonXpath;
            _searchInputXPath = base.elementXPath;
        }

        new public void accept(IActionsVisitor visitor, InputVal input)
        {
            visitor.visitSearch(this, input);
        }
    }
}