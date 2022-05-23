using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class message
{
    [Key]
    public int id { get; set; }
    public string content { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime created { get; set; }

    [Required]
    public bool sent { get; set; }


}
