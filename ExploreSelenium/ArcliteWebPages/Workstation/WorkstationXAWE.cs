using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System.Collections.Generic;
using System.Linq;

namespace ExploreSelenium.ArcliteWebPages.WorkstationPage
{
    public class WorkstationXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;

        public KeyValuePair<string, IArcliteWebElement> ongoing;
        public KeyValuePair<string, IArcliteWebElement> completed;
        public KeyValuePair<string, IArcliteWebElement> ongoingWorkstationTable;
        public KeyValuePair<string, IArcliteWebElement> completedWorkstationTable;

        public KeyValuePair<string, IArcliteWebElement> stepsTable;
        public KeyValuePair<string, IArcliteWebElement> start;
        public KeyValuePair<string, IArcliteWebElement> pause;
        public KeyValuePair<string, IArcliteWebElement> complete;
        public KeyValuePair<string, IArcliteWebElement> instruction;

        public KeyValuePair<string, IArcliteWebElement> personnel;
        public KeyValuePair<string, IArcliteWebElement> asset;
        public KeyValuePair<string, IArcliteWebElement> equiment;
        public KeyValuePair<string, IArcliteWebElement> checklist;
        public KeyValuePair<string, IArcliteWebElement> producedGoodsQuality;

        public KeyValuePair<string, IArcliteWebElement> numberOfGoodsToBeProduced;
        public KeyValuePair<string, IArcliteWebElement> goodsProduceAreEfficient;
        public KeyValuePair<string, IArcliteWebElement> attachment;
        public KeyValuePair<string, IArcliteWebElement> backToStep;
        public KeyValuePair<string, IArcliteWebElement> back;

        public WorkstationXAWE(IArclitePage page)
        {
            this.initPage();
            this.setElementXpaths();
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }

        public WorkstationXAWE()
        {
            this.initPage();
        }

