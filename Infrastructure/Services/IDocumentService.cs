using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Infrastructure.Services;

public interface IDocumentService
{
    
    /// <summary>
    /// Loads json file from defined location to application
    /// </summary>
    /// <param name="pathToFile">Path to json file in project</param>
    /// <returns>Content of json file as Document entity</returns>
    Document ReadJsonFile(string pathToFile);
    
    /// <summary>
    /// Creates json file in defined location and stores document object in it
    /// </summary>
    /// <param name="document">document entity</param>
    /// <param name="pathToFile">path to file in project tree</param>
    void WriteJsonFile(Document document, string pathToFile);
    
    /// <summary>
    /// Loads XML file from defined location to application
    /// </summary>
    /// <param name="pathToFile">Path to json file in project</param>
    /// <returns>Content of XML file as Document entity</returns>
    Document ReadXmlFile(string pathToFile);
    
    /// <summary>
    /// Creates XML file in defined location and stores document object in it
    /// </summary>
    /// <param name="document">document entity</param>
    /// <param name="pathToFile">path to file in project tree</param>
    void WriteXmlFile(Document document, string pathToFile);

    /// <summary>
    /// Gets document entity from HTTP get request
    /// </summary>
    /// <param name="url">url of the storage</param>
    /// <returns>data from HTTP request as document entity</returns>
    Task<Document> LoadDocumentFromHttpAsync(string url);

}