using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models;

public class Engineer
{
  public int EngineerId { get; set; }
  [Required(ErrorMessage = "Please enter a name for this employee.")]
  public string EngineerName { get; set; }
  public List<EngineerMachine> JoinEntities { get; set; }
}