        //Dictionary<element name, XPath>
        private void initPage()
        {
            elementXpaths = new Dictionary<string, IArcliteWebElement>();

            IArcliteWebElement approveRequestConfirm = new ArcliteButton("Workstation Submit Delete", "//button[@id='btnDelete']");
            IArcliteWebElement approveRequestCancel = new ArcliteButton("Workstation Cancel Delete", "//button[@id='btnDelete']/parent::div/button[@title='No']");
            IArcliteWebElement search = new ArcliteSearch("Workstation Ongoing Search", "//input[@id='textSrchWrkflwName']", "//button[@id='anchSearchJobs']");
            ongoing = new KeyValuePair<string, IArcliteWebElement>("Workstation Ongoing", new ArcliteButton("Workstation Ongoing", "//a[@id='aOngoingTab']"));
            completed = new KeyValuePair<string, IArcliteWebElement>("Workstation Completed", new ArcliteButton("Workstation Completed", "//a[@id='aCompletedTab']"));
            ongoingWorkstationTable = new KeyValuePair<string, IArcliteWebElement>("Workstation Ongoing Table", new ArcliteDataTable("Workstation Ongoing Table", search, "//td[text()='", "']", "", null, null));
            search.elementName = "Workstation Compelted Search";
            completedWorkstationTable = new KeyValuePair<string, IArcliteWebElement>("Workstation Completed Table", new ArcliteDataTable("Workstation Completed Table", search, "//td[text()='", "']", "/parent::tr/td/div/a", null, null));

            search = new ArcliteSearch("Workstation Step Search", "//div[@id='tblSteps_filter']/label/input", null);
            stepsTable = new KeyValuePair<string, IArcliteWebElement>("Workstation Steps Table", new ArcliteDataTable("Workstation Steps Table", search, "//td[text()='", "']", "", null, null));
            start = new KeyValuePair<string, IArcliteWebElement>("Workstation Step Start", new ArcliteButton("Workstation Step Start", "//button[@id='timerPlay']"));
            pause = new KeyValuePair<string, IArcliteWebElement>("Workstation Step Pause", new ArcliteButton("Workstation Step Pause", "//button[@id='timerPause']"));
            complete = new KeyValuePair<string, IArcliteWebElement>("Workstation Step Complete", new ArcliteButton("Workstation Step Complete", "//button[@id='timerStop']"));
            instruction = new KeyValuePair<string, IArcliteWebElement>("Workstation Instruction", new ArcliteButton("Workstation Instruction", "//button[@data-menu-name='Instructions']"));

            personnel = new KeyValuePair<string, IArcliteWebElement>("Workstation Personnel", new ArcliteButton("Workstation Personnel", "//button[@data-menu-name='Personnel']"));
            asset = new KeyValuePair<string, IArcliteWebElement>("Workstation Equipments", new ArcliteButton("Workstation Equipments", "//button[@data-menu-name='Equipments']"));
            equiment = new KeyValuePair<string, IArcliteWebElement>("Workstation Output", new ArcliteButton("Workstation Output", "//button[@data-menu-name='Output']"));
            checklist = new KeyValuePair<string, IArcliteWebElement>("Workstation Parameters Input", new ArcliteButton("Workstation Parameters Input", "//button[@data-menu-name='Parameters Input']"));
            /*notReady*/
            producedGoodsQuality = new KeyValuePair<string, IArcliteWebElement>("Workstation Produced Goods Quality", new ArcliteButton("Workstation Produced Goods Quality", "//label[@for='chkIsLastStep']"));

            /*notReady*/
            numberOfGoodsToBeProduced = new KeyValuePair<string, IArcliteWebElement>("Workstation Number Of Good To Be Produced", new ArcliteTextBox("Workstation Number Of Good To Be Produced", "//button[@title='Instructions']"));

            /*notReady*/
            goodsProduceAreEfficient = new KeyValuePair<string, IArcliteWebElement>("Workstation Goods Produce Are Efficent", new ArcliteTextBox("Workstation Goods Produce Are Efficent", "//input[@id='txtInstructionName']"));
            attachment = new KeyValuePair<string, IArcliteWebElement>("Workstation Attachments", new ArcliteButton("Workstation Attachments", "//button[@data-menu-name='Attachments']"));
            backToStep = new KeyValuePair<string, IArcliteWebElement>("Workstation Back To Step", new ArcliteButton("Workstation Back To Step", "//button[@onclick='goBackTostepPage()']"));
            back = new KeyValuePair<string, IArcliteWebElement>("Workstation Back", new ArcliteButton("Workstation Back To Step", "//button[@id='btnBack']"));
        }

        public void setElementXpaths()
        {
            this.elementXpaths.Add(ongoing.Key, ongoing.Value);
            this.elementXpaths.Add(completed.Key, completed.Value);
            this.elementXpaths.Add(ongoingWorkstationTable.Key, ongoingWorkstationTable.Value);
            this.elementXpaths.Add(completedWorkstationTable.Key, completedWorkstationTable.Value);

            this.elementXpaths.Add(stepsTable.Key, stepsTable.Value);
            this.elementXpaths.Add(start.Key, start.Value);
            this.elementXpaths.Add(pause.Key, pause.Value);
            this.elementXpaths.Add(complete.Key, complete.Value);
            this.elementXpaths.Add(instruction.Key, instruction.Value);

            this.elementXpaths.Add(personnel.Key, personnel.Value);
            this.elementXpaths.Add(asset.Key, asset.Value);
            this.elementXpaths.Add(equiment.Key, equiment.Value);
            this.elementXpaths.Add(checklist.Key, checklist.Value);
            this.elementXpaths.Add(producedGoodsQuality.Key, producedGoodsQuality.Value);

            this.elementXpaths.Add(numberOfGoodsToBeProduced.Key, numberOfGoodsToBeProduced.Value);
            this.elementXpaths.Add(goodsProduceAreEfficient.Key, goodsProduceAreEfficient.Value);
            this.elementXpaths.Add(attachment.Key, attachment.Value);
            this.elementXpaths.Add(backToStep.Key, backToStep.Value);
            this.elementXpaths.Add(back.Key, back.Value);
        }
    }
}