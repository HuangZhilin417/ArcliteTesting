using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages
{
    /*
     * Test actions
     */

    public enum ArcliteTestAction
    {
        add,
        delete,
        check,
        login,
        approve
    }

    /*
     * Repersents a Arclite Web Page
     */

    public interface IArclitePage
    {
        /*
         * sets and gets unique page title for every page
         */
        string pageTitle { get; set; }

        /*
         * contains the key (name of the web element or the page title it leads to), and the actual element of Arclite
         */
        Dictionary<string, IArcliteWebElement> pageElements { get; set; }

        /*
         * run tests for the page, and perfroms different test based on the given action
         */

        void runTests(ArcliteTestAction action);
    }
}