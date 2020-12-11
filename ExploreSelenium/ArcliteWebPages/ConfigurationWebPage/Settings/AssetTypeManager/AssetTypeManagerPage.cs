using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;
using System.Threading;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.AssetTypeManager
{
    /*
     * Repersents the Asset Type Manager Page on ArcLite
     */

    public class AssetTypeManagerPage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public AssetTypeManagerXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Asset Type Manager page and initializes page title and all of this page's Xpath
         */

        public AssetTypeManagerPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Setting Asset Type";
            _visitor = visitor;
            pageInfo = new AssetTypeManagerXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Asset Type Manager
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Asset Type Manager");
                    addingAssetTypeManager();
                    System.Console.WriteLine("Finished Adding Asset Type Manager");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Asset Type Manager");
                    deleteAssetTypeManager();
                    System.Console.WriteLine("Finished Deleting Asset Type Manager");
                    break;

                default:
                    break;
            }
        }

        private void addingAssetTypeManager()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.name.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
            _pageElements[pageInfo.description.Key].accept(_visitor, inputs.getInput(pageInfo.description.Key));
            Thread.Sleep(2000);
            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());
        }

        private void deleteAssetTypeManager()
        {
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
        }
    }
}