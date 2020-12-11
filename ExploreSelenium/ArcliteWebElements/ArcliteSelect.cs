using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;

namespace ExploreSelenium.ArcliteWebElements
{
    /*
     * Repersents a Select element on ArcLite
     */

    public class ArcliteSelect : ArcliteWebElement, IArcliteWebElement
    {
        private string _elementName;
        public string _dropDownXpath;
        public string _selectXPath;
        public string _optionFirst;
        public string _optionSecond;

        /*
         * Creates a Select variable with its specific name and xpath, with only select element
         */

        public ArcliteSelect(string name, string dropDownXpath, string selectXPath) : base(name, selectXPath)
        {
            _elementName = base.elementName;
            _selectXPath = base.elementXPath;
            _dropDownXpath = dropDownXpath;
            _optionFirst = null;
            _optionSecond = null;
        }

        /*
         * Creates a Select variable with its specific name and xpath, select with div fs-option
         */

        public ArcliteSelect(string name, string dropDownXpath, string selectXPath, string optionFirst, string optionSecond) : base(name, selectXPath)
        {
            _elementName = base.elementName;
            _selectXPath = base.elementXPath;
            _optionFirst = optionFirst;
            _optionSecond = optionSecond;
            _dropDownXpath = dropDownXpath;
        }

        new public void accept(IActionsVisitor visitor, InputVal input)
        {
            visitor.visitSelect(this, input);
        }
    }
}