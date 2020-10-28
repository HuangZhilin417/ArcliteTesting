using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Personnel
{
    public class PersonnelPage : ConfigurationsPage, IArclitePage
    {
        new public string _pageTitle;
        new public Dictionary<string, IArcliteWebElement> _pageElements;
        new public PersonnelXAWE pageInfo;
        IActionsVisitor _visitor;
        public PersonnelPage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Personnel Page";
            _visitor = visitor;
            pageInfo = new PersonnelXAWE(this);
            _pageElements = base.pageElements;
        }

        new public void runTests(ArcliteTestAction action)
        {
            Util.navigateToWeb(this, _visitor, true);

            switch (action)
            {
                case ArcliteTestAction.add:
                    addingPersonnel();
                    break;
                case ArcliteTestAction.delete:
                    deletingPersonnel();
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

        private void deletingPersonnel()
        {
            _pageElements[pageInfo.dataTable.Key].accept(_visitor, inputs.getInput(pageInfo.userName.Key));
        }
    }
}
