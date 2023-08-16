using DIMS.Entities;
using DIMS.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportRepository _IreportRepository;
        private readonly IEnterpriseRepository _IenterpriseRepository;
        public ReportController(IReportRepository IreportRepository, IEnterpriseRepository IenterpriseRepository)
        {
            _IreportRepository = IreportRepository;
            _IenterpriseRepository = IenterpriseRepository;
        }
        public async Task<IActionResult> Index(bool isSuccess = false, string DuplicateError = "")
        {
            int InterPriseLocation = int.Parse(User.FindFirst("UserLocationId").Value);
            int LocationId = await _IenterpriseRepository.GetUserLocationIdAsync(InterPriseLocation);
            if (DuplicateError != "")
            {
                ViewBag.DuplicateErrormsg = DuplicateError;
                ViewBag.DuplicateError = true;
            }
            else
            {
                ViewBag.DuplicateError = false;
            }
            ViewBag.isSuccess = isSuccess;
            ViewBag.GetAllReportList =   _IreportRepository.GetAllEnterpriseList().Where(x=>x.EnterUserLocationId== LocationId);

            return View();
        }
    }
}
