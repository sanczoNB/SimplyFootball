using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimlyFooball.Models
{



  public class TeamValidator
  {
    [ScaffoldColumn(false)]
    public long Id { get; set; }

     [Display(Name = "Pełna nazwa")]
    public string FullName { get; set; }

    [Display(Name = "Nazwa potoczna")]
    public string NickName { get; set; }

    [Display(Name = "Kraj")]
    public string Country { get; set; }

    [Display(Name = "Miasto")]
    public string City { get; set; }

    [Display(Name = "Rok założenia")]
    public int FoundYear { get; set; }
  }

  [MetadataType(typeof(TeamValidator))]
  public partial class Team
  {
     
  }

}