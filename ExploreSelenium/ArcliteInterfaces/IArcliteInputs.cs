using ExploreSelenium.ArcliteInputs;

namespace ExploreSelenium.ArcliteInterfaces
{
    /*
     * Repersents the inputs for an Arclite Element
     */

    public interface IArcliteInputs
    {
        /*
         * get the inputs for certain element based on the given key
         */

        InputVal getInput(string key);

        /*
         * set the inputs for certain element based on the given key
         */

        void setInput(string key, InputVal value);

        /*
         * switch the inputs to a secondary input for a element based on the given key
         */

        void switchInput(string key);
    }
}