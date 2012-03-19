using System.Collections;
using System.Web;
using System.Xml;

namespace Abidar.Example
{
    public class ClearCacheTask : ITask
    {
        public void Execute(XmlNode configuration)
        {
            foreach (DictionaryEntry entry in HttpRuntime.Cache)
            {
                HttpRuntime.Cache.Remove(entry.Key.ToString());
            }
        }
    }
}
