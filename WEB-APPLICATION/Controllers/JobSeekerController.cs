using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WEB_APPLICATION.Models;

namespace WEB_APPLICATION.Controllers
{
    public class JobSeekerController : Controller
    {
        public List<JobModel> JobList = new List<JobModel>();
        public IActionResult Index()
        {

            string connectionString = "Data Source=DESKTOP-A1NJHOG;Initial Catalog=Job;Integrated Security=True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query1 = "SELECT * FROM Jobs";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            JobModel model = new JobModel();
                            model.JobId = reader.GetInt32(0);
                            model.JobName = reader.GetString(1);
                            model.Category = reader.GetString(2);
                            model.SubCategory = reader.GetString(3);
                            model.VacancyCount = reader.GetInt32(4);
                            model.Salary = reader.GetInt32(5);
                            JobList.Add(model);
                        }
                    }
                }
            }
            ViewBag.JobList = JobList;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name)
        {
            int salary;
            bool isInt = int.TryParse(name, out salary);

            string connectionString = "Data Source=DESKTOP-A1NJHOG;Initial Catalog=Job;Integrated Security=True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query1 = isInt ? $"SELECT * FROM Jobs WHERE Salary >= {salary};" : $"SELECT * FROM Jobs WHERE JobName LIKE '%{name}%';";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            JobModel model = new JobModel();
                            model.JobId = reader.GetInt32(0);
                            model.JobName = reader.GetString(1);
                            model.Category = reader.GetString(2);
                            model.SubCategory = reader.GetString(3);
                            model.VacancyCount = reader.GetInt32(4);
                            model.Salary = reader.GetInt32(5);
                            JobList.Add(model);
                        }
                    }
                }
            }
            ViewBag.JobList = JobList;
            return View();
        }
    }
}
