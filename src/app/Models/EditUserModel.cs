using System.ComponentModel.DataAnnotations;
using app.Data.Entities.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.Models;

public class EditUserModel
{
    public Guid UserId { get; set; }
    
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    [Required(ErrorMessage = "El correo electrónico es requerido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "El tipo es requerido.")]
    public UserType Type { get; set; }
      
    public List<SelectListItem> UserTypes { get; set; }
}