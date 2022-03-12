using Aula6.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aula6.Data
{
    public class DbInitializer
    {
        public static void Initialize(Aula6Context context)
        {
            context.Database.EnsureCreated();

            // Look for any categories
            if (context.Students.Any())
            {
                return; // DB has been seeded
            }

            Dictionary<string, List<Student>> collection = new();

            using (StreamReader sr = File.OpenText("Data\\studentslist_class06.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // splits the info number, name and course
                    string[] parts = line.Split(';');
                    // creates a dictionary with course as key
                    if (collection.ContainsKey(parts[2]) == false)
                    {
                        collection.Add(parts[2], new List<Student>());
                    }
                    // ... and list of students as Value
                    collection[parts[2]].Add(new Student { Number = Convert.ToInt32(parts[0]), Name = parts[1] });
                }
                foreach (var course in collection.Keys)
                {
                    context.Courses.Add(new Course { Name = course });
                }
                context.SaveChanges();

                // create Courses in Database
                foreach (var aux in collection)
                {
                    foreach (var s in aux.Value)
                    {
                        s.CourseId = context.Courses.Single(course => course.Name == aux.Key).Id;
                        context.Students.Add(s);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
