using System.ComponentModel.DataAnnotations;

namespace Clinica.Web.Data.Entities;

public class Client
{
    public int Id { get; set; }

    //[Display(Name = "Nome")]
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    //public string LastName { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]{9}$", ErrorMessage = "Incorret Data")]
    public string BI { get; set; }

    //[EmailAddress(ErrorMessage = "The Email is Not Valid!")]
    [RegularExpression(".+\\@.+\\..+", ErrorMessage = "The Email is Not Valid!")]
    public string Email { get; set; }

    //[Display(Name = "Contato")]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "The Phone Number is Not Valid!")]
    public string Phone { get; set; }

    //[Display(Name = "Data Nascimento")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
    [DataType(DataType.Date)]
    public DateTime Birth { get; set; }

    //[Display(Name = "Endereço")]
    [MaxLength(300)]
    public string Address { get; set; }

    [Display(Name = "Image")]
    public string? ImageUrl { get; set; }




}
