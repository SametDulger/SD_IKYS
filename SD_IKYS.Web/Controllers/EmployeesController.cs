using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Web.Models;
using SD_IKYS.Web.Services;

namespace SD_IKYS.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IApiService _apiService;

        public EmployeesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            try
            {
                var employees = await _apiService.GetAsync<List<EmployeeViewModel>>("employees");
                return View(employees);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Personel listesi yüklenirken hata oluştu: " + ex.Message;
                return View(new List<EmployeeViewModel>());
            }
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var employee = await _apiService.GetAsync<EmployeeViewModel>($"employees/{id}");
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Personel detayları yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TCKN,FirstName,LastName,MiddleName,DateOfBirth,PlaceOfBirth,PhoneNumber,Email,Address,HireDate,Position,Department,Salary,ManagerId,UserId")] EmployeeCreateViewModel employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.PostAsync<EmployeeViewModel>("employees", employee);
                    TempData["Success"] = "Personel başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Personel oluşturulurken hata oluştu: " + ex.Message;
                }
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var employee = await _apiService.GetAsync<EmployeeViewModel>($"employees/{id}");
                if (employee == null)
                {
                    return NotFound();
                }

                var editViewModel = new EmployeeEditViewModel
                {
                    Id = employee.Id,
                    TCKN = employee.TCKN,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    MiddleName = employee.MiddleName,
                    DateOfBirth = employee.DateOfBirth,
                    PlaceOfBirth = employee.PlaceOfBirth,
                    PhoneNumber = employee.PhoneNumber,
                    Email = employee.Email,
                    Address = employee.Address,
                    HireDate = employee.HireDate,
                    Position = employee.Position,
                    Department = employee.Department,
                    Salary = employee.Salary,
                    ManagerId = employee.ManagerId,
                    UserId = employee.UserId,
                    IsActive = employee.IsActive
                };

                return View(editViewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Personel bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TCKN,FirstName,LastName,MiddleName,DateOfBirth,PlaceOfBirth,PhoneNumber,Email,Address,HireDate,Position,Department,Salary,ManagerId,UserId,IsActive")] EmployeeEditViewModel employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.PutAsync<EmployeeViewModel>($"employees/{id}", employee);
                    TempData["Success"] = "Personel başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Personel güncellenirken hata oluştu: " + ex.Message;
                }
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var employee = await _apiService.GetAsync<EmployeeViewModel>($"employees/{id}");
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Personel bilgileri yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _apiService.DeleteAsync($"employees/{id}");
                if (result)
                {
                    TempData["Success"] = "Personel başarıyla silindi.";
                }
                else
                {
                    TempData["Error"] = "Personel silinirken hata oluştu.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Personel silinirken hata oluştu: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/ByDepartment/department
        public async Task<IActionResult> ByDepartment(string department)
        {
            try
            {
                var employees = await _apiService.GetAsync<List<EmployeeViewModel>>($"employees/department/{department}");
                ViewBag.Department = department;
                return View(employees);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Departman personeli yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Employees/Active
        public async Task<IActionResult> Active()
        {
            try
            {
                var employees = await _apiService.GetAsync<List<EmployeeViewModel>>("employees/active");
                return View(employees);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Aktif personel listesi yüklenirken hata oluştu: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 