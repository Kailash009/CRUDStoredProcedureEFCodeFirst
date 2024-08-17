using CRUDStoredProcedureEFCodeFirst.Models;
using CRUDStoredProcedureEFCodeFirst.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CRUDStoredProcedureEFCodeFirst.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _stu;
        public StudentController(IStudent stu)
        {
            _stu = stu;
        }
        public async Task<IActionResult> Index()
        {
            var students =await _stu.GetAllStudentAsync();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                bool b= await _stu.CreateStudentAsync(student);
                if(b!=false)
                {
                    TempData["insert"] = "<script>alert('Student Added SuccessFully!!');;</script>";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["insert"] = "<script>alert('Student Failed!!');;</script>";
                }
                
            }
            return View(student);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var students =await _stu.GetStudentByIdAsync(id);
            var single_student = students.Where(s => s.id == id).FirstOrDefault();
            return View(single_student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                bool b = await _stu.UpdateStudentAsync(student);
                if (b != false)
                {
                    TempData["update"] = "<script>alert('Student Updated SuccessFully!!');;</script>";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["update"] = "<script>alert('Student Failed!!');;</script>";
                }

            }
            return View(student);
        }
        public async Task<IActionResult> Details(int id)
        {
            var students = await _stu.GetStudentByIdAsync(id);
            var single_student = students.Where(s => s.id == id).FirstOrDefault();
            return View(single_student);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                bool b = await _stu.DeleteStudentAsync(id);
                if (b != false)
                {
                    TempData["delete"] = "<script>alert('Student Deleted SuccessFully!!');;</script>";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["delete"] = "<script>alert('Student Failed!!');;</script>";
                }

            }
            return View();
        }
    }
}
