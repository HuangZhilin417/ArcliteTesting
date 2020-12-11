using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;

namespace ExploreSelenium.ArcliteWebElements
{
    /*
     * Repersents a Textbox element on ArcLite
     */

    public class ArcliteTextBox : ArcliteWebElement, IArcliteWebElement
    {
        public string _elementName;
        public string _elementXPath;
        public string _secondXPath;

        /*
         * Creates a Textbox variable with its specific name and xpath
         */

        public ArcliteTextBox(string name, string xPath) : base(name, xPath)
        {
            _elementName = base.elementName;
            _elementXPath = base.elementXPath;
            _secondXPath = null;
        }

        /*
         * Creates a Textbox variable with its specific name and xpath, and this is only for in tables where the first xpath contains the wanted option and the second xpath is the rest of the xpath
         */

        public ArcliteTextBox(string name, string firstXPath, string secondXpath) : base(name, firstXPath)
        {
            _elementName = base.elementName;
            _elementXPath = base.elementXPath;
            _secondXPath = secondXpath;
        }

        new public void accept(IActionsVisitor visitor, InputVal input)
        {
            visitor.visitTextBox(this, input);
        }

        new public string getValue(IActionsVisitor visitor)
        {
            return visitor.getValue(this);
        }
    }
}