using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class PayRollController : Controller
    {
        // GET: PayRollController
        public IConfiguration Configuration { get; }

        public PayRollController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public ActionResult Index()
        {
            List<PayRoll> li = new List<PayRoll>();
            string connectionString = Configuration["ConnectionStrings:paycon"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sql = "select * from PayRoll";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        PayRoll p = new PayRoll();
                        p.Id = Convert.ToInt32(sdr["id"]);
                        p.Empname = Convert.ToString(sdr["empname"]);
                        p.Deptname = Convert.ToString(sdr["deptname"]);
                        p.Email = Convert.ToString(sdr["Email"]);
                        p.Accno = Convert.ToInt32(sdr["Accno"]);
                        p.Leavedays = Convert.ToInt32(sdr["leavedays"]);
                        p.Detuction = Convert.ToInt32(sdr["Detuction"]);
                        p.Salary = Convert.ToInt32(sdr["salary"]);
                        li.Add(p);
                    }
                    con.Close();
                }
            }
            return View(li);
        }

        // GET: PayRollController/Details/5
        public ActionResult Details(int id)
        {
            PayRoll pay = new PayRoll();


            string connectionString = Configuration["ConnectionStrings:paycon"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string sqlQuery = $"select * from PayRoll where id = {id}";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {

                        while (sdr.Read())
                        {


                            pay.Id = Convert.ToInt32(sdr["id"]);
                            pay.Empname = Convert.ToString(sdr["empname"]);
                            pay.Deptname = Convert.ToString(sdr["deptname"]);
                            pay.Email = Convert.ToString(sdr["Email"]);
                            pay.Accno = Convert.ToInt32(sdr["Accno"]);
                            pay.Leavedays = Convert.ToInt32(sdr["leavedays"]);
                            pay.Detuction = Convert.ToInt32(sdr["Detuction"]);
                            pay.Salary = Convert.ToInt32(sdr["salary"]);



                        }

                        con.Close();

                    }

                }



            }
            return View(pay);
        }

        // GET: PayRollController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PayRollController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PayRoll p)
        {
            string connectionString = Configuration["ConnectionStrings:paycon"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int l = Convert.ToInt32(p.Leavedays);
                int det = l * 1000;
                int sal = 30000 - l * 1000;
                string sql = $"insert into PayRoll(empname,deptname,Email,Accno,leavedays,Detuction,salary)values('{p.Empname}','{p.Deptname}','{p.Email}','{p.Accno}','{p.Leavedays}','{det}','{sal}')";
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

        // GET: PayRollController/Edit/5
        public ActionResult Edit(int id)
        {
            PayRoll pay = new PayRoll();


            string connectionString = Configuration["ConnectionStrings:paycon"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();
                string sqlQuery = $"select * from PayRoll where id = {id}";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                {

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {

                        while (sdr.Read())
                        {


                            pay.Id = Convert.ToInt32(sdr["id"]);
                            pay.Empname = Convert.ToString(sdr["empname"]);
                            pay.Deptname = Convert.ToString(sdr["deptname"]);
                            pay.Email = Convert.ToString(sdr["Email"]);
                            pay.Accno = Convert.ToInt32(sdr["Accno"]);
                            pay.Leavedays = Convert.ToInt32(sdr["leavedays"]);



                        }

                        con.Close();

                    }

                }



            }
            return View(pay);
        }

        // POST: PayRollController/Edit/5
        [HttpPost]
        
        public ActionResult Edit(int id, PayRoll p)
        {
                int l = Convert.ToInt32(p.Leavedays);
                int det = l * 1000;
                int sal = 30000 - l * 1000;
                string connectionString = Configuration["ConnectionStrings:paycon"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Update PayRoll SET empname='{p.Empname}',deptname='{p.Deptname}',Email='{p.Email}',Accno='{p.Accno}',leavedays='{p.Leavedays}',Detuction='{det}',salary='{sal}' where id='{id}'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {


                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return RedirectToAction("Index");
            
          
        }

        // GET: PayRollController/Delete/5
        public ActionResult Delete(int id)
        {
            PayRoll pay = new PayRoll();


            string connectionString = Configuration["ConnectionStrings:paycon"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();
                string sqlQuery = $"select * from PayRoll where id = {id}";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {

                        while (sdr.Read())
                        {



                            pay.Empname = Convert.ToString(sdr["empname"]);
                            pay.Deptname = Convert.ToString(sdr["deptname"]);
                            pay.Email = Convert.ToString(sdr["Email"]);
                            pay.Accno = Convert.ToInt32(sdr["Accno"]);
                            pay.Leavedays = Convert.ToInt32(sdr["leavedays"]);
                            pay.Detuction = Convert.ToInt32(sdr["Detuction"]);
                            pay.Salary = Convert.ToInt32(sdr["salary"]);



                        }

                        con.Close();

                    }

                }



            }
            return View(pay);
        }

        // POST: PayRollController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,PayRoll p)
        {
            try
            {

                string connectionString = Configuration["ConnectionStrings:paycon"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Delete from PayRoll where Id='{id}'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {


                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
