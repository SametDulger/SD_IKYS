using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Web.Models;
using SD_IKYS.Web.Services;

namespace SD_IKYS.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IApiService _apiService;

        public UsersController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _apiService.GetAsync<List<UserViewModel>>("users");
                return View(users);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Kullanıcılar yüklenirken hata oluştu: " + ex.Message;
                return View(new List<UserViewModel>());
            }
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var user = await _apiService.GetAsync<UserViewModel>($"users/{id}");
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Kullanıcı detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Email,Password,FirstName,LastName,PhoneNumber,RoleId")] UserCreateViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.PostAsync<UserViewModel>("users", user);
                    TempData["Success"] = "Kullanıcı başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Kullanıcı oluşturulurken hata oluştu: " + ex.Message;
                }
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var user = await _apiService.GetAsync<UserViewModel>($"users/{id}");
                if (user == null)
                {
                    return NotFound();
                }

                var editViewModel = new UserEditViewModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    RoleId = user.RoleId,
                    IsActive = user.IsActive
                };

                return View(editViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Kullanıcı bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Email,FirstName,LastName,PhoneNumber,RoleId,IsActive")] UserEditViewModel user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.PutAsync<UserViewModel>($"users/{id}", user);
                    TempData["Success"] = "Kullanıcı başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Kullanıcı güncellenirken hata oluştu: " + ex.Message;
                }
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _apiService.GetAsync<UserViewModel>($"users/{id}");
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Kullanıcı bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _apiService.DeleteAsync($"users/{id}");
                if (result)
                {
                    TempData["Success"] = "Kullanıcı başarıyla silindi.";
                }
                else
                {
                    TempData["Error"] = "Kullanıcı silinirken hata oluştu.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Kullanıcı silinirken hata oluştu: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Users/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username,Password")] LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _apiService.PostAsync<UserViewModel>("users/login", loginModel);
                    if (user != null)
                    {
                        // Session'a kullanıcı bilgilerini kaydet
                        HttpContext.Session.SetString("UserId", user.Id.ToString());
                        HttpContext.Session.SetString("Username", user.Username);
                        HttpContext.Session.SetString("UserRole", user.RoleName ?? "");
                        
                        TempData["Success"] = "Başarıyla giriş yaptınız.";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["Error"] = "Kullanıcı adı veya şifre hatalı.";
                    }
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Giriş yapılırken hata oluştu: " + ex.Message;
                }
            }
            return View(loginModel);
        }

        // GET: Users/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Success"] = "Başarıyla çıkış yaptınız.";
            return RedirectToAction("Index", "Home");
        }
    }
} 