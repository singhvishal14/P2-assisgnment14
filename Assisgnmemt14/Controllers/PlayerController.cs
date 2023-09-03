using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assisgnmemt14.Controllers
{
    public class PlayerController : Controller
    {
        static string connection = ConfigurationManager.ConnectionStrings["PlayersDetails"].ConnectionString;
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        // GET: Players
        public ActionResult Index()
        {
            List<Player> player = new List<Player>();
            try
            {
                con = new SqlConnection(connection);
                cmd = new SqlCommand("Select * From Player", con);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    player.Add(
                        new Player
                        {
                            Id = (int)(reader["Id"]),
                            FirstName = (string)(reader["FirstName"]),
                            LastName = (string)(reader["LastName"]),
                            JerseyNumber = (int)(reader["JerseyNumber"]),
                            Position = (string)(reader["Position"]),
                            Team = (string)(reader["Team"]),
                        });
                }
            }
            catch
            {
                return View("Error");
            }
            finally
            {
                con.Close();
            }
            return View(player);
        }

        // GET: Players/Details/5
        public ActionResult Details(int id)
        {
            Player player = new Player();
            try
            {
                con = new SqlConnection(connection);
                cmd = new SqlCommand("Select * From Player where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    player =
                        new Player
                        {
                            Id = (int)(reader["Id"]),
                            FirstName = (string)(reader["FirstName"]),
                            LastName = (string)(reader["LastName"]),
                            JerseyNumber = (int)(reader["JerseyNumber"]),
                            Position = (string)(reader["Position"]),
                            Team = (string)(reader["Team"]),
                        };
                }
                return View(player);
            }
            catch
            {
                return View("Error");
            }
            finally
            {
                con.Close();
            }
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        public ActionResult Create(Player player)
        {
            try
            {
                con = new SqlConnection(connection);
                cmd = new SqlCommand("Insert Into Player Values (@id,@fn,@ln,@jn,@pos,@tm)", con);
                cmd.Parameters.AddWithValue("@id", player.Id);
                cmd.Parameters.AddWithValue("@fn", player.FirstName);
                cmd.Parameters.AddWithValue("@ln", player.LastName);
                cmd.Parameters.AddWithValue("@jn", player.JerseyNumber);
                cmd.Parameters.AddWithValue("@pos", player.Position);
                cmd.Parameters.AddWithValue("@tm", player.Team);
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
            finally
            {
                con.Close();
            }
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int id)
        {
            Player player = new Player();
            try
            {
                con = new SqlConnection(connection);
                cmd = new SqlCommand("Select * From Player where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    player =
                        new Player
                        {
                            Id = (int)(reader["Id"]),
                            FirstName = (string)(reader["FirstName"]),
                            LastName = (string)(reader["LastName"]),
                            JerseyNumber = (int)(reader["JerseyNumber"]),
                            Position = (string)(reader["Position"]),
                            Team = (string)(reader["Team"]),
                        };
                }
                return View(player);
            }
            catch
            {
                return View("Error");
            }
            finally
            {
                con.Close();
            }
        }

        // POST: Players/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Player player)
        {
            try
            {
                con = new SqlConnection(connection);
                cmd = new SqlCommand("Update Player Set FirstName=@fn,LastName=@ln,JerseyNumber=@jn,Position=@pos,Team=@tm where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", player.Id);
                cmd.Parameters.AddWithValue("@fn", player.FirstName);
                cmd.Parameters.AddWithValue("@ln", player.LastName);
                cmd.Parameters.AddWithValue("@jn", player.JerseyNumber);
                cmd.Parameters.AddWithValue("@pos", player.Position);
                cmd.Parameters.AddWithValue("@tm", player.Team);
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
            finally
            {
                con.Close();
            }
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int id)
        {
            Player player = new Player();
            try
            {
                con = new SqlConnection(connection);
                cmd = new SqlCommand("Select * From Player where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    player =
                        new Player
                        {
                            Id = (int)(reader["Id"]),
                            FirstName = (string)(reader["FirstName"]),
                            LastName = (string)(reader["LastName"]),
                            JerseyNumber = (int)(reader["JerseyNumber"]),
                            Position = (string)(reader["Position"]),
                            Team = (string)(reader["Team"]),
                        };
                }
                return View(player);
            }
            catch
            {
                return View("Error");
            }
            finally
            {
                con.Close();
            }
        }

        // POST: Players/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Player player)
        {
            try
            {
                con = new SqlConnection(connection);
                cmd = new SqlCommand("Delete From Player where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", player.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
            finally
            {
                con.Close();
            }
        }
    }
}