using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class EntryController : Controller
    {
        public IConfiguration Configuration { get; }
        public EntryController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserDetail userDetail)
        {


            string connectionString = Configuration["ConnectionStrings:paycon"];
            using (var con = new SqlConnection(connectionString))
            {

                //     string sql = $"Insert Into NewTable (acc_no, pwd) Values ('{inventory.AccNo}', '{inventory.Pwd}')";

                using (var cmd = new SqlCommand("select dbo.userlogincheck(@username,@pwd)", con))
                {
                    cmd.Parameters.AddWithValue("@username", userDetail.Username);
                    cmd.Parameters.AddWithValue("@pwd", userDetail.Pwd);


                    con.Open();
                    int c = Convert.ToInt32(cmd.ExecuteScalar());

                    if (c == 1)
                    {

                        Console.WriteLine("welcome User");
                        return RedirectToAction("Index", "PayRoll");


                    }
                    else
                    {
                        Console.WriteLine("Account No or Password is wrong!!!");

                        return RedirectToAction("Index");
                    }
                }

            }
            return View(userDetail);
        }


   
        

        [HttpGet]
        public ActionResult signup()
        {

            return View();


        }

        [HttpPost]  
        public ActionResult signup(UserDetail l)
        {

            string connectionString = Configuration["ConnectionStrings:paycon"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = $"insert into login_checking values('{l.Username}','{l.Pwd}')";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            ViewBag.result = "success";
            return RedirectToAction(nameof(Index));


        }
    }

}
