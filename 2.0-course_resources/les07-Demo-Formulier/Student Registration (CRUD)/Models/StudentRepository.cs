using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Registration.Models
{
    public static class StudentRepository
    {
        private static List<Student> _students = new List<Student>();

        public static IEnumerable<Student> GetAll()
        {
            return _students.ToList();
        }

        public static Student GetById(int id)
        {
            return _students.Find(x => x.ID == id);
        }
        public static int Add(Student student)
        {
            int id = _students.Count() > 0 ? _students.Max(x => x.ID) + 1 : 1;
            student.ID = id;

            _students.Add(student);

            return id;                
        }

        public static void Update(Student student)
        {
            Student existing = _students.Find(x => x.ID == student.ID);
            _students.Remove(existing);
            _students.Add(student);
        }

        public static bool Delete(Student student)
        {
           return _students.Remove(student);
        }
    }
}
