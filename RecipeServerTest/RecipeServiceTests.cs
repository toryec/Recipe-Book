using NUnit.Framework;
using BlazorApp.Server.Services;
using Moq;
using BlazorApp.Server.Data;
using BlazorApp.Server.Models;
using System.Collections;
using System.Threading.Tasks;
using FluentAssertions;

namespace RecipeServerTest;

public class RepoServiceTests
{
    private Mock<IRepo<Recipe>> iRepoRecipeMock = null!;
    private RecipeService recipeService = null!;

    [SetUp]
    public void Setup()
    {
       iRepoRecipeMock = new Mock<IRepo<Recipe>>(MockBehavior.Strict);
       recipeService = new RecipeService(iRepoRecipeMock.Object);
    }

    [Test]
    public async Task GetAllRecipiesAsync_RecipesReturned_ReturnsTaskOfIEnumerableOfRecipe()
    {
        //Arrange
        var expectedResult = new[] { new Recipe() };

        iRepoRecipeMock.Setup(r => r.GetAllAsync()).ReturnsAsync(expectedResult);

        //Act
        var actualResult = await recipeService.GetAllRecipesAsync();

        //Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public async Task GetRecipeByIdAsync_RecipeReturned_ReturnsTaskofRecipe()
    {
        //Arrange
        const int id = 2;
        var expectedResult = new Recipe { Id = id };

        iRepoRecipeMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(expectedResult);

        //Act
        var actualResult = await recipeService.GetRecipeByIdAsync(id);

        //Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
        
    }

    [Test]
    public async Task DeleteRecipeAsync_IsSuccessfull_ReturnsTaskofBool()
    {
        // Arrange
        //var expectedResult = false;
        var expectedId = 2;

        iRepoRecipeMock.Setup(r => r.DeleteAsync(expectedId)).ReturnsAsync(false);
        
        //Act
        var actualResult = await recipeService.DeleteRecipeAsync(2);

        //Assert
        Assert.That(actualResult, Is.False);
    }

    [Test]
    public async Task CreateRecipeAsync_CreatesRecipe_ReturnsTaskOfRecipe()
    {
        //Arrange
        var expectedInput = new Recipe();
        Recipe? actualInput = default;
        var expectedResult = new Recipe();

        iRepoRecipeMock//.Setup(r => r.CreateAsync(expectedInput)).ReturnsAsync(expectedInput);
        .Setup(r => r.CreateAsync(It.IsAny<Recipe>()))
        .Callback<Recipe>((r) => actualInput = r).ReturnsAsync(expectedResult);

        //Act
        await recipeService.CreateRecipeAsync(expectedInput);

        //Assert
        Assert.That(actualInput, Is.EqualTo(expectedInput));
        
    }

   /* [Test] // Another Way To Test AddRecipe Method
    public async Task AddRecipeAsync_CreatesRecipe_ReturnsTask()
    {
        //Arrange
        var expectedInput = new Recipe();

        iRepoRecipeMock.Setup(r => r.CreateAsync(expectedInput))
        .Returns(Task.CompletedTask)
        .Verifiable();

        //Act
        await recipeService.AddRecipeAsync(expectedInput);

        //Assert
        iRepoRecipeMock.Verify();
        
    }*/

    [Test]
    public async Task UpdateRecipeAsync_UpdatesRecipe_ReturnsTaskOfBool()
    {
        // Arrange
        const long id = 2;
        var expectedInput = new Recipe();
        var expectedResult = new Recipe { Id = id };

        iRepoRecipeMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(expectedResult);
        var getByIdResult = await recipeService.GetRecipeByIdAsync(id);
            //getByIdResult.Id = expectedInput.Id;
            getByIdResult.Author = expectedInput.Author;
        iRepoRecipeMock.Setup(r => r.UpdateAsync(getByIdResult)).ReturnsAsync(false);
        
        //Act
        var actualResult = await recipeService.UpdateRecipeAsync(id,expectedInput);      
        //Assert
        Assert.That(actualResult, Is.True);
        
    }


}