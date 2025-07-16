using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Web.Models;
using SD_IKYS.Web.Services;

namespace SD_IKYS.Web.Controllers
{
    public class PerformanceEvaluationsController : Controller
    {
        private readonly IApiService _apiService;

        public PerformanceEvaluationsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: PerformanceEvaluations
        public async Task<IActionResult> Index()
        {
            try
            {
                var evaluations = await _apiService.GetAsync<List<PerformanceEvaluationViewModel>>("performanceevaluations");
                return View(evaluations);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Performans değerlendirmeleri yüklenirken hata oluştu: " + ex.Message;
                return View(new List<PerformanceEvaluationViewModel>());
            }
        }

        // GET: PerformanceEvaluations/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var evaluation = await _apiService.GetAsync<PerformanceEvaluationViewModel>($"performanceevaluations/{id}");
                if (evaluation == null)
                {
                    return NotFound();
                }
                return View(evaluation);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Performans değerlendirmesi detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: PerformanceEvaluations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PerformanceEvaluations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EvaluatorId,EvaluationDate,WorkQuality,WorkQuantity,Teamwork,Communication,Initiative,ProblemSolving,Attendance,Punctuality,Strengths,AreasForImprovement,Comments")] PerformanceEvaluationCreateViewModel evaluation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.PostAsync<PerformanceEvaluationViewModel>("performanceevaluations", evaluation);
                    TempData["Success"] = "Performans değerlendirmesi başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Performans değerlendirmesi oluşturulurken hata oluştu: " + ex.Message;
                }
            }
            return View(evaluation);
        }

        // GET: PerformanceEvaluations/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var evaluation = await _apiService.GetAsync<PerformanceEvaluationViewModel>($"performanceevaluations/{id}");
                if (evaluation == null)
                {
                    return NotFound();
                }

                var editViewModel = new PerformanceEvaluationEditViewModel
                {
                    Id = evaluation.Id,
                    EmployeeId = evaluation.EmployeeId,
                    EvaluatorId = evaluation.EvaluatorId,
                    EvaluationDate = evaluation.EvaluationDate,
                    WorkQuality = evaluation.WorkQuality,
                    WorkQuantity = evaluation.WorkQuantity,
                    Teamwork = evaluation.Teamwork,
                    Communication = evaluation.Communication,
                    Initiative = evaluation.Initiative,
                    ProblemSolving = evaluation.ProblemSolving,
                    Attendance = evaluation.Attendance,
                    Punctuality = evaluation.Punctuality,
                    Strengths = evaluation.Strengths,
                    AreasForImprovement = evaluation.AreasForImprovement,
                    Comments = evaluation.Comments,
                    Status = evaluation.Status
                };

                return View(editViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Performans değerlendirmesi bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: PerformanceEvaluations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,EvaluatorId,EvaluationDate,WorkQuality,WorkQuantity,Teamwork,Communication,Initiative,ProblemSolving,Attendance,Punctuality,Strengths,AreasForImprovement,Comments,Status")] PerformanceEvaluationEditViewModel evaluation)
        {
            if (id != evaluation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.PutAsync<PerformanceEvaluationViewModel>($"performanceevaluations/{id}", evaluation);
                    TempData["Success"] = "Performans değerlendirmesi başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Performans değerlendirmesi güncellenirken hata oluştu: " + ex.Message;
                }
            }
            return View(evaluation);
        }

        // GET: PerformanceEvaluations/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evaluation = await _apiService.GetAsync<PerformanceEvaluationViewModel>($"performanceevaluations/{id}");
                if (evaluation == null)
                {
                    return NotFound();
                }
                return View(evaluation);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Performans değerlendirmesi bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: PerformanceEvaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _apiService.DeleteAsync($"performanceevaluations/{id}");
                if (result)
                {
                    TempData["Success"] = "Performans değerlendirmesi başarıyla silindi.";
                }
                else
                {
                    TempData["Error"] = "Performans değerlendirmesi silinirken hata oluştu.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Performans değerlendirmesi silinirken hata oluştu: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PerformanceEvaluations/ByEmployee/5
        public async Task<IActionResult> ByEmployee(int employeeId)
        {
            try
            {
                var evaluations = await _apiService.GetAsync<List<PerformanceEvaluationViewModel>>($"performanceevaluations/employee/{employeeId}");
                ViewBag.EmployeeId = employeeId;
                return View(evaluations);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Personel performans değerlendirmeleri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: PerformanceEvaluations/ByEvaluator/5
        public async Task<IActionResult> ByEvaluator(int evaluatorId)
        {
            try
            {
                var evaluations = await _apiService.GetAsync<List<PerformanceEvaluationViewModel>>($"performanceevaluations/evaluator/{evaluatorId}");
                ViewBag.EvaluatorId = evaluatorId;
                return View(evaluations);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Değerlendirici performans değerlendirmeleri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: PerformanceEvaluations/HighPerformers
        public async Task<IActionResult> HighPerformers()
        {
            try
            {
                var evaluations = await _apiService.GetAsync<List<PerformanceEvaluationViewModel>>("performanceevaluations/high-performers");
                return View(evaluations);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Yüksek performanslı personel listesi yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: PerformanceEvaluations/Report
        public async Task<IActionResult> Report()
        {
            try
            {
                var report = await _apiService.GetAsync<object>("performanceevaluations/report");
                return View(report);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Performans raporu yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 