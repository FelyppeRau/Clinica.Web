using System.ComponentModel.DataAnnotations;

namespace Clinica.Web.Data.Entities;

public class Client
{
    public int Id { get; set; }

    [Display(Name = "Nome")]
    public string Name { get; set; }

    //public string LastName { get; set; }

    public string CPF { get; set; }

    public string Email { get; set; }

    [Display(Name = "Contato")]
    public string Phone { get; set; }

    [Display(Name = "Data Nascimento")]
    public DateTime Birth { get; set; }

    [Display(Name = "Endereço")]
    public string Address { get; set; }

    [Display(Name = "Foto")]
    public string ImageUrl { get; set; }




}
