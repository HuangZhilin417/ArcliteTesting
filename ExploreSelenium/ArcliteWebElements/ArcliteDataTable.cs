using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebElements
{
    public class ArcliteDataTable : ArcliteWebElement, IArcliteWebElement
    {
        string _elementName;
        public string _tableEntryFirst;
        public string _tableEntrySecond;
        ArcliteWebElementType _elementType;
        public IArcliteWebElement _searchElement;
        public IArcliteWebElement _confirmDelete;
        public IArcliteWebElement _cancelDelete;
        public string _expand;
        public string _deleteFirst;
        public string _deleteSecond;
        public string _deleteXpathWithEntry;
        public ArcliteDataTable(string name, IArcliteWebElement search, string tableEntryFirst, string tableEntrySecond, string deleteXpathWithEntry, IArcliteWebElement confirmDelete, IArcliteWebElement cancelDelete) : base(name, "")
        {
            _elementType = ArcliteWebElementType.Table;
            _searchElement = search;
            _tableEntryFirst = tableEntryFirst;
            _tableEntrySecond = tableEntrySecond;
            _deleteXpathWithEntry = deleteXpathWithEntry;
            _confirmDelete = confirmDelete;
            _cancelDelete = cancelDelete;
            _expand = null;
            _deleteFirst = null;
            _deleteSecond = null;
            _elementName = base.elementName;

        }

        public ArcliteDataTable(string name, IArcliteWebElement search, string tableEntryFirst, string tableEntrySecond, string expandWithEntry, string deleteFirst, string deleteSecond, IArcliteWebElement confirmDelete, IArcliteWebElement cancelDelete) : base(name, "")
        {
            _elementType = ArcliteWebElementType.Table;
            _searchElement = search;
            _tableEntryFirst = tableEntryFirst;
            _tableEntrySecond = tableEntrySecond;
            _confirmDelete = confirmDelete;
            _cancelDelete = cancelDelete;
            _expand = expandWithEntry;
            _deleteFirst = deleteFirst;
            _deleteSecond = deleteSecond;
            _elementName = base.elementName;

        }

        new public void accept(IActionsVisitor visitor, InputVal input)
        {
                visitor.visitDataTable(this, input);
                
        }
    }
}
