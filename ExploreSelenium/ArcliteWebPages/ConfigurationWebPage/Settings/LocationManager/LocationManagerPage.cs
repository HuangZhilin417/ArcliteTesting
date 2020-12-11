using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.LocationManager
{
    /*
     * Repersents the Location Manager Page on ArcLite
     */

    public class LocationManagerPage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public LocationManagerXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
        * Creates a Location Manager page and initializes page title and all of this page's Xpath
        */

        public LocationManagerPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Setting Location Manager";
            _visitor = visitor;
            pageInfo = new LocationManagerXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Location Manager
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Location Manager");
                    addingLocationManager();
                    System.Console.WriteLine("Finished Adding Location Manager");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Location Manager");
                    deleteLocationManager();
                    System.Console.WriteLine("Finished Deleting Location Manager");
                    break;

                default:
                    break;
            }
        }

        private void addingLocationManager()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.name.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
            _pageElements[pageInfo.code.Key].accept(_visitor, inputs.getInput(pageInfo.code.Key));
            _pageElements[pageInfo.description.Key].accept(_visitor, inputs.getInput(pageInfo.description.Key));
            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());
        }

        private void deleteLocationManager()
        {
            System.Diagnostics.Debug.WriteLine("in delete");
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
        }
    }
}