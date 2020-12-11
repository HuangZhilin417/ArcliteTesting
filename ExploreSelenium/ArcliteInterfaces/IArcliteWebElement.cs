using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;

namespace ExploreSelenium.ArcliteWebElements
{
    /*
     * repersents each interactive web element in ArcLite
     */

    public interface IArcliteWebElement
    {
        /*
         * A unique string for the element's name
         */
        string elementName { get; set; }

        /*
         * The Xpath for the element
         */
        string elementXPath { get; set; }

        /*
         * Getting the value of a textbox
         */

        string getValue(IActionsVisitor visitor);

        /*
         * Accepts visitor and input to perform action
         */

        void accept(IActionsVisitor visitor, InputVal input);
    }
}