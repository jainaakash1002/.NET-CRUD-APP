using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Operations.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_Operations.Controllers
{
    public class CRUDOperationController : Controller
    {
        // GET: CRUDOperation
        public ActionResult Index()
        {
            ViewBag.searchresult = "";
            ViewBag.updateresult = "";
            StudentData sd = new StudentData();
            sd.rollno = "";
            sd.sname = "";
            ViewBag.cancelbutton = "disabled";
            ViewBag.updatebutton = "disabled";
            ViewBag.deletebutton = "disabled";
            ViewBag.savebutton = "disabled";
            ViewBag.searchbutton = "";
            ViewBag.addnewbutton = "";
            return View(sd);
        }
        [HttpPost]
        public ActionResult Index(string rollno, string cbutton, string sname, string mname, string fname)
        {
            StudentData sd = new StudentData();
            if (cbutton == "Search")
            {

                String mycon = "Data Source=LAPTOP-NVFAIS7U; Initial Catalog=crud; Integrated Security=True";
                String myquery = "Select * from stud where rollno=" + Convert.ToInt32(rollno);
                SqlConnection con = new SqlConnection(mycon);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = myquery;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewBag.searchresult = "Roll Number Has Been Found";
                    sd.rollno = rollno;
                    sd.sname = ds.Tables[0].Rows[0]["sname"].ToString();
                    ViewBag.cancelbutton = "";
                    ViewBag.updatebutton = "";
                    ViewBag.deletebutton = "";
                    ViewBag.savebutton = "disabled";
                    ViewBag.addnewbutton = "disabled";

                }
                else
                {
                    ViewBag.searchresult = "Roll Number Has Not Found";
                    ViewBag.cancelbutton = "disabled";
                    ViewBag.updatebutton = "disabled";
                    ViewBag.deletebutton = "disabled";
                    ViewBag.savebutton = "disabled";
                    ViewBag.addnewbutton = "";
                }
                con.Close();


            }
            else if (cbutton == "Update")
            {
                String mycon = "Data Source=LAPTOP-NVFAIS7U; Initial Catalog=crud; Integrated Security=True";
                String updatedata = "Update stud set sname='" + sname + "' where rollno=" + Convert.ToInt32(rollno);
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updatedata;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                sd.rollno = "";
                sd.sname = "";
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.addnewbutton = "";
            }
            else if (cbutton == "Cancel")
            {
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.searchbutton = "";
                ViewBag.addnewbutton = "";
            }
            else if (cbutton == "AddNew")
            {
                ViewBag.cancelbutton = "";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "";
                ViewBag.addnewbutton = "disabled";
                ViewBag.searchbutton = "disabled";
            }
            else if (cbutton == "Save")
            {
                String mycon = "Data Source=LAPTOP-NVFAIS7U; Initial Catalog=crud; Integrated Security=True";
                String query = "insert into stud(rollno,sname) values(" + rollno + ",'" + sname + "')";
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.searchbutton = "";
                ViewBag.addnewbutton = "";
            }
            else if (cbutton == "Delete")
            {
                String mycon = "Data Source=LAPTOP-NVFAIS7U; Initial Catalog=crud; Integrated Security=True";
                String updatedata = "delete from stud where rollno=" + rollno;
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updatedata;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.searchbutton = "";
                ViewBag.addnewbutton = "";
            }
            return View(sd);
        }
    }
}