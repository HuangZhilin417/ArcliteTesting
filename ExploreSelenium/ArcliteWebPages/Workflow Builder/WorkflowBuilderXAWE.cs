using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System.Collections.Generic;
using System.Linq;

namespace ExploreSelenium.ArcliteWebPages.Workflow_Builder
{
    public class WorkflowBuilderXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> workflowTable;
        public KeyValuePair<string, IArcliteWebElement> add;
        public KeyValuePair<string, IArcliteWebElement> workflowName;
        public KeyValuePair<string, IArcliteWebElement> description;

        public KeyValuePair<string, IArcliteWebElement> AddWorkFlowSave;
        public KeyValuePair<string, IArcliteWebElement> AddWorkFlowCancel;
        public KeyValuePair<string, IArcliteWebElement> FinishBuildingWorkFlow;
        public KeyValuePair<string, IArcliteWebElement> addStep;
        public KeyValuePair<string, IArcliteWebElement> canvas;

        public KeyValuePair<string, IArcliteWebElement> stepName;
        public KeyValuePair<string, IArcliteWebElement> runTime;
        public KeyValuePair<string, IArcliteWebElement> cycleTime;
        public KeyValuePair<string, IArcliteWebElement> startStep;
        public KeyValuePair<string, IArcliteWebElement> lastStep;

        public KeyValuePair<string, IArcliteWebElement> instructionName;
        public KeyValuePair<string, IArcliteWebElement> instructionType;
        public KeyValuePair<string, IArcliteWebElement> attachment;
        public KeyValuePair<string, IArcliteWebElement> instructionSave;
        public KeyValuePair<string, IArcliteWebElement> instructionCancel;

        public KeyValuePair<string, IArcliteWebElement> stepDetail;
        public KeyValuePair<string, IArcliteWebElement> instruction;
        public KeyValuePair<string, IArcliteWebElement> personnel;
        public KeyValuePair<string, IArcliteWebElement> addPersonnelQualification;
        public KeyValuePair<string, IArcliteWebElement> addPersonnel;

        public KeyValuePair<string, IArcliteWebElement> personnelQualificationTable;
        public KeyValuePair<string, IArcliteWebElement> personnelTable;
        public KeyValuePair<string, IArcliteWebElement> machineQualificationTable;
        public KeyValuePair<string, IArcliteWebElement> addMachineQualification;
        public KeyValuePair<string, IArcliteWebElement> machineQualification;

        public KeyValuePair<string, IArcliteWebElement> addAsset;
        public KeyValuePair<string, IArcliteWebElement> assetTable;
        public KeyValuePair<string, IArcliteWebElement> equipment;
        public KeyValuePair<string, IArcliteWebElement> items;
        public KeyValuePair<string, IArcliteWebElement> checklists;

        public KeyValuePair<string, IArcliteWebElement> addItemIn;
        public KeyValuePair<string, IArcliteWebElement> addItemOut;
        public KeyValuePair<string, IArcliteWebElement> itemsTable;
        public KeyValuePair<string, IArcliteWebElement> selectType;
        public KeyValuePair<string, IArcliteWebElement> name;

        public KeyValuePair<string, IArcliteWebElement> notes;
        public KeyValuePair<string, IArcliteWebElement> checklistSave;
        public KeyValuePair<string, IArcliteWebElement> checklistCancel;
        public KeyValuePair<string, IArcliteWebElement> expectedValue;
        public KeyValuePair<string, IArcliteWebElement> closeStep;

        public WorkflowBuilderXAWE(IArclitePage page)
        {
            this.initPage();
            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }

        public WorkflowBuilderXAWE()
        {
            this.initPage();
        }

