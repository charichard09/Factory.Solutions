using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Factory.Controllers;

public class MachinesController : Controller
{
  private readonly FactoryContext _db;

  public MachinesController(FactoryContext db)
  {
    _db = db;
  }
  
  public ActionResult Index()
  {
    return View(_db.Machines.ToList());
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Machine machine)
  {
    _db.Machines.Add(machine);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Details(int id)
  {
    Machine thisMachine = _db.Machines
      .Include(machine => machine.JoinEntities)
      .ThenInclude(join => join.Engineer)
      .FirstOrDefault(machine => machine.MachineId == id);
    return View(thisMachine);
  }
}