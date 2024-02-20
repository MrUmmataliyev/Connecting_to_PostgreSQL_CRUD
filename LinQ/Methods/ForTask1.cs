using LinQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ.Methods
{
    public class ForTask1
    {
        public List<University> GetAll()
        {
            List<University> list = new List<University>()
            {
                new University
                {
                    Id = 1,
                    Name = "Najot Ta'lim",
                    Location = "Chilonzor",
                    Students =
                     new List<Student>() {
                        new Student() { Id = 1, Age = 27, StudyType = "Bujet", FirstName = "Akramjon", LastName = "Abduvahobov" },
                        new Student() { Id = 2, Age = 20, StudyType = "Contract", FirstName = "Abduxoliq", LastName = "Abduxoliqov" },
                        new Student() { Id = 3, Age = 23, StudyType = "Bujet", FirstName = "Muhammad Abdulloh", LastName = "Muhammad Abdullohov" },
                        new Student() { Id = 4, Age = 40, StudyType = "Bujet", FirstName = "Ikromjon", LastName = "Ikromjon" },
                     }
                },
                new University
                {
                    Id = 2,
                    Name = "Salim",
                    Location = "Anjanda",
                    Students =
                     new List<Student>() {
                        new Student() { Id = 5, Age = 27, StudyType = "Bujet", FirstName = "AkramjonAAA", LastName = "Abduvahobov" },
                        new Student() { Id = 6, Age = 20, StudyType = "Contract", FirstName = "AbduxoliqAAA", LastName = "Abduxoliqov" },
                        new Student() { Id = 7, Age = 23, StudyType = "Bujet", FirstName = "Muhammad AbdullohAAA", LastName = "Muhammad Abdullohov" },
                        new Student() { Id = 8, Age = 40, StudyType = "Bujet", FirstName = "IkromjonAAA", LastName = "Ikromjon" },
                     }
                }
            };
            return list;
        }
        public IEnumerable<Student> GetCenterByNameWithExperience()
        {
            var result = GetAll().Where(a=> a.Name== "Salim").SelectMany(x => x.Students).Where(z => z.StudyType == "Bujet");

            return result;
        }
    }
}