        //Dictionary<element name, XPath>
        private void initPage()
        {
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            IArcliteWebElement approveRequestConfirm = new ArcliteButton("Workflow Submit Delete", "//button[@id='btnDelete']");
            IArcliteWebElement approveRequestCancel = new ArcliteButton("Workflow Cancel Delete", "//button[@id='btnDelete']/parent::div/button[@title='No']");
            IArcliteWebElement search = new ArcliteSearch("WorkFlow Search", "//div[@id='tbWorkflows_filter']/label/input", null);
            workflowTable = new KeyValuePair<string, IArcliteWebElement>("Workflow Data Table", new ArcliteDataTable("Workflow Data Table", search, "//div[text()='", "']", "/parent::td/parent::tr/td/button[@title='Delete']", approveRequestConfirm, approveRequestCancel));
            add = new KeyValuePair<string, IArcliteWebElement>("Workflow Add", new ArcliteButton("Workflow Add", "//a[@title='Add Workflow']"));
            workflowName = new KeyValuePair<string, IArcliteWebElement>("Workflow Name", new ArcliteTextBox("Workflow Name", "//input[@id='txtWorkflowName']"));
            description = new KeyValuePair<string, IArcliteWebElement>("Workflow Description", new ArcliteTextBox("Workflow Description", "//textarea[@id='txtDescription']"));

            AddWorkFlowSave = new KeyValuePair<string, IArcliteWebElement>("Workflow Save", new ArcliteButton("Workflow Save", "//a[@onclick='updateWorkflow(this)']"));
            AddWorkFlowCancel = new KeyValuePair<string, IArcliteWebElement>("Workflow Cancel", new ArcliteButton("Workflow Cancel", "//a[@onclick='updateWorkflow(this)']/parent::div/button"));
            FinishBuildingWorkFlow = new KeyValuePair<string, IArcliteWebElement>("Workflow Finish Building", new ArcliteButton("Workflow Finish Building", "//a[@id='btnSaveWorkflow']"));
            addStep = new KeyValuePair<string, IArcliteWebElement>("Workflow Add Step", new ArcliteButton("Workflow Add Step", "//div[@id='btngrpElements']/a[@onclick='createStep()']"));
            canvas = new KeyValuePair<string, IArcliteWebElement>("Workflow Canvas", new ArcliteCanvas("Workflow Canvas", "//div[@id='wfCanvas']", addStep.Value));

            stepName = new KeyValuePair<string, IArcliteWebElement>("Workflow Step Name", new ArcliteTextBox("Workflow Step Name", "//input[@id='txtStepName']"));
            runTime = new KeyValuePair<string, IArcliteWebElement>("Workflow Run Time", new ArcliteTextBox("Workflow Run Time", "//input[@id='txtRuntime']"));
            cycleTime = new KeyValuePair<string, IArcliteWebElement>("Workflow Cycle Time", new ArcliteTextBox("Workflow Cycle Time", "//input[@id='txtCycletime']"));
            startStep = new KeyValuePair<string, IArcliteWebElement>("Workflow Start Step", new ArcliteButton("Workflow Start Step", "//label[@for='chkIsStartStep']"));
            lastStep = new KeyValuePair<string, IArcliteWebElement>("Workflow Last Step", new ArcliteButton("Workflow Last Step", "//label[@for='chkIsLastStep']"));

            instruction = new KeyValuePair<string, IArcliteWebElement>("Workflow Step Instruction", new ArcliteTextBox("Workflow Step Instruction", "//button[@title='Instructions']"));
            instructionName = new KeyValuePair<string, IArcliteWebElement>("Workflow Instruction Name", new ArcliteTextBox("Workflow Instruction Name", "//input[@id='txtInstructionName']"));
            instructionType = new KeyValuePair<string, IArcliteWebElement>("Workflow Instruction Type", new ArcliteSelect("Workflow Instruction Type", "//select[@id='ddlInstructionType']", "//select[@id='ddlInstructionType']"));
            attachment = new KeyValuePair<string, IArcliteWebElement>("Workflow Instruction Attachment", new ArcliteAttachment("Workflow Instruction Attachment", "//input[@id='arc-file']"));
            instructionSave = new KeyValuePair<string, IArcliteWebElement>("Workflow Instruction Save", new ArcliteButton("Workflow Instruction Save", "//button[@onclick='updateInstruction(1)']"));

            search = new ArcliteSearch("Workflow Personnel Qualification Search", "//input[@aria-controls='tbQualification']", null);

            instructionCancel = new KeyValuePair<string, IArcliteWebElement>("Workflow Instruction Cancel", new ArcliteButton("Workflow Instruction Cancel", "//button[@onclick=\"resetForm('#Instruction')\"]"));
            personnel = new KeyValuePair<string, IArcliteWebElement>("Workflow Step Personnel", new ArcliteButton("Workflow Step Personnel", "//button[@title='Personnels']"));
            addPersonnelQualification = new KeyValuePair<string, IArcliteWebElement>("Workflow Add Personnel Qualifiction", new ArcliteButton("Workflow Add Personnel Qualifiction", "//button[@onclick='getQualification(1)']"));
            addPersonnel = new KeyValuePair<string, IArcliteWebElement>("Workflow Add Personnel", new ArcliteButton("Workflow Add Personnel", "//button[@onclick=\"getPersonnelSpecific('AllPersonnels')\"]"));
            personnelQualificationTable = new KeyValuePair<string, IArcliteWebElement>("Workflow Personnel Qualification Table", new ArcliteDataTable("Workflow Personnel Qualification Table", search, "//div[text()='", "']", "", null, null));

            search = new ArcliteSearch("Workflow Personnel Search", "//input[@aria-controls='tbPersonnelSpecifics']", null);
            personnelTable = new KeyValuePair<string, IArcliteWebElement>("Workflow Personnel Table", new ArcliteDataTable("Workflow Personnel Table", search, "//td[text()='", "']", "", null, null));
            addMachineQualification = new KeyValuePair<string, IArcliteWebElement>("Workflow Add Machine Qualifiction", new ArcliteButton("Workflow Add Machine Qualifiction", "//button[@onclick='getAssetQualification(2)']"));
            addAsset = new KeyValuePair<string, IArcliteWebElement>("Workflow Add Asset", new ArcliteButton("Workflow Add Asset", "//button[@onclick='getEquipementSpecific()']"));
            search = new ArcliteSearch("Workflow Machine Qualification Search", "//input[@aria-controls='tbQualification']", null);
            machineQualificationTable = new KeyValuePair<string, IArcliteWebElement>("Workflow Machine Qualification Table", new ArcliteDataTable("Workflow Machine Qualification Table", search, "//div[text()='", "']", "", null, null));
            search = new ArcliteSearch("Workflow Asset Search", "//input[@aria-controls='tbEquipnentSpecifics']", null);
            assetTable = new KeyValuePair<string, IArcliteWebElement>("Workflow Asset Table", new ArcliteDataTable("Workflow Asset Table", search, "//div[text()='", "']", "", null, null));

            items = new KeyValuePair<string, IArcliteWebElement>("Workflow Step Items", new ArcliteButton("Workflow Step Items", "//button[@title='Items']"));
            addItemIn = new KeyValuePair<string, IArcliteWebElement>("Workflow Add Item In", new ArcliteButton("Workflow Add Item In", "//button[@onclick='getResources(1)']"));
            addItemOut = new KeyValuePair<string, IArcliteWebElement>("Workflow Add Item Out", new ArcliteButton("Workflow Add Item Out", "//button[@onclick='getResources(2)']"));
            search = new ArcliteSearch("Workflow Personnel Search", "//input[@aria-controls='tbResources']", null);
            itemsTable = new KeyValuePair<string, IArcliteWebElement>("Workflow Items Table", new ArcliteDataTable("Workflow Items Table", search, "//div[text()='", "']", "", null, null));
            checklists = new KeyValuePair<string, IArcliteWebElement>("Workflow Checklists", new ArcliteButton("Workflow Checklists", "//button[@title='Checklists']"));

            selectType = new KeyValuePair<string, IArcliteWebElement>("Workflow Select Type", new ArcliteSelect("Workflow Select Type", "//select[@id='ddlChecklistType']", "//select[@id='ddlChecklistType']"));
            name = new KeyValuePair<string, IArcliteWebElement>("Workflow Select Checklist Name", new ArcliteTextBox("Workflow Select Checklist Name", "//input[@id='txtChecklistName']"));
            notes = new KeyValuePair<string, IArcliteWebElement>("Workflow Select Checklist Notes", new ArcliteTextBox("Workflow Select Checklist Notes", "//textarea[@id='txtNotes']"));
            expectedValue = new KeyValuePair<string, IArcliteWebElement>("Workflow Expected Value", new ArcliteTextBox("Workflow Expected Value", "//button[@title='Checklists']"));
            equipment = new KeyValuePair<string, IArcliteWebElement>("Workflow Equipment", new ArcliteButton("Workflow Equipment", "//button[@title='Equipments']"));

            checklistSave = new KeyValuePair<string, IArcliteWebElement>("Workflow Checklist Save", new ArcliteButton("Workflow Checklist Save", "//button[@onclick='updateChecklist(1)']"));
            checklistCancel = new KeyValuePair<string, IArcliteWebElement>("Workflow Checklist Cancel", new ArcliteButton("Workflow Checklist Cancel", "//button[@onclick='resetForm('#Checklist')']"));
            closeStep = new KeyValuePair<string, IArcliteWebElement>("Workflow Close Step", new ArcliteButton("Workflow Close Step", "//span[@onclick='closeNav()']"));
        }

