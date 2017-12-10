using ASPTask5.Models;
using System.Collections.Generic;

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
        private static List<StudentModel> listOfStudents = new List<StudentModel>();


        public List<StudentModel> GetList()
        {
            return listOfStudents;
        }

        public void AddStudent(StudentModel student)
        {
            listOfStudents.Add(student);
        }

        public StudentModel GetStudent(int id)
        {
            return listOfStudents[id];
        }

        public void SetStudent(int id, StudentModel student)
        {
            listOfStudents[id] = student;
        }

        public void DeleteStudent(int id)
        {
            listOfStudents.Remove(listOfStudents[id]);
        }
    }
}
