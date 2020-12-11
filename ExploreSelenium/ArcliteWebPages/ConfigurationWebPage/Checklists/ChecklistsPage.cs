using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;
using System.Threading;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Checklists
{
    /*
     * Repersents the Checklist Page on ArcLite
     */

    public class ChecklistsPage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public CheckListsXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Checklist page and initializes page title and all of this page's Xpath
         */

        public ChecklistsPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Checklists Page";
            _visitor = visitor;
            pageInfo = new CheckListsXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Checklist
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Checklist");
                    addingChecklists();
                    System.Console.WriteLine("Fisished Adding Checklist");
                    break;

                case ArcliteTestAction.approve:
                    System.Console.WriteLine("Approving Checklist");
                    approveChecklists();
                    System.Console.WriteLine("Finished Approving Checklist");
                    break;

                default:
                    break;
            }
        }

        private void addingChecklists()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());

            string randomName = Util.randomString();
            string currentName = inputs.getInput(pageInfo.name.Key).valOne;
            inputs.setInput(pageInfo.name.Key, new InputVal(currentName + randomName));

            _pageElements[pageInfo.name.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));

            randomName = Util.randomString();
            string currCategoryName = inputs.getInput(pageInfo.addCategoryName.Key).valOne;
            inputs.setInput(pageInfo.addCategoryName.Key, new InputVal(currCategoryName + randomName));

            _pageElements[pageInfo.addCategory.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.addCategoryName.Key].accept(_visitor, inputs.getInput(pageInfo.addCategoryName.Key));
            _pageElements[pageInfo.categorySave.Key].accept(_visitor, new InputVal());

            _pageElements[pageInfo.formNumber.Key].accept(_visitor, inputs.getInput(pageInfo.formNumber.Key));
            _pageElements[pageInfo.revisionNumber.Key].accept(_visitor, inputs.getInput(pageInfo.revisionNumber.Key));
            _pageElements[pageInfo.header.Key].accept(_visitor, inputs.getInput(pageInfo.header.Key));
            _pageElements[pageInfo.footer.Key].accept(_visitor, inputs.getInput(pageInfo.footer.Key));
            _pageElements[pageInfo.description.Key].accept(_visitor, inputs.getInput(pageInfo.description.Key));

            Thread.Sleep(shortSleepTime);
            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());

            _visitor.switchToParentFrame();
        }

        private void approveChecklists()
        {
            InputVal val = inputs.getInput(pageInfo.name.Key);
            val.valTwo = inputs.getInput(pageInfo.addCategoryName.Key).valOne;
            _pageElements[pageInfo.checklistDataTable.Key].accept(_visitor, val);
            Thread.Sleep(longSleepTime);
            _pageElements[pageInfo.approve.Key].accept(_visitor, new InputVal());

            _pageElements[pageInfo.approveDataTable.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));

            _pageElements[pageInfo.approvePassword.Key].accept(_visitor, inputs.getInput(pageInfo.approvePassword.Key));
            _pageElements[pageInfo.approveStatus.Key].accept(_visitor, inputs.getInput(pageInfo.approveStatus.Key));
            _pageElements[pageInfo.approveConfirm.Key].accept(_visitor, new InputVal());
            _visitor.switchToParentFrame();
        }
    }
}