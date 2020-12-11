using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages;

namespace ExploreSelenium.ArcliteWebElementActionsVisitor
{
    public interface IActionsVisitor
    {
        /*
         * Performs a click on a button
         */

        void visitButton(ArcliteButton element);

        /*
         * selects from a dropdown with wanted option
         */

        void visitSelect(ArcliteSelect element, InputVal wanted);

        /*
         * Enter text in the textbox
         */

        void visitTextBox(ArcliteTextBox element, InputVal wanted);

        /*
         * select the next month's first day for a calender
         */

        void visitCalender(ArcliteCalender element, InputVal wanted);

        /*
         * Delete a entry from a table if no action is specified
         */

        void visitDataTable(ArcliteDataTable element, InputVal wanted, ArcliteTestAction action = ArcliteTestAction.delete);

        /*
         * Enter text in a search box and clicks on search button if there is one
         */

        void visitSearch(ArcliteSearch arcliteSearch, InputVal wanted);

        /*
         * Switches to the main frame of Arclite, usually need to call this after clicking on a navigation tab button and want to access the content inside the tab
         */

        void switchFrame();

        /*
         * Switch to the parent frame
         */

        void switchToParentFrame();

        /*
         * visit canvas in workflow builder and createds one step, and opens it
         */

        void visitCanvas(ArcliteCanvas arcliteCanvas, InputVal input);

        /*
         * selects a attatchement in the attachement box, need to have a exact file location
         */

        void visitAttachment(ArcliteAttachment element, InputVal input);

        /*
        * gets the value from a textbox
        */

        string getValue(ArcliteTextBox textbox);
    }
}