using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using WEB_APPLICATION.Models;

namespace WEB_APPLICATION.Controllers
{
    public class AdminPanelController : Controller
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
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(string name, string category, string subcat, int count,int salary)
        {
            string connectionString = "Data Source=DESKTOP-A1NJHOG;Initial Catalog=Job;Integrated Security=True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query1 = $"INSERT INTO Jobs VALUES ('{name}','{category}','{subcat}',{count},{salary})";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteJob(int id)
        {
            string connectionString = "Data Source=DESKTOP-A1NJHOG;Initial Catalog=Job;Integrated Security=True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query1 = $"DELETE FROM Jobs WHERE JobId={id}";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateJob(int id)
        {
            //List <JobModel> jobs = new List <JobModel> ();
            JobModel model = new JobModel();
            string connectionString = "Data Source=DESKTOP-A1NJHOG;Initial Catalog=Job;Integrated Security=True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query1 = $"SELECT * FROM Jobs WHERE JobId={id}";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            model.JobId = reader.GetInt32(0);
                            model.JobName = reader.GetString(1);
                            model.Category = reader.GetString(2);
                            model.SubCategory = reader.GetString(3);
                            model.VacancyCount = reader.GetInt32(4);
                            model.Salary = reader.GetInt32(5);

                            //jobs.Add(model);
                        }
                    }
                }
            }
            ViewBag.jobs = model;
            return View();
        }

        [HttpPost]
        public IActionResult UpdateJob(string name, string category, string subcat, int count,int id,int salary)
        {
            string connectionString = "Data Source=DESKTOP-A1NJHOG;Initial Catalog=Job;Integrated Security=True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query1 = $"UPDATE Jobs SET JobName='{name}',Category='{category}',SubCategory='{subcat}',VacancyCount={count},Salary={salary} WHERE JobId={id}";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index");
        }
    }
}