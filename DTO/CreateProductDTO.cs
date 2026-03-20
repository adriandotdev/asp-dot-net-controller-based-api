using System.ComponentModel.DataAnnotations;

public record CreateProductDTO
{
    [Required(ErrorMessage = "Product name is required")]
    public string Name {get; set;} = string.Empty!;

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal? Price {get; set;}
}