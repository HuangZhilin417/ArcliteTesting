using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Checklists
{
    public class ChecklistsPage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public CheckListsXAWE pageInfo;
        IActionsVisitor _visitor;
        public ChecklistsPage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Checklists Page";
            _visitor = visitor;
            pageInfo = new CheckListsXAWE(this);
            _pageElements = base.pageElements;

        }


        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true);
            switch (action)
            {
                case ArcliteTestAction.add:
                    addingChecklists();
                    break;
                case ArcliteTestAction.approve:
                    deletingChecklists();
                    break;
                default:
                    break;
            }


        }

        private void addingChecklists()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());


            _pageElements[pageInfo.name.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
            _pageElements[pageInfo.categoryName.Key].accept(_visitor, inputs.getInput(pageInfo.categoryName.Key));
            _pageElements[pageInfo.formNumber.Key].accept(_visitor, inputs.getInput(pageInfo.formNumber.Key));
            _pageElements[pageInfo.revisionNumber.Key].accept(_visitor, inputs.getInput(pageInfo.revisionNumber.Key));
            _pageElements[pageInfo.header.Key].accept(_visitor, inputs.getInput(pageInfo.header.Key));
            _pageElements[pageInfo.footer.Key].accept(_visitor, inputs.getInput(pageInfo.footer.Key));
            _pageElements[pageInfo.description.Key].accept(_visitor, inputs.getInput(pageInfo.description.Key));

            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());
        }

        private void deletingChecklists()
        {
           // _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
        }
    }
}
