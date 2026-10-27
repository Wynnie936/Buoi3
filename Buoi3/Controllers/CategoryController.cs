using Buoi3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// tao thu muc nay bang cach: chuot phai vao Buoi3/Controllers -> Add -> Controller -> MVC Controller - write (dong so 2 ) -> dat ten la CategoryController
namespace Buoi3.Controllers
{
    public class CategoryController : Controller
    {
        public static List<Models.Category> categories = new List<Models.Category>()
        {
            new Models.Category() {Id = 1, Name = "Laptop", Description = "Latop"},
            new Models.Category() {Id = 2, Name = "Phone", Description = "Description 2"},
            new Models.Category() {Id = 3, Name = "Tablet", Description = "Description 3"},
            // neu khai bao using Day3.Models; thi co the viet gon hon nhu sau: public static List<Category> categories = new List<Category>() { new Category() {Id = 1, Name = "Laptop", Description = "Latop"}, new Category() {Id = 2, Name = "Phone", Description = "Description 2"}, new Category() {Id = 3, Name = "Tablet", Description = "Description 3"}
            // diem khac nhau giua khai bao dung using va khong dung using la khi dung using thi chi can viet ten lop, khong can viet ten namespace cua lop do, con khi khong dung using thi phai viet ten namespace cua lop do
        };
        // GET: CategoryController

        // mac dinh cua Public ActionResult Index() => [HttpGet] public ActionResult Index() => [HttpGet] la mac dinh cua ActionResult Index() nen khong can viet [HttpGet] truoc ActionResult Index()
        public ActionResult Index()
        {
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View();
        }


        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Category category)
        {  category.Id = categories.Count + 1;
            categories.Add(category);
           return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var editCategory = categories.FirstOrDefault(c => c.Id == id);
            if (editCategory == null)
            {
                return NotFound();
            }
            return View(editCategory);
        }
        // return View(categories) => do du lieu vao View va se duoc hien thi len Index 
        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;

            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
