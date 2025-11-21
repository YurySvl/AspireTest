using System.ComponentModel.DataAnnotations;

namespace UserApp.Web.Models;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    [StringLength(100, ErrorMessage = "First Name cannot exceed 100 characters")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    [StringLength(100, ErrorMessage = "Last Name cannot exceed 100 characters")]
    public required string LastName { get; set; }

    [Range(1, 149, ErrorMessage = "Age must be greater than 0 and less than 150")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Sex is required")]
    [AllowedValues(["Male", "Female"], ErrorMessage = "Sex must be either 'Male' or 'Female'")]
    public required string Sex { get; set; }
}