using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages.ConfigurationWebPage.Settings.Qualification
{
    public class QualificationPage : ConfigurationsPage, IArclitePage
    {
        public string _pageTitle;
        public Dictionary<string, IArcliteWebElement> _pageElements;
        public QualificationXAWE pageInfo;
        IActionsVisitor _visitor;
        public QualificationPage(IActionsVisitor visitor) : base(visitor)
        {
            base.pageTitle = "Setting Qualifications";
            _visitor = visitor;
            pageInfo = new QualificationXAWE(this);
            _pageElements = base.pageElements;


        }

        new public void runTests()
        {
        }
    }
}
