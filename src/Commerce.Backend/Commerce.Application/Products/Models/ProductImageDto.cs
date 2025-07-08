using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Commerce.Application.Products.Models;

public class ProductImageDto
{
    [Required]
    public IFormFile File { get; set; } = default!;
}
