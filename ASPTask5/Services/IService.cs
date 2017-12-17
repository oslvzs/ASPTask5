using ASPTask5.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace ASPTask5.Services
{
    public interface IService
    {
        List<StudentModel> GetList();
        void AddStudent(StudentModel student);
        StudentModel GetStudent(int id);
        void SetStudent(int id, StudentModel student);
        void DeleteStudent(int id);
    }

    public class Service : IService
    {
        public readonly StudentContext _context;

        public Service(StudentContext context)
        {
            _context = context;
        }

        public List<StudentModel> GetList()
        {
            List<StudentModel> listOfStudents = _context.Students.ToList();
            return listOfStudents;
        }

        public void AddStudent(StudentModel student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public StudentModel GetStudent(int id)
        {
            StudentModel student = _context.Students.Find(id);
            return student;
        }

        public void SetStudent(int id, StudentModel student)
        {
            StudentModel studentToUpdate = _context.Students.Find(id);
            studentToUpdate.Group = student.Group;
            studentToUpdate.Name = student.Name;
            studentToUpdate.Age = student.Age;
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            StudentModel student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }

}
