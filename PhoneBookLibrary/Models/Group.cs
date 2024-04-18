using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookLibrary.Models;

[Index(nameof(Name))]
public class Group
{
  [Key]
  public int Id { get; set; }

  [Required]
  public string Name { get; set; }
  public List<Contact> Contacts { get; set; }
}
