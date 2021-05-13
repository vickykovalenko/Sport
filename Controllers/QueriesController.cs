using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sport.Models;
using Sport;



namespace Sport.Controllers
{
    public class QueriesController : Controller
    {
  
        private const string connection = "Server=SCYRITYS\\server;Database=DBSportGym;Trusted_Connection=True;MultipleActiveResultSets=true";
        private readonly DBSportGymContext _context;

        public QueriesController(DBSportGymContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
