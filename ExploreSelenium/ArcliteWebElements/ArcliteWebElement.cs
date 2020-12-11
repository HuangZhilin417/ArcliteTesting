using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;

namespace ExploreSelenium.ArcliteWebElements
{
    /*
     * Repersents a basic element on ArcLite, have a unqiue name and a xpath
     */

    public class ArcliteWebElement : IArcliteWebElement
    {
        /*
         * A unique string name for this element
         */
        private string _elementName;

        /*
         * The corresponding element Xpath on ArcLite
         */
        private string _elementXPath;

        /*
         * Creates a ArcliteWebElement that requires a unique name and its' Xpath
         */

        public ArcliteWebElement(string name, string xPath)
        {
            _elementName = name;
            _elementXPath = xPath;
        }

        public string elementName { get => _elementName; set => _elementName = value; }

        public string elementXPath { get => _elementXPath; set => _elementXPath = value; }

        /*
         * Performs a action based on the current type of web element with the specific input
         */

        public void accept(IActionsVisitor visitor, InputVal input)
        {
            throw new System.NotImplementedException();
        }

        /*
         * Gets the value of the current web element
         */

        public string getValue(IActionsVisitor visitor)
        {
            throw new System.NotImplementedException();
        }
    }
}