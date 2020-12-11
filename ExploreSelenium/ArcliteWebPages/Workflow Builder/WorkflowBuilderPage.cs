using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System.Collections.Generic;
using System.Threading;

namespace ExploreSelenium.ArcliteWebPages.Workflow_Builder
{
    /*
     * Repersents the Workflow Builder Page on ArcLite
     */

    public class WorkflowBuilderPage : ArcliteWebPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public WorkflowBuilderXAWE pageInfo;
        private IActionsVisitor visitor;

        /*
         * Creates a WorkflowBuilder page and initializes page title and all of this page's Xpath
         */

        public WorkflowBuilderPage(IActionsVisitor visitor, IArcliteInputs inputs) : base(visitor, inputs)
        {
            base.pageTitle = "Workflow Builder";
            this.visitor = visitor;
            pageInfo = new WorkflowBuilderXAWE(this);
            _pageElements = base.pageElements;
        }

        /*
         * runs the test for Workflow Builder
         */

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, this.visitor, true, inputs);
            switch (action)
            {
                case ArcliteTestAction.add:
                    System.Console.WriteLine("Adding Workflow");
                    addWorkflow();
                    System.Console.WriteLine("Finished Adding Workflow");
                    break;

                case ArcliteTestAction.delete:
                    System.Console.WriteLine("Deleting Workflow");
                    deleteWorkflow();
                    System.Console.WriteLine("Finished Deleting Workflow");
                    break;

                default:
                    break;
            }
        }

        private void deleteWorkflow()
        {
            _pageElements[pageInfo.workflowTable.Key].accept(visitor, inputs.getInput(pageInfo.workflowTable.Key));
        }

        private void addWorkflow()
        {
            _pageElements[pageInfo.add.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.workflowName.Key].accept(visitor, inputs.getInput(pageInfo.workflowName.Key));
            _pageElements[pageInfo.description.Key].accept(visitor, inputs.getInput(pageInfo.description.Key));
            _pageElements[pageInfo.AddWorkFlowSave.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.canvas.Key].accept(visitor, new InputVal("1000", "0"));
            this.editWorkFlow("Start");
            _pageElements[pageInfo.canvas.Key].accept(visitor, new InputVal("0", "0"));
            inputs.switchInput(pageInfo.stepName.Key);
            this.editWorkFlow("end");

            Thread.Sleep(longSleepTime);
            _pageElements[pageInfo.FinishBuildingWorkFlow.Key].accept(visitor, new InputVal());
        }

        private void editWorkFlow(string startOrLast)
        {
            _pageElements[pageInfo.stepName.Key].accept(visitor, inputs.getInput(pageInfo.stepName.Key));
            _pageElements[pageInfo.runTime.Key].accept(visitor, inputs.getInput(pageInfo.runTime.Key));
            Thread.Sleep(longSleepTime);
            _pageElements[pageInfo.cycleTime.Key].accept(visitor, inputs.getInput(pageInfo.cycleTime.Key));
            if (startOrLast.Equals("Start"))
            {
                _pageElements[pageInfo.startStep.Key].accept(visitor, new InputVal());
            }
            else
            {
                _pageElements[pageInfo.lastStep.Key].accept(visitor, new InputVal());
            }

            _pageElements[pageInfo.instruction.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.instructionName.Key].accept(visitor, inputs.getInput(pageInfo.instructionName.Key));
            _pageElements[pageInfo.attachment.Key].accept(visitor, inputs.getInput(pageInfo.attachment.Key));
            _pageElements[pageInfo.instructionSave.Key].accept(visitor, new InputVal());

            _pageElements[pageInfo.personnel.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.addPersonnelQualification.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.personnelQualificationTable.Key].accept(visitor, inputs.getInput(pageInfo.personnelQualificationTable.Key));
            _pageElements[pageInfo.addPersonnel.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.personnelTable.Key].accept(visitor, inputs.getInput(pageInfo.personnelTable.Key));

            _pageElements[pageInfo.equipment.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.addMachineQualification.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.machineQualificationTable.Key].accept(visitor, inputs.getInput(pageInfo.machineQualificationTable.Key));
            _pageElements[pageInfo.addAsset.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.assetTable.Key].accept(visitor, inputs.getInput(pageInfo.assetTable.Key));

            _pageElements[pageInfo.items.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.addItemIn.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.itemsTable.Key].accept(visitor, inputs.getInput(pageInfo.itemsTable.Key));
            Thread.Sleep(shortSleepTime);

            _pageElements[pageInfo.addItemOut.Key].accept(visitor, new InputVal());
            Thread.Sleep(shortSleepTime);
            _pageElements[pageInfo.itemsTable.Key].accept(visitor, inputs.getInput(pageInfo.itemsTable.Key));

            _pageElements[pageInfo.checklists.Key].accept(visitor, new InputVal());
            _pageElements[pageInfo.name.Key].accept(visitor, inputs.getInput(pageInfo.name.Key));
            _pageElements[pageInfo.notes.Key].accept(visitor, inputs.getInput(pageInfo.notes.Key));
            Thread.Sleep(shortSleepTime);
            _pageElements[pageInfo.checklistSave.Key].accept(visitor, new InputVal());

            _pageElements[pageInfo.closeStep.Key].accept(visitor, new InputVal());
        }
    }
}