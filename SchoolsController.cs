using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SchoolApiLink.Models;
namespace SchoolApiLink.Controllers
{
    public class SchoolsController : Controller
    {
        // GET: Schools
        public ActionResult Index()
        {
            IEnumerable<SchoolData> Studdata = null;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44311/api/";

                var json = webClient.DownloadString("Students");
                var list = JsonConvert.DeserializeObject<List<SchoolData>>(json);
                Studdata = list.ToList();
                return View(Studdata);
            }
        }

        // GET: Schools/Details/5
        public ActionResult Details(int id)
        {
            SchoolData studdata;
            using (WebClient web = new WebClient())
            {
                web.BaseAddress = "https://localhost:44311/api/";
                var json = web.DownloadString("Students/"+id);
                studdata = JsonConvert.DeserializeObject<SchoolData>(json);
            }
            return View(studdata);

        }

        // GET: Schools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        [HttpPost]
        public ActionResult Create(SchoolData model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44311/api/";
                    var url = "Students/POST";
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);
                    var response = webClient.UploadString(url, data);
                    JsonConvert.DeserializeObject<SchoolData>(response);
                   
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(int id)
        {
            SchoolData Studdata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44311/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                Studdata = JsonConvert.DeserializeObject<SchoolData>(json);
            }
            return View(Studdata);
        }

        // POST: Schools/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SchoolData model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44311/api/Students/"+id;
                    //var url = "Customers/put"+id;

                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);

                   
                    var response = webClient.UploadString(webClient.BaseAddress, "PUT", data);

                    SchoolData modeldata = JsonConvert.DeserializeObject<SchoolData>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: Schools/Delete/5
        public ActionResult Delete(int id)
        {
            SchoolData Studdata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44311/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                Studdata = JsonConvert.DeserializeObject<SchoolData>(json);
            }
            return View(Studdata);
        }

        // POST: Schools/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SchoolData model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    NameValueCollection nv = new NameValueCollection();

                    string url = "https://localhost:44311/api/Students/"+id;

                    var response = Encoding.ASCII.GetString(webClient.UploadValues(url, "DELETE", nv));

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}
