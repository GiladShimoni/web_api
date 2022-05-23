using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain;

public class User
{




    [Key]
    [Required]
    public string id { get; set; }

    [Required]
    public string name { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string password { get; set; }

    [DataType(DataType.Url)]
    public string profiePic{ get; set; }

    [Required]
    public string server { get; set; }

    public List<Contact> Contacts { get; set; }
}
