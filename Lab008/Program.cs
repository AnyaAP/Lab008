using Lab007;
using System.Xml.Serialization;


class Program
{
    static void Main()
    {
        Animal cowS = new Cow("Russia", true, "Moorka", "cattle");
        XmlSerializer serializer = new XmlSerializer(typeof(Animal));
        using FileStream fs = new("animal.xml", FileMode.OpenOrCreate);
        serializer.Serialize(fs, cowS);
    }
}