using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using task5.Models;

namespace task5.Controllers
{
	public class UserController1 : Controller
	{
		private readonly TaskContext? _context;
		public UserController1() => _context = new TaskContext();
		
		public IActionResult Index()
		{
			var users = _context?.users.ToList();
			return View(users);
		}
		[HttpPost]
		public IActionResult Index(string search)
		{
			ViewBag.Search = search;
			if (search == null)
			{
				return RedirectToAction("Index");
			}
			var users = _context?.users.Where(u => 
			u.Name.Contains(search)  ||
			u.Email.Contains(search) ||
			u.phone.Contains(search) ||
			u.Age.ToString().Contains(search)
			).ToList();
			return View(users);
		}
		public IActionResult Show(int id)
		{
			var user = _context?.users.Include(c => c.course).FirstOrDefault(x => x.Id == id);
			return View(user);
		}
		[HttpGet]
		public IActionResult Add()
		{
			GetCourses();
			return View();
		}
		private void GetCourses()
		{
			var courses = _context?.courses.Select(c => new SelectListItem(c.Name, c.Id.ToString()));
			ViewBag.courses = courses;
		}
		[HttpPost]
		public IActionResult Add(User newUser)
		{
			if (!ModelState.IsValid)
			{
				GetCourses();
				return View();
			}
			_context?.users.Add(newUser);
			_context?.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var user = _context?.users.Find(id);
			GetCourses();
			return View(user);
		}
		[HttpPost]
		public IActionResult Edit(User user)
		{
			if (!ModelState.IsValid)
			{
				GetCourses();
				return View();
			}
			var _user = _context?.users.Find(user.Id);
			_user!.Name = user.Name;
			_user.Email = user.Email;
			_user.Age = user.Age;
			_user.CourseId = user.CourseId;
			_context?.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Delete(int id)
		{
			var _user = _context?.users.FirstOrDefault(u => u.Id == id);
			_context?.users.Remove(_user!);
			_context?.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
