namespace UnitTestExample.API.Utilities
{
    public class TryDataMethods
    {
        //data
        public static string[] examples = { "this", "is", "our", "data" };
        public static string[] boolexample = { "this", "is", "bool", "example" };

        //Method
        public string[] TryData()
        {
            return examples;
        }


        public string[] TryDataBool(bool check)
        {
            if (!check)
            {
                return new string[] {"errors"};
            }
            return boolexample;
        }
    }
}
