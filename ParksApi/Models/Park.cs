using System.ComponentModel.DataAnnotations;

namespace ParksApi.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required]
    [StringLength(100)]          
    public string Name { get; set; } 
    [Required]
    [StringLength(500)]
    public string Description { get; set; }
    [Required]
    [StringLength(20)]      
    public string FeeRequired { get; set; }        
    [Required]
    [StringLength(20)]  
    public string Status { get; set; }
    [Required]
    [StringLength(20)]  
    public string CampingAllowed { get; set; }     
    [Required]
    [StringLength(20)]  
    public string DogsAllowed { get; set; }
  }
}