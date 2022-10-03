using RegistrationPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;

namespace RegistrationPortal.Controllers
{
    public class EmployeeDetailsController : Controller
    {

        // GET: EmployeeDetails
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            RegistrationPortalEntities db = new RegistrationPortalEntities();

            List<tblCompanyName> objCompanyList = db.tblCompanyNames.ToList();
            List<tblBankName> objBankList = db.tblBankNames.ToList();

            ViewBag.CompanyList = new SelectList(objCompanyList, "Company", "Company");
            ViewBag.BankList = new SelectList(objBankList, "Bank", "Bank");

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeDetailsForm form)
        {
            RegistrationPortalEntities db = new RegistrationPortalEntities();

            List<tblCompanyName> objCompanyList = db.tblCompanyNames.ToList();
            List<tblBankName> objBankList = db.tblBankNames.ToList();

            ViewBag.CompanyList = new SelectList(objCompanyList, "Company", "Company");
            ViewBag.BankList = new SelectList(objBankList, "Bank", "Bank");

            if (ModelState.IsValid)
            {
                //RegistrationPortalEntities db = new RegistrationPortalEntities();

                tblEmployeeDetail employeeDetails = new tblEmployeeDetail();

                if (form.UserPhotoFile.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(form.UserPhotoFile.FileName);
                    string _Extension = Path.GetExtension(form.UserPhotoFile.FileName);
                    if (_Extension == ".png" || _Extension == ".jpg")
                    {
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                        form.UserPhotoFile.SaveAs(_path);
                        employeeDetails.UserPhotoPath = _path;
                        ViewBag.Message = _Extension;
                    }
                    ViewBag.Message = "Invalid format";
                }

                foreach (HttpPostedFileBase doc in form.DocumentUploadFile)
                {
                    string _Extension = Path.GetExtension(doc.FileName);
                    if (_Extension == ".pdf" || _Extension == ".ppt")
                    {
                        //Checking file is available to save.  
                        if (doc != null)
                        {
                            var InputFileName = Path.GetFileName(doc.FileName);
                            var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + InputFileName);
                            //Save file to server folder  
                            doc.SaveAs(ServerSavePath);
                            employeeDetails.DocumentUploadPath = ServerSavePath;
                            //file.DocumentPath = ServerSavePath;
                            //assigning file uploaded status to ViewBag for showing message to user.  
                            //ViewBag.UploadStatus = form.DocumentUploadFile.Count().ToString() + " files uploaded successfully.";
                        }

                    }
                }

                employeeDetails.FirstName = form.FirstName;
                employeeDetails.MiddleName = form.MiddleName;
                employeeDetails.LastName = form.LastName;
                employeeDetails.CompanyName = form.Company.ToString();
                employeeDetails.Age = form.Age.ToString();
                employeeDetails.Salary = form.Salary.ToString();
                employeeDetails.DateOfJoining = form.DateOfJoining.ToString();
                employeeDetails.MobileNumber = form.MobileNumber.ToString();
                employeeDetails.Email = form.Email;
                employeeDetails.BankName = form.Bank.ToString();
                employeeDetails.IFSCCode = form.IFSCCode;
                employeeDetails.AccountNumber = form.AccountNumber;
                employeeDetails.PFNumber = form.PFNumber;
                employeeDetails.UANNumber = form.UANNumber;

                db.tblEmployeeDetails.Add(employeeDetails);
                db.SaveChanges();

                return View();
            }
            return View();
        }

        public ActionResult Retrive()
        {
            RegistrationPortalEntities db = new RegistrationPortalEntities();

            var table = db.tblEmployeeDetails.ToList();

            return View(table);
        }

        public ActionResult GetList()
        {
            RegistrationPortalEntities db = new RegistrationPortalEntities();
            var table = db.tblEmployeeDetails.ToList<tblEmployeeDetail>();
            return Json( table, JsonRequestBehavior.AllowGet);
        }

        //private void PopulateList(EmployeeDetailsForm model)
        //{
        //    if (MemoryCache.Default.Contains("SubjectList"))
        //    {
        //        // The SubjectList already exists in the cache,
        //        model.Company = (List<Subject>)MemoryCache.Default.Get("SubjectList");
        //    }
        //    else
        //    {
        //        // The select list does not yet exists in the cache, fetch items from the data store.
        //        List<Subject> selectList = _db.Subjects.ToList();

        //        // Cache the list in memory for 15 minutes.
        //        MemoryCache.Default.Add("SubjectList", selectList, DateTime.Now.AddMinutes(15));
        //        model.Subjects = selectList;
        //    }
        //}
    }
}