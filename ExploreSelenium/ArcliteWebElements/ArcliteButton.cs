﻿using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;

namespace ExploreSelenium.ArcliteWebElements
{
    /*
     * Repersents a Button element on ArcLite
     */

    public class ArcliteButton : ArcliteWebElement, IArcliteWebElement
    {
        public string _elementName;
        public string _elementXPath;

        /*
         * Creates a Button variable with its specific name and xpath
         */

        public ArcliteButton(string name, string xPath) : base(name, xPath)
        {
            _elementName = base.elementName;
            _elementXPath = base.elementXPath;
        }

        new public void accept(IActionsVisitor visitor, InputVal input)
        {
            visitor.visitButton(this);
        }
    }
}