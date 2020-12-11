using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Assets
{
    /*
     * Repersents the Assets Page on ArcLite
     */

    public class AssetsPage : ConfigurationsPage, IArclitePage
    {
        new public string _pageTitle;
        new public Dictionary<string, IArcliteWebElement> _pageElements;
        new public AssetsXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Assets page and initializes page title and all of this page's Xpath
         */

        public AssetsPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Assets Page";
            _visitor = visitor;
            pageInfo = new AssetsXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Asset
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Assets");
                    addingAssets();
                    System.Console.WriteLine("Finished Adding Assets");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Assets");
                    deletingAssets();
                    System.Console.WriteLine("Finished Deleting Assets");
                    break;
            }
        }

        private void addingAssets()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());

            _pageElements[pageInfo.name.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
            _pageElements[pageInfo.assetType.Key].accept(_visitor, inputs.getInput(pageInfo.assetType.Key));
            _pageElements[pageInfo.serial.Key].accept(_visitor, inputs.getInput(pageInfo.serial.Key));
            _pageElements[pageInfo.description.Key].accept(_visitor, inputs.getInput(pageInfo.description.Key));
            _pageElements[pageInfo.installedBy.Key].accept(_visitor, inputs.getInput(pageInfo.installedBy.Key));

            _pageElements[pageInfo.trackOEE.Key].accept(_visitor, new InputVal());

            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());
        }

        private void deletingAssets()
        {
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
        }
    }
}