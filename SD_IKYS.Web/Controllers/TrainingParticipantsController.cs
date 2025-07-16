using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Web.Models;
using SD_IKYS.Web.Services;

namespace SD_IKYS.Web.Controllers
{
    public class TrainingParticipantsController : Controller
    {
        private readonly IApiService _apiService;

        public TrainingParticipantsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: TrainingParticipants
        public async Task<IActionResult> Index()
        {
            try
            {
                var participants = await _apiService.GetAsync<List<TrainingParticipantViewModel>>("trainingparticipants");
                return View(participants);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitim katılımcıları yüklenirken hata oluştu: " + ex.Message;
                return View(new List<TrainingParticipantViewModel>());
            }
        }

        // GET: TrainingParticipants/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var participant = await _apiService.GetAsync<TrainingParticipantViewModel>($"trainingparticipants/{id}");
                if (participant == null)
                {
                    return NotFound();
                }
                return View(participant);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitim katılımcısı detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: TrainingParticipants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingParticipants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingId,EmployeeId,Comments")] TrainingParticipantCreateViewModel participant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.PostAsync<TrainingParticipantViewModel>("trainingparticipants", participant);
                    TempData["Success"] = "Eğitim katılımcısı başarıyla eklendi.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Eğitim katılımcısı eklenirken hata oluştu: " + ex.Message;
                }
            }
            return View(participant);
        }

        // GET: TrainingParticipants/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var participant = await _apiService.GetAsync<TrainingParticipantViewModel>($"trainingparticipants/{id}");
                if (participant == null)
                {
                    return NotFound();
                }

                var editViewModel = new TrainingParticipantEditViewModel
                {
                    Id = participant.Id,
                    TrainingId = participant.TrainingId,
                    EmployeeId = participant.EmployeeId,
                    Status = participant.Status,
                    Score = participant.Score,
                    Certificate = participant.Certificate,
                    Comments = participant.Comments
                };

                return View(editViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitim katılımcısı bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: TrainingParticipants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrainingId,EmployeeId,Status,Score,Certificate,Comments")] TrainingParticipantEditViewModel participant)
        {
            if (id != participant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.PutAsync<TrainingParticipantViewModel>($"trainingparticipants/{id}", participant);
                    TempData["Success"] = "Eğitim katılımcısı başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Eğitim katılımcısı güncellenirken hata oluştu: " + ex.Message;
                }
            }
            return View(participant);
        }

        // GET: TrainingParticipants/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var participant = await _apiService.GetAsync<TrainingParticipantViewModel>($"trainingparticipants/{id}");
                if (participant == null)
                {
                    return NotFound();
                }
                return View(participant);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitim katılımcısı bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: TrainingParticipants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _apiService.DeleteAsync($"trainingparticipants/{id}");
                if (result)
                {
                    TempData["Success"] = "Eğitim katılımcısı başarıyla silindi.";
                }
                else
                {
                    TempData["Error"] = "Eğitim katılımcısı silinirken hata oluştu.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitim katılımcısı silinirken hata oluştu: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TrainingParticipants/ByTraining/5
        public async Task<IActionResult> ByTraining(int trainingId)
        {
            try
            {
                var participants = await _apiService.GetAsync<List<TrainingParticipantViewModel>>($"trainingparticipants/training/{trainingId}");
                ViewBag.TrainingId = trainingId;
                return View(participants);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitim katılımcıları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: TrainingParticipants/ByEmployee/5
        public async Task<IActionResult> ByEmployee(int employeeId)
        {
            try
            {
                var participants = await _apiService.GetAsync<List<TrainingParticipantViewModel>>($"trainingparticipants/employee/{employeeId}");
                ViewBag.EmployeeId = employeeId;
                return View(participants);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Personel eğitim katılımları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: TrainingParticipants/Score/5
        public async Task<IActionResult> Score(int id)
        {
            try
            {
                var participant = await _apiService.GetAsync<TrainingParticipantViewModel>($"trainingparticipants/{id}");
                if (participant == null)
                {
                    return NotFound();
                }

                var scoreViewModel = new TrainingParticipantScoreViewModel
                {
                    Id = participant.Id,
                    Score = participant.Score ?? 0
                };

                return View(scoreViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitim katılımcısı bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: TrainingParticipants/Score/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Score(int id, [Bind("Id,Score,Comments")] TrainingParticipantScoreViewModel scoreViewModel)
        {
            if (id != scoreViewModel.Id)
            {
                return NotFound();
            }

            try
            {
                await _apiService.PutAsync<TrainingParticipantViewModel>($"trainingparticipants/{id}/score", scoreViewModel);
                TempData["Success"] = "Eğitim puanı başarıyla kaydedildi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Eğitim puanı kaydedilirken hata oluştu: " + ex.Message;
                return View(scoreViewModel);
            }
        }

        // GET: TrainingParticipants/Completed
        public async Task<IActionResult> Completed()
        {
            try
            {
                var participants = await _apiService.GetAsync<List<TrainingParticipantViewModel>>("trainingparticipants/completed");
                return View(participants);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Tamamlanan eğitim katılımları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: TrainingParticipants/Pending
        public async Task<IActionResult> Pending()
        {
            try
            {
                var participants = await _apiService.GetAsync<List<TrainingParticipantViewModel>>("trainingparticipants/pending");
                return View(participants);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Bekleyen eğitim katılımları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 