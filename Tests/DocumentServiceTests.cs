using System;
using Infrastructure.Entities;
using Infrastructure.Services;
using Logic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public class DocumentServiceTests
{
    
    private readonly IDocumentService _documentService;

    public DocumentServiceTests()
    {
        var services = new ServiceCollection();
        services.AddTransient<IDocumentService, DocumentService>();

        var serviceProvider = services.BuildServiceProvider();

        _documentService = serviceProvider.GetService<IDocumentService>();
    }


    [Fact]
    public void ReadJsonFile_ShouldBeSuccessFull()
    {
        //Arrange
        var validPath = "/TestFiles/Document1.json";
        var expectedResult = new Document { Title = "Test title", Text = "Test text" };

        //Act
        var document = _documentService.ReadJsonFile(validPath);
        
        //Assert
        Assert.Equal(expectedResult.Title, document.Title);
        Assert.Equal(expectedResult.Text, document.Text);
    }
    
    [Fact]
    public void ReadJsonFile_ShouldThrowException()
    {
        //Arrange
        const string invalidPath = "dlkjfsdkjf lkhjk";

        //Act
        var ex = Assert.Throws<Exception>(() => _documentService.ReadJsonFile(invalidPath));
        
        //Assert
        Assert.Equal( "File does not exist.", ex.Message );
    }
    
    
}