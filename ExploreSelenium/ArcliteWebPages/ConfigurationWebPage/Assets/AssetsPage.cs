using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Assets
{
    public class AssetsPage : ConfigurationsPage, IArclitePage
    {
        new public string _pageTitle;
        new public Dictionary<string, IArcliteWebElement> _pageElements;
        new public AssetsXAWE pageInfo;
        IActionsVisitor _visitor;
        public AssetsPage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Assets Page";
            _visitor = visitor;
            pageInfo = new AssetsXAWE(this);
            _pageElements = base.pageElements;
        }

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true);
            switch (action)
            {
                case ArcliteTestAction.add:
                    addingAssets();
                    break;
                case ArcliteTestAction.delete:
                    deletingAssets();
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