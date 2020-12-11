using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages.WorkstationPage;
using System.Collections.Generic;
using System.Threading;

namespace ExploreSelenium.ArcliteWebPages
{
    /*
     * Repersents the Workstation Page on ArcLite
     */

    public class WorkstationsPage : ArcliteWebPage, IArclitePage
    {
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public WorkstationXAWE pageInfo;
        private IActionsVisitor visitor;

        /*
         * Creates a Workstations page and initializes page title and all of this page's Xpath
         */

        public WorkstationsPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Workstation";
            this.visitor = visitor;
            pageInfo = new WorkstationXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Workstation
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, this.visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Workstation");
                    completeWorkStation();
                    System.Console.WriteLine("Finished Adding Workstation");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Workstation");
                    deleteWorkStation();
                    System.Console.WriteLine("Finished Deleting Workstation");
                    break;

                default:
                    break;
            }
        }

        private void completeWorkStation()
        {
            _pageElements[pageInfo.ongoingWorkstationTable.Key].accept(visitor, inputs.getInput(pageInfo.ongoingWorkstationTable.Key));
            _pageElements[pageInfo.stepsTable.Key].accept(visitor, inputs.getInput(pageInfo.stepsTable.Key));
            this.runStep();
            InputVal newStep = inputs.getInput(pageInfo.stepsTable.Key).switchVal();

            _pageElements[pageInfo.stepsTable.Key].accept(visitor, newStep);
            this.runStep();
            _pageElements[pageInfo.back.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.completed.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.completedWorkstationTable.Key].accept(visitor, inputs.getInput(pageInfo.ongoingWorkstationTable.Key));
        }

        private void runStep()
        {
            int time = longSleepTime;

            _pageElements[pageInfo.start.Key].accept(visitor, new InputVal());
            Thread.Sleep(time);

            _pageElements[pageInfo.instruction.Key].accept(visitor, new InputVal());
            Thread.Sleep(time);

            _pageElements[pageInfo.personnel.Key].accept(visitor, new InputVal());
            Thread.Sleep(time);

            _pageElements[pageInfo.equiment.Key].accept(visitor, new InputVal());
            Thread.Sleep(time);

            _pageElements[pageInfo.asset.Key].accept(visitor, new InputVal());
            Thread.Sleep(time);

            _pageElements[pageInfo.checklist.Key].accept(visitor, new InputVal());
            Thread.Sleep(time);

            _pageElements[pageInfo.pause.Key].accept(visitor, new InputVal());
            Thread.Sleep(time);

            _pageElements[pageInfo.complete.Key].accept(visitor, new InputVal());
            Thread.Sleep(time);

            _pageElements[pageInfo.backToStep.Key].accept(visitor, new InputVal());
            Thread.Sleep(time);
        }

        private void deleteWorkStation()
        {
        }
    }
}