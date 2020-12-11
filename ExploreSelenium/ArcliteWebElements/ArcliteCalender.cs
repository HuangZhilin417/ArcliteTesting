using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using OpenQA.Selenium;

namespace ExploreSelenium.ArcliteWebElements
{
    /*
     * Repersents a Calender element on ArcLite
     */

    public class ArcliteCalender : ArcliteWebElement, IArcliteWebElement
    {
        private string _elementName;
        private string _elementXPath;
        public string _nextMonthXpath;
        public string _firstDateXpath;
        private IWebElement _element;

        /*
         * Creates a Calender variable with its specific name and xpath
         */

        public ArcliteCalender(string name, string xPath, string nextMonthXpath, string firstDateXpath) : base(name, xPath)
        {
            _elementName = base.elementName;
            _elementXPath = base.elementXPath;
            _nextMonthXpath = nextMonthXpath;
            _firstDateXpath = firstDateXpath;
        }

        new public void accept(IActionsVisitor visitor, InputVal input)
        {
            visitor.visitCalender(this, input);
        }
    }
}