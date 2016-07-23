using CleanCode.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class StudentInMemoryRepository
    {
        private List<Student> students;
        private int count;

        public StudentInMemoryRepository()
        {
            this.students = new List<Student>();
        }

        public StudentInMemoryRepository(List<Student> students)
        {
            this.students = students;
        }

        public bool Add(Student student)
        {
            // Check if student is valid
            if (string.IsNullOrEmpty(student.FirstName) &&
                string.IsNullOrEmpty(student.LastName) &&
                string.IsNullOrEmpty(student.Document))
                return false;

            //Create id for new student
            student.Id = count++;

            //Add student
            this.students.Add(student);
            return true;
        }

        public bool AddOrUpdate(Student student)
        {
            // Check if student is valid
            if (string.IsNullOrEmpty(student.FirstName) &&
                string.IsNullOrEmpty(student.LastName) &&
                string.IsNullOrEmpty(student.Document))
                return false;

            // Add or update student
            var existingStudent = this.students.Where((x) => x.Id.Equals(student.Id)).SingleOrDefault();
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Document = student.Document;
            }
            else
            {
                student.Id = count++;
                this.students.Add(existingStudent);
            }
            return true;
        }

        public bool Update(Student student)
        {
            // Check if student is valid
            if (string.IsNullOrEmpty(student.FirstName) &&
                string.IsNullOrEmpty(student.LastName) &&
                string.IsNullOrEmpty(student.Document))
                return false;

            // Update student
            var existingStudent = this.students.Where((x) => x.Id.Equals(student.Id)).SingleOrDefault();
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Document = student.Document;
            return true;
        }

        public Student Get(int id)
        {
            return this.students.Where((x) => x.Id.Equals(id)).SingleOrDefault();
        }

        public List<Student> Get()
        {
            return this.students;
        }
    }
}
