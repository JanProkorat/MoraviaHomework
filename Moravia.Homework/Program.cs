using System;
using Infrastructure.Entities;
using Infrastructure.Services;
using Logic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Moravia.Homework;

internal static class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddTransient<IDocumentService, DocumentService>()
            .BuildServiceProvider();

        var documentService = serviceProvider.GetService<IDocumentService>();
        if (documentService == null)
            throw new Exception("Service not found.");
        
        var documentXml = documentService.ReadXmlFile("/SourceFiles/Document1.xml");
        Console.WriteLine($"{documentXml.Title} {documentXml.Text}");
        
        var documentJson = documentService.ReadJsonFile("/SourceFiles/Document1.json");
        Console.WriteLine($"{documentJson.Title} {documentJson.Text}");

        var document = new Document() { Text = "Document", Title = "Title" };
        documentService.WriteJsonFile(document, "/SourceFiles/Document2.json");
        documentService.WriteXmlFile(document, "/SourceFiles/Document2.xml");
    }
}