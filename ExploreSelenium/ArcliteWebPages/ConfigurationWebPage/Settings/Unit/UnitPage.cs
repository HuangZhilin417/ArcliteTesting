using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Unit
{
    /*
     * Repersents the Unit Page on ArcLite
     */

    public class UnitPage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public UnitXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Unit page and initializes page title and all of this page's Xpath
         */

        public UnitPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Setting Unit";
            _visitor = visitor;
            pageInfo = new UnitXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Unit
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Unit");
                    addingUnit();
                    System.Console.WriteLine("Finished Adding Unit");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Unit");
                    deleteUnit();
                    System.Console.WriteLine("Finished Deleting Unit");
                    break;

                default:
                    break;
            }
        }

        private void addingUnit()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.name.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
            _pageElements[pageInfo.symbol.Key].accept(_visitor, inputs.getInput(pageInfo.symbol.Key));
            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());
        }

        private void deleteUnit()
        {
            System.Diagnostics.Debug.WriteLine("in delete");
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
        }
    }
}