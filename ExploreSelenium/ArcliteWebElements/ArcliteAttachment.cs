using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;

namespace ExploreSelenium.ArcliteWebElements
{
    /*
     * Repersents the Attachment element on Arclite
     */

    public class ArcliteAttachment : ArcliteWebElement, IArcliteWebElement
    {
        /*
         * Creates a Attachment variable with its specific name and xpath
         */

        public ArcliteAttachment(string name, string xPath) : base(name, xPath)
        {
        }

        new public void accept(IActionsVisitor visitor, InputVal input)
        {
            visitor.visitAttachment(this, input);
        }
    }
}