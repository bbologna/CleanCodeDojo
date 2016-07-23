using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using CleanCode.Entities;

namespace CleanCode
{

    /// <summary>
    /// Niveles de abstraccion
    /// </summary>
    public class StudentsSynchronize
    {
        private List<Student> registeredStudents = new List<Student>();
        private StudentInMemoryRepository studentRepository;

        public StudentsSynchronize(StudentInMemoryRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public void SynchronizeStudents()
        {
            var students = studentRepository.Get();

            var unregisteredStudents = students.Where(s => !registeredStudents.Any(rs => rs.Id.Equals(s.Id)));

            RestClient client = new RestClient("http://localhost/university/api");
            var request = new RestRequest("student/batch", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", unregisteredStudents, ParameterType.RequestBody);
            var response = client.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.registeredStudents.AddRange(unregisteredStudents);
            }
        }
    }
}
