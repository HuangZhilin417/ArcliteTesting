using ExploreSelenium.ArcliteWebElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebElementActionsVisitor
{
    public interface IActionsVisitor
    {
        void visitButton(ArcliteButton element);
        void visitSelect(ArcliteSelect element, string wanted);
        void visitTextBox(ArcliteTextBox element, string wanted);
        void visitCalender(ArcliteCalender element, string wanted);
    }
}
