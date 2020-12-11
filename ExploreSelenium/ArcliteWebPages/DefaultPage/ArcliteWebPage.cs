using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages.DefaultPage;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages
{
    /*
     * Repersents the basic Arclite Page which contains the navigation bar on the top of the Arclite Page
     */

    public class ArcliteWebPage : IArclitePage
    {
        /*
         * Unique name for each page
         */
        private string _pageTitle;

        /*
         * Dictionary: Key is a unique element name for a ArcLite Web Elment, Value: IArcliteWebElement that has the same element name as the current Key
         */
        private Dictionary<string, IArcliteWebElement> _pageElements;

        /*
         * Every IArcliteWebElement will accept this visitor, and perform a action corresponding to the type of IArcliteWebElement with a given input.
         */
        private IActionsVisitor _visitor;

        /*
         * A Page that contains all of the Xpath corresponding to the IWebElement
         */
        private IArcliteData pageInfo;

        /*
         * A input class that contains all of the pageInfo, and it will apply the input value based on the current element the test is interacting with
         */
        public IArcliteInputs inputs;

        /*
         * A long sleep time, meant for long pause for the test, usually used when waiting on a page element that takes a long time to load
         */
        public int longSleepTime;

        /*
         * A short sleep time, meant for short pause for the test, usually used when making a short pause from one element's action to another.
         */
        public int shortSleepTime;

        /*
         * Creates a Arclite Web Page with the created inputs and the visitor
         */

        public ArcliteWebPage(IActionsVisitor visitor, IArcliteInputs inputs)
        {
            _pageTitle = "defaultPage";
            _pageElements = new Dictionary<string, IArcliteWebElement>();
            _visitor = visitor;
            pageInfo = new ArcliteWebPageXAWE(this);
            this.inputs = inputs;
            this.longSleepTime = 4000;
            this.shortSleepTime = 2000;
        }

        /*
         * Creates a Arclite Web Page with just the created inputs, it is mainly for accessing value of different inputs
         */

        public ArcliteWebPage(IArcliteInputs inputs)
        {
            _pageTitle = "defaultPage";
            this.inputs = inputs;
            _pageElements = new Dictionary<string, IArcliteWebElement>();
            this.longSleepTime = 4000;
            this.shortSleepTime = 2000;
        }

        /*
         * creates a Arclite Web Page that does not need any custom inputs
         */

        public ArcliteWebPage(IActionsVisitor visitor)
        {
            _pageTitle = "defaultPage";
            _pageElements = new Dictionary<string, IArcliteWebElement>();
            this.longSleepTime = 4000;
            this.shortSleepTime = 2000;
        }

        public string pageTitle { get => _pageTitle; set => _pageTitle = value; }

        public Dictionary<string, IArcliteWebElement> pageElements { get => _pageElements; set => _pageElements = value; }

        public void runTests(ArcliteTestAction action)
        {
            throw new NotImplementedException();
        }
    }
}