        public void setElementXpaths()
        {
            this.elementXpaths.Add(workflowTable.Key, workflowTable.Value);
            this.elementXpaths.Add(add.Key, add.Value);
            this.elementXpaths.Add(workflowName.Key, workflowName.Value);
            this.elementXpaths.Add(description.Key, description.Value);

            this.elementXpaths.Add(AddWorkFlowSave.Key, AddWorkFlowSave.Value);
            this.elementXpaths.Add(AddWorkFlowCancel.Key, AddWorkFlowCancel.Value);
            this.elementXpaths.Add(FinishBuildingWorkFlow.Key, FinishBuildingWorkFlow.Value);
            this.elementXpaths.Add(addStep.Key, addStep.Value);
            this.elementXpaths.Add(canvas.Key, canvas.Value);

            this.elementXpaths.Add(stepName.Key, stepName.Value);
            this.elementXpaths.Add(runTime.Key, runTime.Value);
            this.elementXpaths.Add(cycleTime.Key, cycleTime.Value);
            this.elementXpaths.Add(startStep.Key, startStep.Value);
            this.elementXpaths.Add(lastStep.Key, lastStep.Value);

            this.elementXpaths.Add(instruction.Key, instruction.Value);
            this.elementXpaths.Add(instructionName.Key, instructionName.Value);
            this.elementXpaths.Add(instructionType.Key, instructionType.Value);
            this.elementXpaths.Add(attachment.Key, attachment.Value);
            this.elementXpaths.Add(instructionSave.Key, instructionSave.Value);

            this.elementXpaths.Add(instructionCancel.Key, instructionCancel.Value);
            this.elementXpaths.Add(personnel.Key, personnel.Value);
            this.elementXpaths.Add(addPersonnelQualification.Key, addPersonnelQualification.Value);
            this.elementXpaths.Add(addPersonnel.Key, addPersonnel.Value);
            this.elementXpaths.Add(personnelQualificationTable.Key, personnelQualificationTable.Value);

            this.elementXpaths.Add(personnelTable.Key, personnelTable.Value);
            this.elementXpaths.Add(addMachineQualification.Key, addMachineQualification.Value);
            this.elementXpaths.Add(addAsset.Key, addAsset.Value);
            this.elementXpaths.Add(machineQualificationTable.Key, machineQualificationTable.Value);
            this.elementXpaths.Add(assetTable.Key, assetTable.Value);

            this.elementXpaths.Add(items.Key, items.Value);
            this.elementXpaths.Add(addItemIn.Key, addItemIn.Value);
            this.elementXpaths.Add(addItemOut.Key, addItemOut.Value);
            this.elementXpaths.Add(itemsTable.Key, itemsTable.Value);
            this.elementXpaths.Add(checklists.Key, checklists.Value);

            this.elementXpaths.Add(selectType.Key, selectType.Value);
            this.elementXpaths.Add(name.Key, name.Value);
            this.elementXpaths.Add(notes.Key, notes.Value);
            this.elementXpaths.Add(expectedValue.Key, expectedValue.Value);
            this.elementXpaths.Add(equipment.Key, equipment.Value);

            this.elementXpaths.Add(checklistSave.Key, checklistSave.Value);
            this.elementXpaths.Add(checklistCancel.Key, checklistCancel.Value);
            this.elementXpaths.Add(closeStep.Key, closeStep.Value);
        }
    }
}