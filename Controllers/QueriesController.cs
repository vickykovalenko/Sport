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
using System.Data;



namespace Sport.Controllers
{
    public class QueriesController : Controller
    {

        private const string connections = "Server=SCYRITYS\\server;Database=DBSportGym;Trusted_Connection=True;MultipleActiveResultSets=true";

        private const string sq1 = @"C:\Users\Bakup\Documents\SQL Server Management Studio\Simple_query_1.sql";
        private const string sq2 = @"C:\Users\Bakup\Documents\SQL Server Management Studio\Simple_query_2.sql";
        private const string sq3 = @"C:\Users\Bakup\Documents\SQL Server Management Studio\Simple_query_3.sql";
        private const string sq4 = @"C:\Users\Bakup\Documents\SQL Server Management Studio\Simple_query_4.sql";
        private const string sq5 = @"C:\Users\Bakup\Documents\SQL Server Management Studio\Simple_query_5.sql";

        private const string mq1 = @"C:\Users\Bakup\Documents\SQL Server Management Studio\Multiple_query_1.sql";
        private const string mq2 = @"C:\Users\Bakup\Documents\SQL Server Management Studio\Multiple_query_2.sql";
        private const string mq3 = @"C:\Users\Bakup\Documents\SQL Server Management Studio\Multiple_query_3.sql";
        private const string mq4 = @"C:\Users\Bakup\Documents\SQL Server Management Studio\SQLQuery1.sql";

        private const string tq1 = @"C:\Users\Bakup\Documents\SQL Server Management Studio\TempQuery_1.sql";
        private const string tq2 = @"C:\Users\Bakup\Documents\SQL Server Management Studio\TempQuery_2.sql";


        private const string error_client = "Немає відвідувачів з такою умовою.";

        private readonly DBSportGymContext _context;
        public QueriesController(DBSportGymContext context)
        {
            _context = context;
        }

        public IActionResult Index(int errorCode)
        {
            var clients = _context.Clients.Select(c => c.Name).Distinct().ToList();
            var empty = new SelectList(new List<string> { "--Пусто--" });
            var anyTrainers = _context.Trainers.Any();
            var anyClients = _context.Clients.Any();
            var anyGyms = _context.Gyms.Any();
            var anyPayments = _context.Payments.Any();

            ViewBag.TrainerNames = anyTrainers ? new SelectList(_context.Trainers, "Name", "Name") : empty;
            ViewBag.ClientNames = anyClients ? new SelectList(clients) : empty;
            ViewBag.ClientsSurnames = anyClients ? new SelectList(_context.Clients, "Surname", "Surname") : empty;
            ViewBag.GymNames = anyGyms ? new SelectList(_context.Gyms, "Name", "Name") : empty;
            ViewBag.TrainerSalaries = anyTrainers ? new SelectList(_context.Trainers, "Salary", "Salary") : empty;
            ViewBag.PaymentMonths = anyPayments ? new SelectList(_context.Payments, "Month", "Month") : empty;
            ViewBag.ClientEmails = anyClients ? new SelectList(_context.Clients, "Email", "Email") : empty;
            ViewBag.ClientIds = anyClients ? new SelectList(_context.Clients, "Id", "Id") : empty;


            return View();
            //ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Name", client.TrainerId);
            //return View(client);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SimpleQ1(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(sq1);
            query = query.Replace("K", "\'" + queryModel.TrainerName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "S1";
            queryModel.ClientNames = new List<string>();
            queryModel.ClientSurnames = new List<string>();

            using (var connection = new SqlConnection(connections))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.ClientNames.Add(reader.GetString(0));
                            queryModel.ClientSurnames.Add(reader.GetString(1));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = error_client;
                        }
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SimpleQ2(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(sq2);
            query = query.Replace("X", "\'" + queryModel.GymName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "S2";
            queryModel.ClientNames = new List<string>();
            queryModel.ClientSurnames = new List<string>();

            using (var connection = new SqlConnection(connections))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.ClientNames.Add(reader.GetString(0));
                            queryModel.ClientSurnames.Add(reader.GetString(1));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = error_client;
                        }
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SimpleQ3(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(sq3);
            query = query.Replace("X",  queryModel.TrainerSalary.ToString());
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "S3";
            queryModel.ClientNames = new List<string>();
            queryModel.ClientSurnames = new List<string>();

            using (var connection = new SqlConnection(connections))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.ClientNames.Add(reader.GetString(0));
                            queryModel.ClientSurnames.Add(reader.GetString(1));
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = error_client;
                        }
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SimpleQ4(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(sq4);
            query = query.Replace("X", "\'" + queryModel.PaymentMonth + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "S4";
            queryModel.TrainerNames = new List<string>();

           
            using (var connection = new SqlConnection(connections))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.TrainerNames.Add(reader.GetString(0));
                         
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = error_client;
                        }
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SimpleQ5(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(sq5);
            query = query.Replace("X", queryModel.CountClients.ToString());
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "S5";
            queryModel.TrainerNames = new List<string>();

            using (var connection = new SqlConnection(connections))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.TrainerNames.Add(reader.GetString(0));

                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = error_client;
                        }
                    }
                }
                connection.Close();
            }

            return RedirectToAction("Result", queryModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MultipleQ1(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(mq1);
            query = query.Replace("Y", "\'" + queryModel.TrainerName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "M1";
            queryModel.TrainerNames = new List<string>();

            using (var connection = new SqlConnection(connections))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            queryModel.TrainerNames.Add(reader.GetString(0));

                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = error_client;
                        }
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MultipleQ2(Query queryModel)
        { 
            string query = System.IO.File.ReadAllText(mq2);
            query = query.Replace("B", "\'" + queryModel.TrainerName + "\'");
            query = query.Replace("Z", "\'" + queryModel.GymName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            queryModel.QueryId = "M2";
            queryModel.ClientEmails = new List<string>();


            using (var connection = new SqlConnection(connections))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {

                            queryModel.ClientEmails.Add(reader.GetString(0));
                     
                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = error_client;
                        }
                    }
                }

                connection.Close();
            }

            return RedirectToAction("Result", queryModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MultipleQ3(Query queryModel)
        {
            string query = System.IO.File.ReadAllText(mq3);

            queryModel.QueryId = "M3";

            queryModel.ClientNames = new List<string>();
            using (var connection = new SqlConnection(connections))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {

                            queryModel.ClientNames.Add(reader.GetString(0));

                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = error_client;
                        }
                    }
                }
                connection.Close();
            }

            return RedirectToAction("Result", queryModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TestQ1(Query queryModel)
        {
            queryModel.GymNames = new List<string>();

            string query = System.IO.File.ReadAllText(tq1);

            queryModel.QueryId = "T1";
            queryModel.ClientNames = new List<string>();
            using (var connection = new SqlConnection(connections))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {

                            queryModel.GymNames.Add(reader.GetString(0));

                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = error_client;
                        }
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TestQ2(Query queryModel)
        {
            queryModel.ClientNames = new List<string>();

            string query = System.IO.File.ReadAllText(tq2);
            query = query.Replace("X", queryModel.ClientId.ToString());
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');
            queryModel.QueryId = "T2";

            using (var connection = new SqlConnection(connections))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {

                            queryModel.ClientNames.Add(reader.GetString(0));

                            flag++;
                        }
                        if (flag == 0)
                        {
                            queryModel.ErrorFlag = 1;
                            queryModel.Error = error_client;
                        }
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", queryModel);


        }

        public IActionResult Result(Query queryResult)
        {
            return View(queryResult);
        }
    }
}
