using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Web.Models;
using SD_IKYS.Web.Services;

namespace SD_IKYS.Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly IApiService _apiService;

        public RolesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var roles = await _apiService.GetAsync<List<RoleViewModel>>("roles");
                return View(roles ?? new List<RoleViewModel>());
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Roller yüklenirken hata oluştu: " + ex.Message;
                return View(new List<RoleViewModel>());
            }
        }

        public IActionResult Create()
        {
            return View(new RoleViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createdRole = await _apiService.PostAsync<RoleViewModel>("roles", roleViewModel);
                    TempData["Success"] = "Rol başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Rol oluşturulurken hata oluştu: " + ex.Message;
                }
            }
            return View(roleViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var role = await _apiService.GetAsync<RoleViewModel>($"roles/{id}");
                if (role == null)
                {
                    TempData["Error"] = "Rol bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(role);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Rol detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var role = await _apiService.GetAsync<RoleViewModel>($"roles/{id}");
                if (role == null)
                {
                    TempData["Error"] = "Rol bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(role);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Rol yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedRole = await _apiService.PutAsync<RoleViewModel>($"roles/{id}", roleViewModel);
                    TempData["Success"] = "Rol başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Rol güncellenirken hata oluştu: " + ex.Message;
                }
            }
            return View(roleViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var role = await _apiService.GetAsync<RoleViewModel>($"roles/{id}");
                if (role == null)
                {
                    TempData["Error"] = "Rol bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }
                return View(role);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Rol yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _apiService.DeleteAsync($"roles/{id}");
                if (result)
                {
                    TempData["Success"] = "Rol başarıyla silindi.";
                }
                else
                {
                    TempData["Error"] = "Rol silinemedi.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Rol silinirken hata oluştu: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
    }
} 