using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Web.Models;
using SD_IKYS.Web.Services;

namespace SD_IKYS.Web.Controllers
{
    public class TrainingsController : Controller
    {
        private readonly IApiService _apiService;

        public TrainingsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
            try
            {
                var trainings = await _apiService.GetAsync<List<TrainingViewModel>>("trainings");
                return View(trainings);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitimler yüklenirken hata oluştu: " + ex.Message;
                return View(new List<TrainingViewModel>());
            }
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var training = await _apiService.GetAsync<TrainingViewModel>($"trainings/{id}");
                if (training == null)
                {
                    return NotFound();
                }
                return View(training);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitim detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Trainings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Trainer,StartDate,EndDate,Location,MaxParticipants,Cost")] TrainingCreateViewModel training)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.PostAsync<TrainingViewModel>("trainings", training);
                    TempData["Success"] = "Eğitim başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Eğitim oluşturulurken hata oluştu: " + ex.Message;
                }
            }
            return View(training);
        }

        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var training = await _apiService.GetAsync<TrainingViewModel>($"trainings/{id}");
                if (training == null)
                {
                    return NotFound();
                }

                var editViewModel = new TrainingEditViewModel
                {
                    Id = training.Id,
                    Title = training.Title,
                    Description = training.Description,
                    Trainer = training.Trainer,
                    StartDate = training.StartDate,
                    EndDate = training.EndDate,
                    Location = training.Location,
                    MaxParticipants = training.MaxParticipants,
                    Cost = training.Cost,
                    Status = training.Status,
                    IsActive = training.IsActive
                };

                return View(editViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitim bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Trainings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Trainer,StartDate,EndDate,Location,MaxParticipants,Cost,Status,IsActive")] TrainingEditViewModel training)
        {
            if (id != training.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.PutAsync<TrainingViewModel>($"trainings/{id}", training);
                    TempData["Success"] = "Eğitim başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Eğitim güncellenirken hata oluştu: " + ex.Message;
                }
            }
            return View(training);
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var training = await _apiService.GetAsync<TrainingViewModel>($"trainings/{id}");
                if (training == null)
                {
                    return NotFound();
                }
                return View(training);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitim bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _apiService.DeleteAsync($"trainings/{id}");
                if (result)
                {
                    TempData["Success"] = "Eğitim başarıyla silindi.";
                }
                else
                {
                    TempData["Error"] = "Eğitim silinirken hata oluştu.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitim silinirken hata oluştu: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Trainings/Active
        public async Task<IActionResult> Active()
        {
            try
            {
                var trainings = await _apiService.GetAsync<List<TrainingViewModel>>("trainings/active");
                return View(trainings);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Aktif eğitimler yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Trainings/Upcoming
        public async Task<IActionResult> Upcoming()
        {
            try
            {
                var trainings = await _apiService.GetAsync<List<TrainingViewModel>>("trainings/upcoming");
                return View(trainings);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Yaklaşan eğitimler yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Trainings/Completed
        public async Task<IActionResult> Completed()
        {
            try
            {
                var trainings = await _apiService.GetAsync<List<TrainingViewModel>>("trainings/completed");
                return View(trainings);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Tamamlanan eğitimler yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Trainings/ByTrainer/trainer
        public async Task<IActionResult> ByTrainer(string trainer)
        {
            try
            {
                var trainings = await _apiService.GetAsync<List<TrainingViewModel>>($"trainings/trainer/{trainer}");
                ViewBag.Trainer = trainer;
                return View(trainings);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitmen eğitimleri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 