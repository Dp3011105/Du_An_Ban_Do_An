using DuAn.Authorization;
using DuAn.Data;
using DuAn.Models;
using DuAn.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace DuAn.Controllers
{
    [AuthorizeAdmin]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MyDbContext _context;
        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, MyDbContext context, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
         
        }




        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }


        public async Task<IActionResult> ListNguoiDung()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }








        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> EditNguoiDung(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("Tài khoản không tồn tại.");
            }

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new EditUserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Gender = user.Gender,
                Nationality = user.Nationality,
                Email = user.Email,
                AvailableRoles = roles.Select(role => new SelectListItem
                {
                    Value = role.Name,
                    Text = role.Name,
                    Selected = userRoles.Contains(role.Name)
                }).ToList(),
                SelectedRoles = userRoles.ToList()
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNguoiDung(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound("Tài khoản không tồn tại.");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.DateOfBirth = model.DateOfBirth;
            user.Address = model.Address;
            user.Gender = model.Gender;
            user.Nationality = model.Nationality;

            user.Role = model.SelectedRoles?.FirstOrDefault();

            await _userManager.UpdateAsync(user);

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (model.SelectedRoles != null && model.SelectedRoles.Any())
            {
                await _userManager.AddToRolesAsync(user, model.SelectedRoles);
            }

            return RedirectToAction("ListNguoiDung", "Admin");
        }


        //public IActionResult ListComBo()
        //{

        //    var comboList = _context.Combos
        //                            .Include(c => c.ChiTietCombos)
        //                            .ThenInclude(ct => ct.MaMonAnNavigation)
        //                            .ToList();

        //    return View(comboList);
        //}




        //public IActionResult CreateCombo()
        //{
        //    ViewBag.MonAnList = _context.MonAns.ToList();
        //    return View(new Combo());
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateCombo(Combo combo, List<int> selectedMonAnIds, List<string> selectedSoLuongs)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Combos.Add(combo);
        //        _context.SaveChanges();

        //        for (int i = 0; i < selectedMonAnIds.Count; i++)
        //        {
        //            int soLuong = int.Parse(selectedSoLuongs[i]);

        //            if (soLuong > 0)
        //            {
        //                var chiTiet = new Combodetails
        //                {
        //                    MaCombo = combo.MaCombo,
        //                    MaMonAn = selectedMonAnIds[i],
        //                    SoLuong = soLuong
        //                };
        //                _context.ChiTietCombos.Add(chiTiet);
        //            }
        //        }

        //        _context.SaveChanges();
        //        return RedirectToAction("ListComBo", "Admin");
        //    }

        //    ViewBag.MonAnList = _context.MonAns.Where(m => m.TrangThai == true).ToList();
        //    return View(combo);
        //}



        //public IActionResult EditCombo(int id)
        //{
        //    var combo = _context.Combos.Include(c => c.ChiTietCombos)
        //                               .ThenInclude(ct => ct.MaMonAnNavigation)
        //                               .FirstOrDefault(c => c.MaCombo == id);
        //    if (combo == null) return NotFound();

        //    ViewBag.MonAnList = _context.MonAns.ToList();
        //    return View(combo);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditCombo(int id, Combo updatedCombo, List<int> selectedMonAnIds, List<string> selectedSoLuongs)
        //{
        //    if (id != updatedCombo.MaCombo) return NotFound();

        //    if (ModelState.IsValid)
        //    {
        //        var combo = _context.Combos.Include(c => c.ChiTietCombos).FirstOrDefault(c => c.MaCombo == id);
        //        if (combo == null) return NotFound();

        //        combo.TenCombo = updatedCombo.TenCombo;
        //        combo.MoTa = updatedCombo.MoTa;
        //        combo.Gia = updatedCombo.Gia;
        //        combo.TrangThai = updatedCombo.TrangThai;
        //        combo.DuongDanHinh = updatedCombo.DuongDanHinh;

        //        _context.ChiTietCombos.RemoveRange(combo.ChiTietCombos);

        //        for (int i = 0; i < selectedMonAnIds.Count; i++)
        //        {
        //            int soLuong = int.Parse(selectedSoLuongs[i]);

        //            if (soLuong > 0)
        //            {
        //                var chiTiet = new Combodetails
        //                {
        //                    MaCombo = id,
        //                    MaMonAn = selectedMonAnIds[i],
        //                    SoLuong = soLuong
        //                };
        //                _context.ChiTietCombos.Add(chiTiet);
        //            }
        //        }

        //        _context.SaveChanges();
        //        return RedirectToAction("ListComBo", "Admin");
        //    }

        //    ViewBag.MonAnList = _context.MonAns.ToList();
        //    return View(updatedCombo);
        //}




        public IActionResult ListDonHang()
        {
            var donHangs = _context.DonHangs
                .Include(d => d.ChiTietDonHangs)
                    .ThenInclude(ct => ct.MaMonAnNavigation)
                .Include(d => d.ChiTietDonHangs)
                    .ThenInclude(ct => ct.MaComboNavigation)
                .ToList();

            return View(donHangs);
        }









        public IActionResult IndexTag()
        {
            var tags = _context.Tags.ToList();
            return View(tags);
        }

        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTag(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _context.Tags.Add(tag);
                _context.SaveChanges();
                return RedirectToAction(nameof(IndexTag));
            }
            return View(tag);
        }


        [HttpGet]
        public IActionResult EditTag(int id)
        {
            var tag = _context.Tags.FirstOrDefault(t => t.MaTag == id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTag(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _context.Update(tag);
                _context.SaveChanges();
                return RedirectToAction(nameof(IndexTag));
            }
            return View(tag);
        }







        // Action hiển thị danh sách món ăn
        public async Task<IActionResult> ListMonAn()
        {
            // Lấy tất cả món ăn và các thông tin liên quan (bao gồm Tag) từ cơ sở dữ liệu
            var monAnList = _context.MonAns
                                    .Include(m => m.MaTagNavigation) // Lấy thông tin về tag liên quan
                                    .ToList();

            return View(monAnList);
        }

        // Action hiển thị form thêm món ăn
        public IActionResult CreateMonAn()
        {
            ViewBag.Tags = _context.Tags.ToList();  // Truyền danh sách tags cho view
            return View(new Dish());
        }

        // Action xử lý form thêm món ăn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Dish monAn)
        {
            if (ModelState.IsValid)
            {
                _context.MonAns.Add(monAn);
                _context.SaveChanges();
                return RedirectToAction("ListMonAn", "Admin");
            }

            // Nếu có lỗi trong ModelState, truyền lại danh sách tags và Model về view
            ViewBag.Tags = _context.Tags.ToList();
            return View(monAn);
        }


        // Action hiển thị form sửa món ăn
        public async Task<IActionResult> EditMonAn(int id)
        {
            var monAn = await _context.MonAns.FindAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }
            ViewBag.Tags = _context.Tags.ToList(); // Lấy danh sách các tag để chọn
            return View(monAn);
        }

        // Action xử lý form sửa món ăn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMonAn(int id, Dish monAn)
        {
            if (id != monAn.MaMonAn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monAn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.MonAns.Any(m => m.MaMonAn == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListMonAn)); // Sau khi sửa, quay lại danh sách món ăn
            }
            ViewBag.Tags = _context.Tags.ToList(); // Nếu có lỗi, truyền lại danh sách tags
            return View(monAn);
        }



    }
}
