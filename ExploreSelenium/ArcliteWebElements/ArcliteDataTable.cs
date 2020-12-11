using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteWebElementActionsVisitor;

namespace ExploreSelenium.ArcliteWebElements
{
    /*
     * Repersents a Data Table element on ArcLite
     */

    public class ArcliteDataTable : ArcliteWebElement, IArcliteWebElement
    {
        private string _elementName;
        public string _tableEntryFirst;
        public string _tableEntrySecond;

        public IArcliteWebElement _searchElement;
        public IArcliteWebElement _confirmDelete;
        public IArcliteWebElement _cancelDelete;
        public string _expand;
        public string _deleteFirst;
        public string _deleteSecond;
        public string _deleteXpathWithEntry;

        /*
         * Creates a Data Table variable with its specific name and xpath, data table without expand
         */

        public ArcliteDataTable(string name, IArcliteWebElement search, string tableEntryFirst, string tableEntrySecond, string deleteXpathWithEntry, IArcliteWebElement confirmDelete, IArcliteWebElement cancelDelete) : base(name, "")
        {
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

        /*
         * Creates a Data Table variable with its specific name and xpath, data table with expand and delete
         */

        public ArcliteDataTable(string name, IArcliteWebElement search, string tableEntryFirst, string tableEntrySecond, string expandWithEntry, string deleteFirst, string deleteSecond, IArcliteWebElement confirmDelete, IArcliteWebElement cancelDelete) : base(name, "")
        {
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