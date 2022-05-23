using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Ratings
{
    public int Id { get; set; }
    public int CurrAvgRating { get; set; }

    [Range(0, 5)]
    [Required(ErrorMessage = "This Field Is Required")]
    public int Rating { get; set; }

    [MaxLength(100, ErrorMessage = "Please Write A Shorter Comment")]
    public string Comment { get; set; }

    [Required(ErrorMessage = "This Field Is Required")]
    public string Username { get; set; }

    public string Date { get; set; } = DateTime.Now.Date.ToString("dd/MM/yyyy");

    public string Time { get; set; } = DateTime.Now.ToString("h:mm tt");
}
