using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Personnel
{
    /*
     * Repersents the Personnel Page on ArcLite
     */

    public class PersonnelPage : ConfigurationsPage, IArclitePage
    {
        new public string _pageTitle;
        new public Dictionary<string, IArcliteWebElement> _pageElements;
        new public PersonnelXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
        * Creates a Personnel page and initializes page title and all of this page's Xpath
        */

        public PersonnelPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Personnel Page";
            _visitor = visitor;
            pageInfo = new PersonnelXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Personnel
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);

            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Personnel");
                    addingPersonnel();
                    System.Console.WriteLine("Finished Adding Personnel");
                    break;

                case ArcliteTestAction.approve:
                    System.Console.WriteLine("Approving Personnel");
                    approvePersonnel();
                    System.Console.WriteLine("Finished Approving Personnel");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Personnel");
                    deletingPersonnel();
                    System.Console.WriteLine("Finished Deleting Personnel   ");
                    break;
            }
        }

        private void addingPersonnel()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());

            string randomName = Util.randomString();
            string currentUsername = inputs.getInput(pageInfo.userName.Key).valOne;
            inputs.setInput(pageInfo.userName.Key, new InputVal(currentUsername + randomName));

            _pageElements[pageInfo.userName.Key].accept(_visitor, inputs.getInput(pageInfo.userName.Key));

            _pageElements[pageInfo.firstName.Key].accept(_visitor, inputs.getInput(pageInfo.firstName.Key));

            _pageElements[pageInfo.lastName.Key].accept(_visitor, inputs.getInput(pageInfo.lastName.Key));

            _pageElements[pageInfo.primaryPassword.Key].accept(_visitor, inputs.getInput(pageInfo.primaryPassword.Key));

            _pageElements[pageInfo.confirmPassword.Key].accept(_visitor, inputs.getInput(pageInfo.confirmPassword.Key));

            _pageElements[pageInfo.email.Key].accept(_visitor, inputs.getInput(pageInfo.email.Key));

            _pageElements[pageInfo.department.Key].accept(_visitor, inputs.getInput(pageInfo.department.Key));

            _pageElements[pageInfo.title.Key].accept(_visitor, inputs.getInput(pageInfo.title.Key));

            _pageElements[pageInfo.qualification.Key].accept(_visitor, inputs.getInput(pageInfo.qualification.Key));

            _pageElements[pageInfo.role.Key].accept(_visitor, inputs.getInput(pageInfo.role.Key));

            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());
        }

        private void approvePersonnel()
        {
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, new InputVal("admin"));

            _pageElements[pageInfo.qualification.Key].accept(_visitor, new InputVal("Best"));
        }

        private void deletingPersonnel()
        {
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.userName.Key));
        }
    }
}