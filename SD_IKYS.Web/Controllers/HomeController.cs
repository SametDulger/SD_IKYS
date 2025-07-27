using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Web.Models;
using SD_IKYS.Web.Services;

namespace SD_IKYS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;

        public HomeController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            // Authentication kontrolü
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Users");
            }

            try
            {
                // Dashboard için istatistikleri API'den al
                var dashboardData = new
                {
                    TotalEmployees = 0,
                    ActiveEmployees = 0,
                    PendingLeaveRequests = 0,
                    ActiveTrainings = 0,
                    RecentEvaluations = 0
                };

                // API'den veri alınmaya çalışılır, hata durumunda varsayılan değerler kullanılır
                try
                {
                    // Tüm istatistikleri paralel olarak al
                    var tasks = new[]
                    {
                        _apiService.GetAsync<List<object>>("employees"),
                        _apiService.GetAsync<List<object>>("leaverequests"),
                        _apiService.GetAsync<List<object>>("trainings"),
                        _apiService.GetAsync<List<object>>("performanceevaluations")
                    };

                    await Task.WhenAll(tasks);

                    var employees = tasks[0].Result as List<object>;
                    var leaveRequests = tasks[1].Result as List<object>;
                    var trainings = tasks[2].Result as List<object>;
                    var evaluations = tasks[3].Result as List<object>;

                    // Bekleyen izinleri filtrele (Status = "Pending")
                    var pendingLeaveRequests = 0;
                    if (leaveRequests != null)
                    {
                        // JSON verilerini kontrol et
                        foreach (var request in leaveRequests)
                        {
                            var requestDict = request as System.Text.Json.JsonElement?;
                            if (requestDict.HasValue)
                            {
                                var status = requestDict.Value.GetProperty("status").GetString();
                                if (status?.ToLower() == "pending")
                                {
                                    pendingLeaveRequests++;
                                }
                            }
                        }
                    }

                    // Aktif eğitimleri filtrele (Status = "Active" veya "In Progress")
                    var activeTrainings = 0;
                    if (trainings != null)
                    {
                        foreach (var training in trainings)
                        {
                            var trainingDict = training as System.Text.Json.JsonElement?;
                            if (trainingDict.HasValue)
                            {
                                var status = trainingDict.Value.GetProperty("status").GetString();
                                if (status?.ToLower() == "active" || status?.ToLower() == "in progress")
                                {
                                    activeTrainings++;
                                }
                            }
                        }
                    }

                    // Son değerlendirmeleri say (son 30 gün)
                    var recentEvaluations = 0;
                    if (evaluations != null)
                    {
                        var thirtyDaysAgo = DateTime.Now.AddDays(-30);
                        foreach (var evaluation in evaluations)
                        {
                            var evaluationDict = evaluation as System.Text.Json.JsonElement?;
                            if (evaluationDict.HasValue)
                            {
                                var createdDate = evaluationDict.Value.GetProperty("createdDate").GetDateTime();
                                if (createdDate >= thirtyDaysAgo)
                                {
                                    recentEvaluations++;
                                }
                            }
                        }
                    }

                    // Aktif çalışanları say (IsActive = true)
                    var activeEmployees = 0;
                    if (employees != null)
                    {
                        foreach (var employee in employees)
                        {
                            var employeeDict = employee as System.Text.Json.JsonElement?;
                            if (employeeDict.HasValue)
                            {
                                var isActive = employeeDict.Value.GetProperty("isActive").GetBoolean();
                                if (isActive)
                                {
                                    activeEmployees++;
                                }
                            }
                        }
                    }

                    dashboardData = new
                    {
                        TotalEmployees = employees?.Count ?? 0,
                        ActiveEmployees = activeEmployees,
                        PendingLeaveRequests = pendingLeaveRequests,
                        ActiveTrainings = activeTrainings,
                        RecentEvaluations = recentEvaluations
                    };
                }
                catch
                {
                    // API erişilemezse varsayılan değerler kullanılır
                }

                ViewBag.DashboardData = dashboardData;
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Dashboard yüklenirken hata oluştu: " + ex.Message;
                return View();
            }
        }

        public IActionResult Privacy()
        {
            // Authentication kontrolü
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Users");
            }
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}
