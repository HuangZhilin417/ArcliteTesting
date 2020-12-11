using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;

namespace ExploreSelenium.ArcliteWebElements
{
    /*
     * Repersents a Canvas element on ArcLite
     */

    public class ArcliteCanvas : ArcliteWebElement, IArcliteWebElement
    {
        public string _elementName;
        public string _elementXPath;

        public IArcliteWebElement addStep;

        /*
         * Creates a Canvas variable with its specific name and xpath
         */

        public ArcliteCanvas(string name, string xPath, IArcliteWebElement addStep) : base(name, xPath)
        {
            _elementName = base.elementName;
            _elementXPath = base.elementXPath;

            this.addStep = addStep;
        }

        new public void accept(IActionsVisitor visitor, InputVal input)
        {
            visitor.visitCanvas(this, input);
        }
    }
}