using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;
using System.Threading;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Qualification
{
    /*
     * Repersents the Qualification Page on ArcLite
     */

    public class QualificationPage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public QualificationXAWE pageInfo;
        private IActionsVisitor _visitor;

        /*
         * Creates a Qualification page and initializes page title and all of this page's Xpath
         */

        public QualificationPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Setting Qualifications";
            _visitor = visitor;
            pageInfo = new QualificationXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Qualification
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Qualifications");
                    addingPersonnelQualification();
                    Thread.Sleep(longSleepTime);
                    addingMachineQualification();
                    System.Console.WriteLine("Finished Adding Qualifications");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Qualifications");
                    deleteQualification();
                    System.Console.WriteLine("Finished Deleting Qualifications");
                    break;

                default:
                    break;
            }
        }

        private void addingPersonnelQualification()
        {
            _pageElements[pageInfo.add.Key].accept(_visitor, new InputVal());
            _pageElements[pageInfo.name.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
            Thread.Sleep(shortSleepTime);
            _pageElements[pageInfo.type.Key].accept(_visitor, inputs.getInput(pageInfo.type.Key));
            _pageElements[pageInfo.description.Key].accept(_visitor, inputs.getInput(pageInfo.description.Key));
            _pageElements[pageInfo.save.Key].accept(_visitor, new InputVal());
        }

        private void addingMachineQualification()
        {
            inputs.switchInput(pageInfo.name.Key);
            inputs.switchInput(pageInfo.type.Key);
            this.addingPersonnelQualification();
        }

        private void deleteQualification()
        {
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
            inputs.switchInput(pageInfo.name.Key);
            Thread.Sleep(longSleepTime);
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.name.Key));
        }
    }
}