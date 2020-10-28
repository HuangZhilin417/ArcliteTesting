using ExploreSelenium.ArcliteWebElements;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using ExploreSelenium.ArcliteInputs;

namespace ExploreSelenium.ArcliteWebElementActionsVisitor
{
    public interface IActionsVisitor
    {

        void visitButton(ArcliteButton element);
        void visitSelect(ArcliteSelect element, InputVal wanted);
        void visitTextBox(ArcliteTextBox element, InputVal wanted);
        void visitCalender(ArcliteCalender element, InputVal wanted);
        void visitDataTable(ArcliteDataTable element, InputVal wanted);
        void visitSearch(ArcliteSearch arcliteSearch, InputVal wanted);
        void switchFrame();
    }
}
