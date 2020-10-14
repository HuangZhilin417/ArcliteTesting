using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebElements
{
    class ArcliteDataTable : ArcliteWebElement, IArcliteWebElement
    {
        string _elementName;
        public string _tableEntryFirst;
        public string _tableEntrySecond;
        ArcliteWebElementType _elementType;
        public IArcliteWebElement _searchElement;
        public ArcliteDataTable(string name, IArcliteWebElement search, string tableEntryFirst, string tableEntrySecond) : base(name, "")
        {
            _elementType = ArcliteWebElementType.Table;
            _searchElement = search;
            _tableEntryFirst = tableEntryFirst;
            _tableEntrySecond = tableEntrySecond;
            _elementName = base.elementName;

        }
    }
}
