using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Infrastructure.Entities;
using Infrastructure.Services;
using Newtonsoft.Json;

namespace Logic.Services;

public class DocumentService : IDocumentService
{
    public DocumentService()
    {
    }

    public Document ReadJsonFile(string pathToFile)
    {
        var file = $"{Environment.CurrentDirectory}{pathToFile}";
        CheckIfFileExists(file);

        using StreamReader r = new StreamReader(file);
        string json = r.ReadToEnd();
        var document = JsonConvert.DeserializeObject<Document>(json);
        if (document == null)
            throw new Exception("Error while parsing json file");

        return document;
    }

    public void WriteJsonFile(Document document, string pathToFile)
    {
        string jsonString = JsonConvert.SerializeObject(document);
        File.WriteAllText($"{Environment.CurrentDirectory}{pathToFile}", jsonString);
    }

    public Document ReadXmlFile(string pathToFile)
    {
        var file = $"{Environment.CurrentDirectory}{pathToFile}";
        CheckIfFileExists(file);

        var doc = new XmlDocument();
        doc.Load(file);
        var serializer = new XmlSerializer(typeof(Document));
        using XmlReader reader = new XmlNodeReader(doc);
        var result = (Document)serializer.Deserialize(reader);
        if (result == null)
            throw new Exception("Error while parsing XML file");

        return result;
    }

    public void WriteXmlFile(Document document, string pathToFile)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Document));
        serializer.Serialize(File.Create($"{Environment.CurrentDirectory}{pathToFile}"), document);
    }

    public Task<Document> LoadDocumentFromHttpAsync(string url)
    {
        //TODO: Call storage through HttpClient, then parse data from response of HTTP request to document entity and return it
        
        throw new NotImplementedException();
    }

    private static void CheckIfFileExists(string filePath)
    {
        if(!File.Exists(filePath))
            throw new Exception("File does not exist.");
    }
}