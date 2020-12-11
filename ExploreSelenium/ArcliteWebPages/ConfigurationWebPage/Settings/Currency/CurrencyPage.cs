using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Currency
{
    /*
     * Repersents the Currency Page on ArcLite
     */

    public class CurrencyPage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public CurrencyXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Currency page and initializes page title and all of this page's Xpath
         */

        public CurrencyPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Setting Currency";
            _visitor = visitor;
            pageInfo = new CurrencyXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Currency
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Currency");
                    addingCurrency();
                    System.Console.WriteLine("Finished Adding Currency");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Currency");
                    deleteCurrency();
                    System.Console.WriteLine("Finished Deleting Currency");
                    break;

                default:
                    break;
            }
        }

        private void addingCurrency()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.name.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
            _pageElements[pageInfo.symbol.Key].accept(_visitor, inputs.getInput(pageInfo.symbol.Key));
            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());
        }

        private void deleteCurrency()
        {
            System.Diagnostics.Debug.WriteLine("in delete");
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
        }
    }
}