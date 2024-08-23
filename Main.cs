using System;
using Repository;

public class Program
{
    public static string LoadXML(string fileName)
    {
        return File.ReadAllText(fileName);
    }

    public static string LoadJson(string fileName)
    {
        return File.ReadAllText(fileName);
    }

    public static void Main(string[] args)
    {
        Manager manager = new Manager();
        manager.OnRetrieved += OnRetrieved;
        manager.OnGetType += OnGetType;

        string content = LoadJson("data.json");

        manager.RegisterManager("sensor",content, (int)ItemType.JSON);
 
        // string content = LoadJson("data.xml");

        // manager.RegisterManager("sensor",content, (int)ItemType.XML);

        manager.RetrieveManager("sensor");

        manager.GetTypeManager("sensor");
        manager.RegisterManager("sensor2",content, (int)ItemType.JSON);
        manager.DeRegisterManager("sensor2");
        

    }
    public static void OnRetrieved(string? result) 
    {
        Console.WriteLine("Retrieve: " + result);
    }
    public static void OnGetType(int? result)
    {
        Console.WriteLine("Gettype: " + result);
    }

}