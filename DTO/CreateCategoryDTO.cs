using System.ComponentModel.DataAnnotations;

public record CreateCategoryDTO
{
    [Required(ErrorMessage = "Category name is required")]
    public string Name {get; set;} = string.Empty;
}