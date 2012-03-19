using System.Xml;

namespace Abidar
{
    public interface ITask
    {
        void Execute(XmlNode configuration);
    }
}
