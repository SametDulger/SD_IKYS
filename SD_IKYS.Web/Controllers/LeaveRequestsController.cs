using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Web.Models;
using SD_IKYS.Web.Services;

namespace SD_IKYS.Web.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private readonly IApiService _apiService;

        public LeaveRequestsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: LeaveRequests
        public async Task<IActionResult> Index()
        {
            try
            {
                var leaveRequests = await _apiService.GetAsync<List<LeaveRequestViewModel>>("leaverequests");
                return View(leaveRequests);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İzin talepleri yüklenirken hata oluştu: " + ex.Message;
                return View(new List<LeaveRequestViewModel>());
            }
        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var leaveRequest = await _apiService.GetAsync<LeaveRequestViewModel>($"leaverequests/{id}");
                if (leaveRequest == null)
                {
                    return NotFound();
                }
                return View(leaveRequest);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İzin talebi detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveRequests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,StartDate,EndDate,LeaveType,Reason")] LeaveRequestCreateViewModel leaveRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.PostAsync<LeaveRequestViewModel>("leaverequests", leaveRequest);
                    TempData["Success"] = "İzin talebi başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "İzin talebi oluşturulurken hata oluştu: " + ex.Message;
                }
            }
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var leaveRequest = await _apiService.GetAsync<LeaveRequestViewModel>($"leaverequests/{id}");
                if (leaveRequest == null)
                {
                    return NotFound();
                }

                var editViewModel = new LeaveRequestEditViewModel
                {
                    Id = leaveRequest.Id,
                    EmployeeId = leaveRequest.EmployeeId,
                    StartDate = leaveRequest.StartDate,
                    EndDate = leaveRequest.EndDate,
                    LeaveType = leaveRequest.LeaveType,
                    Reason = leaveRequest.Reason,
                    Status = leaveRequest.Status,
                    Comments = leaveRequest.Comments
                };

                return View(editViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İzin talebi bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: LeaveRequests/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,StartDate,EndDate,LeaveType,Reason,Status,Comments")] LeaveRequestEditViewModel leaveRequest)
        {
            if (id != leaveRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.PutAsync<LeaveRequestViewModel>($"leaverequests/{id}", leaveRequest);
                    TempData["Success"] = "İzin talebi başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "İzin talebi güncellenirken hata oluştu: " + ex.Message;
                }
            }
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var leaveRequest = await _apiService.GetAsync<LeaveRequestViewModel>($"leaverequests/{id}");
                if (leaveRequest == null)
                {
                    return NotFound();
                }
                return View(leaveRequest);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İzin talebi bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _apiService.DeleteAsync($"leaverequests/{id}");
                if (result)
                {
                    TempData["Success"] = "İzin talebi başarıyla silindi.";
                }
                else
                {
                    TempData["Error"] = "İzin talebi silinirken hata oluştu.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İzin talebi silinirken hata oluştu: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LeaveRequests/Approve/5
        public async Task<IActionResult> Approve(int id)
        {
            try
            {
                var leaveRequest = await _apiService.GetAsync<LeaveRequestViewModel>($"leaverequests/{id}");
                if (leaveRequest == null)
                {
                    return NotFound();
                }

                var approvalViewModel = new LeaveRequestApprovalViewModel
                {
                    Id = leaveRequest.Id,
                    Status = "Approved"
                };

                return View(approvalViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İzin talebi bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: LeaveRequests/Approve/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id, [Bind("Id,Status,Comments")] LeaveRequestApprovalViewModel approval)
        {
            if (id != approval.Id)
            {
                return NotFound();
            }

            try
            {
                await _apiService.PutAsync<LeaveRequestViewModel>($"leaverequests/{id}/approve", approval);
                TempData["Success"] = "İzin talebi başarıyla onaylandı.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İzin talebi onaylanırken hata oluştu: " + ex.Message;
                return View(approval);
            }
        }

        // GET: LeaveRequests/Reject/5
        public async Task<IActionResult> Reject(int id)
        {
            try
            {
                var leaveRequest = await _apiService.GetAsync<LeaveRequestViewModel>($"leaverequests/{id}");
                if (leaveRequest == null)
                {
                    return NotFound();
                }

                var approvalViewModel = new LeaveRequestApprovalViewModel
                {
                    Id = leaveRequest.Id,
                    Status = "Rejected"
                };

                return View(approvalViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İzin talebi bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: LeaveRequests/Reject/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id, [Bind("Id,Status,Comments")] LeaveRequestApprovalViewModel approval)
        {
            if (id != approval.Id)
            {
                return NotFound();
            }

            try
            {
                await _apiService.PutAsync<LeaveRequestViewModel>($"leaverequests/{id}/reject", approval);
                TempData["Success"] = "İzin talebi başarıyla reddedildi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İzin talebi reddedilirken hata oluştu: " + ex.Message;
                return View(approval);
            }
        }

        // GET: LeaveRequests/Pending
        public async Task<IActionResult> Pending()
        {
            try
            {
                var leaveRequests = await _apiService.GetAsync<List<LeaveRequestViewModel>>("leaverequests/pending");
                return View(leaveRequests);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Bekleyen izin talepleri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: LeaveRequests/ByEmployee/5
        public async Task<IActionResult> ByEmployee(int employeeId)
        {
            try
            {
                var leaveRequests = await _apiService.GetAsync<List<LeaveRequestViewModel>>($"leaverequests/employee/{employeeId}");
                ViewBag.EmployeeId = employeeId;
                return View(leaveRequests);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Personel izin talepleri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 