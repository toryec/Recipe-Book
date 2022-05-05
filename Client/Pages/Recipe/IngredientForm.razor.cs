using BlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Pages.Recipe;

public partial class IngredientForm
{

    private IngredientDto originalIngredientDto;

    [Parameter]
    public IngredientDto IngredientDto { get; set; } = default!;

    [Parameter]
    public EventCallback<bool> HandleValidSubmit{  get; set;} 

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (IngredientDto is not null)
        {
            originalIngredientDto = IngredientDto;

            IngredientDto = new IngredientDto
            {
                Id = originalIngredientDto.Id,
                ItemAmount = originalIngredientDto.ItemAmount,
                ItemName = originalIngredientDto.ItemName
            };
        }
    }

    public async void OnSave()
    {
        Console.WriteLine($"Original: {originalIngredientDto.ItemName}; HashCode: {originalIngredientDto.GetHashCode()}");
        Console.WriteLine($"Parameter: {IngredientDto.ItemName}; HashCode: {IngredientDto.GetHashCode()}");
        originalIngredientDto = IngredientDto;
        Console.WriteLine($"After Original: {originalIngredientDto.ItemName}; HashCode: {originalIngredientDto.GetHashCode()}");
        Console.WriteLine($"After Parameter: {IngredientDto.ItemName}; HashCode: {IngredientDto.GetHashCode()}");
        await HandleValidSubmit.InvokeAsync(true);
    }

    public async void OnCancel()
    {
        IngredientDto = originalIngredientDto;
        await HandleValidSubmit.InvokeAsync(false);
    }
}