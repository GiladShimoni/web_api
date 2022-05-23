using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Contact
{
    
    [Required]
    public string id { get; set; }

    [Required]
    public string name { get; set; }

    [Required]
    public string server { get; set; }

    public string? last { get; set; }

    [DataType(DataType.Date)]
    public DateTime? lastdate { get; set; }

    public List<message> messages { get; set; } 

}
