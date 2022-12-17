using Lab007;
using System.Xml.Serialization;


class Program
{
    static void Main()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Animal));
        using (FileStream fs = new("" +
            "C:\\Users\\anyap\\source\\repos\\Lab008\\Lab008\\bin\\Debug\\net6.0\\animal.xml", FileMode.OpenOrCreate))
        {
            Animal? cowD = serializer.Deserialize(fs) as Animal;
            Console.WriteLine($"Country: {cowD?.Country}" +
                $", HideFromOtherAnimals: {cowD?.HideFromOtherAnimals}" +
                $", Name: {cowD?.Name}" +
                $", WhatAnimal: {cowD?.WhatAnimal} ");
        }
    }
}