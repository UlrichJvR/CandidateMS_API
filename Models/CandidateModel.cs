using System.ComponentModel.DataAnnotations;

namespace CandidateManagementSystem.Models;

public class CandidateModel
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }    
    
    [Required]
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    [Required]
    public string Role { get; set; }
    
    public string[] Skills { get; set; }
    
    public string Experience { get; set; }

    public DateTime DateCreated { get; set; }
}