using System.Text.RegularExpressions;

namespace CP.Infra.Common.HelperTools
{
    public class CharacterHelper
    {
        public static string SomenteNumeros(string texto)
        {
            string resultString = string.Empty;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(texto, "");
            return resultString;
        }
    }
}
