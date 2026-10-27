using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Buoi3.Models;

namespace Buoi3.Controllers
{
    public class ProductController : Controller
    {
        // Giả lập "cơ sở dữ liệu trong bộ nhớ"
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500, Description = "Powerful laptop" },
            new Product { Id = 2, Name = "Mouse", Price = 25, Description = "Wireless mouse" },
            new Product { Id = 3, Name = "Keyboard", Price = 50, Description = "Mechanical keyboard" }
        };

        // --- GET: Hiển thị danh sách sản phẩm ---
        public IActionResult Index()
        {
            return View(_products);
        }

        // --- Action Details ---
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // --- GET: Create Form ---
        public IActionResult Create()
        {
            return View(); // Đã xóa số 59 bị dính
        }

        // --- POST: Xử lý form gửi về ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product newProduct)
        {
            // Kiểm tra danh sách có rỗng không trước khi lấy Max Id để tránh crash
            newProduct.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(newProduct);
            return RedirectToAction(nameof(Index));
        }

        // --- GET: Hiển thị form sửa sản phẩm ---
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // --- POST: Nhận dữ liệu sau khi sửa ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;
            return RedirectToAction(nameof(Index));
        }

        // --- GET: Hiển thị xác nhận xóa ---
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // --- POST: Xác nhận xóa ---
        [HttpPost, ActionName("Delete")] // Đã xóa số 60 bị dính
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}