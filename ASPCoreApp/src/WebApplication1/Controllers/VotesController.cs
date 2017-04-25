using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataModel;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VotesController : Controller
    {
        private readonly MyDbContext db;

        public VotesController(MyDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            using (db)
            {
                return View(db.Candidates.ToList());
            }
        }

        public IActionResult Info()
        {
            return View();  
        }
        
        [HttpPost]
        public IActionResult Info(CandidateInfoModel model)
        {
            /*
            using (db)
            {
                var candidateInfo =
                    db.Candidates.FromSql("SELECT * FROM dbo.Candidates WHERE id = " + model.CandidateId)
                        .ToList()
                        .SingleOrDefault()
                        .Info;

                return View(new CandidateInfoModel {CandidateInfo = candidateInfo});
            }
            //parametrizovana query na StackOverflow
             */

            string info = null;
            using (
                var sqlConnection1 =
                    new SqlConnection(
                        "Server=(localdb)\\mssqllocaldb;Database=KYPODB;Trusted_Connection=True;MultipleActiveResultSets=true")
            )
            {
                using (var cmd = new SqlCommand
                {
                    CommandText = "SELECT * FROM dbo.Candidates WHERE id = " + model.CandidateId,
                    CommandType = CommandType.Text,
                    Connection = sqlConnection1
                })
                { 
                    sqlConnection1.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info = reader[1].ToString();
                        }
                    }

                    sqlConnection1.Close();
                }
            }
            return View(new CandidateInfoModel { CandidateInfo = info });
        }
    }
}
