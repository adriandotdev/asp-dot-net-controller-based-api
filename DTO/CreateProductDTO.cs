public record CreateProductDTO
{
    public string Name {get; set;} = string.Empty!;
    public decimal Price {get; set;}
}