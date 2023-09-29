using Microsoft.AspNetCore.Mvc;
using task5.Models;

namespace task5.Controllers
{
	public class CourseController1 : Controller
	{
		TaskContext? _context;
		public CourseController1() => _context = new TaskContext();
		public IActionResult Index()
		{
			var course = _context?.courses.ToList();
			return View(course);
		}
		[HttpPost]
		public IActionResult Index(string search)
		{
			ViewBag.search = search;
			if(search == null)
			{
				return RedirectToAction(nameof(Index));
			}
			var courses = _context?.courses.Where(
				c => c.Name.Contains(search) ||
				c.Description.Contains(search) ||
				c.Hour.ToString().Contains(search))
				.ToList();
			return View(courses);
		}
		public IActionResult Show(int id)
		{
			var course = _context?.courses.First(x =>
			x.Id == id);
			return View(course);
		}
		[HttpGet]
		public IActionResult Add() => View();
		[HttpPost]
		public IActionResult Add(Course newCourse)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			_context?.courses.Add(newCourse);
			_context?.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var course = _context?.courses.Find(id);
			return View(course);
		}
		[HttpPost]
		public IActionResult Edit(Course course)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var _course = _context?.courses.Find(course.Id);
			_course!.Name = course.Name;
			_course.Description = course.Description;
			_course.Hour = course.Hour;
			_context?.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Delete(int id)
		{
			var course = _context?.courses.Find(id);
			_context?.courses.Remove(course!);
			_context?.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

	}
}
