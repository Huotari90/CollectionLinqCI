﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CollectionLinqAssignment
{
    public static class Assignments
    {
        /// <summary>
        /// Given an array of integers, return a new array containing only the even numbers.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static int[] FindEvenNumbers(int[] numbers)
        {
            //1. Introduction to LINQ with Arrays
            //Objective: Familiarize with basic LINQ operations.
            //Task:

            //Create an array of integers.
            //Use LINQ to find and return all even numbers back. Note the method return type
            //Also return empty array if the input is null.


            // Check if the input is null and return an empty array if so.
            if (numbers == null)
            {
                return Array.Empty<int>();
            }

            // Use LINQ to find and return all even numbers.
            var evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();
            return evenNumbers;


        }

        /// <summary>
        /// Find strings that starts with lettter A
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static List<string> FindStringsStartingWithA(List<string> strings)
        {
            //2. LINQ with Lists
            //Objective: Understand how LINQ operates on List<T>.
            //Task:
            //
            //Create a list of strings.
            //Use LINQ to find all strings that start with the letter 'A' and return them.
            //Also return empty list if the input is null.
            // Use LINQ to filter the list of strings where the string starts with "A".

            // Check if the input list is null and return an empty list if so.
            if (strings == null)
            {
                return new List<string>();
            }

            return strings.Where(s => s.StartsWith("A")).ToList();

        }

        /// <summary>
        /// Find cities with a population greater than 1 million and print them
        /// </summary>
        /// <param name="cities"></param>
        /// <returns></returns>
        public static Dictionary<string, int> FindCitiesWithPopulationOverOneMillion(Dictionary<string, int> cities)
        {
            //3. LINQ with Dictionaries
            //Objective: Grasp querying key-value pairs.
            //Task:
            //
            //Create a dictionary with city names as keys and populations as values.
            //Use LINQ to find cities with a population greater than 1 million and return them.
            //Hint check Where() and ToDictionary() methods.

            //Also return empty dictionary if the input is null.

            if (cities == null)
                return new Dictionary<string, int>();

            var citiesOverOneMillion = cities
                .Where(cities => cities.Value >= 1000000)
                .ToDictionary(cities => cities.Key, cities => cities.Value);

            var yliMiljoona = new Dictionary<string, int>();

            foreach (var city in cities)
            {
                if (city.Value >= 100000)
                    yliMiljoona.Add(city.Key, city.Value);
            }


            return citiesOverOneMillion;

            throw new NotImplementedException();
        }


        /// <summary>
        /// Filter electronics that are under 100
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static List<Product> FilterElectronicsUnder100(List<Product> products)
        {
            //4. Complex Filtering with LINQ
            //Objective: Utilize multiple conditions in LINQ.
            //Task:
            //
            //Given a list of products with properties Name, Price, and Category, use LINQ to find all products in the "Electronics" category with a price less than $100.
            //Also return empty list if the input is null.

            if (products == null)
            {
                return new List<Product>();
            }

            return products
                .Where(product => product.Category == "Electronics" && product.Price < 100)
                .ToList();
        }


        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public static List<object> ProjectFullNameAndIsAdult(List<Person> people)
        {
            //5. LINQ with Anonymous Types
            //Objective: Understand anonymous types and their role in LINQ.
            //Task:
            //
            //Use LINQ to create a new list where each entry is an anonymous type with properties: FullName, and IsAdult.
            //FullName = (a combination of FirstName and LastName) and IsAdult = (a boolean indicating if age is 18 or above).
            //Also return empty list if the input is null.
            //
            //Hint: Use the new keyword to create an anonymous type. and check Select() method.
            throw new NotImplementedException();
        }

        public class Sale
        {
            public int ProductId { get; set; }
            public decimal AmountSold { get; set; }
            public DateTime SaleDate { get; set; }
        }

        /// <summary>
        /// Returns 
        /// </summary>
        /// <param name="sales"></param>
        /// <returns></returns>
        public static Dictionary<int, decimal> TotalAmountSoldPerProduct(List<Sale> sales)
        {
            //6. Aggregation with LINQ
            //| OBJECTIVE:                                                  |
            //| Understand how to aggregate data using LINQ.               |
            //|                                                            |
            //| TASK:                                                      |
            //| From a list of sales records with properties ProductId,    |
            //| AmountSold, and SaleDate, find the total amount sold for   |
            //| each product.                                              |
            //|                                                            |
            //| SAMPLE DATA:                                               |
            //| +----------+------------+--------------+                    |
            //| | ProductId| AmountSold | SaleDate     |                    |
            //| +----------+------------+--------------+                    |
            //| |    1     | 100.0      | 2023-08-25   |                    |
            //| |    1     | 200.0      | 2023-08-26   |                    |
            //| |    2     | 50.0       | 2023-08-25   |                    |
            //| |    2     | 150.0      | 2023-08-26   |                    |
            //| +----------+------------+--------------+                    |
            //|                                                            |
            //| EXPECTED OUTPUT:                                           |
            //| +----------+------------------+                             |
            //| | ProductId| TotalAmountSold |                             |
            //| +----------+------------------+                             |
            //| |    1     | 300.0           |                             |
            //| |    2     | 200.0           |                             |
            //| +----------+------------------+                             |
            //+------------------------------------
            //
            //Hint: check GroupBy() and Sum() methods.
            //Also return empty list if the input is null.

            if (sales == null)
            {
                return new Dictionary<int, decimal>();
            }

            return sales
                .GroupBy(sale => sale.ProductId)
                .ToDictionary(group => group.Key, group => group.Sum(sale => sale.AmountSold));
        }

        public static List<Student> GetStudentsFromEachSchool(List<School> schools)
        {
            // +-------------------------------------------------------------+
            // | OBJECTIVE:                                                  |
            // | Flatten nested collections and aggregate data using LINQ.   |
            // |                                                            |
            // | TASK:                                                      |
            // | Given a list of schools where each school has a Name and a  |
            // | list of Students (each student having properties like Name, |
            // | GradeLevel, GPA, etc.), create a single list of all students|
            // | from all the schools.                                       |
            // |                                                            |
            // | SAMPLE DATA:                                               |
            // | Schools: HighSchool A, HighSchool B                        |
            // | HighSchool A Students:                                     |
            // | +------+------------+------+                               |
            // | | Name | GradeLevel | GPA  |                               |
            // | +------+------------+------+                               |
            // | | Eva  | 11         | 3.7  |                               |
            // | | Frank| 10         | 3.5  |                               |
            // |                                                            |
            // | HighSchool B Students:                                     |
            // | +------+------------+------+                               |
            // | | Name | GradeLevel | GPA | |
            //
            // | +------+------------+------+ |
            // | | Grace | 12 | 3.8 | |
            // | | Helen | 10 | 3.6 | |
            // | |
            // | EXPECTED OUTPUT: |
            // | A combined list of all students from all schools: |
            // | +------+------------+------+ |
            // | | Name | GradeLevel | GPA | |
            // | +------+------------+------+ |
            // | | Eva | 11 | 3.7 | |
            // | | Frank| 10 | 3.5 | |
            // | | Grace| 12 | 3.8 | |
            // | | Helen| 10 | 3.6 | |
            // | +------+------------+------+ |
            // +-------------------------------------------------------------+
            // Hint: Use SelectMany() to flatten the list of students from all schools.

            // Check if the input list is null and return an empty list if so.
            if (schools == null)
            {
                return new List<Student>();
            }

            // Use SelectMany to flatten the list of students from all schools.
            var allStudents = schools.SelectMany(school => school.Students).ToList();

            return allStudents;

        }




        public static List<Student> TopStudentFromEachGrade(List<Student> students)
        {
            //7. Grouping and Sorting with LINQ
            //Objective: Use LINQ to group and order data. Hint: Use GroupBy and OrderBy.
            //| OBJECTIVE:                                                  |
            //| Use LINQ to group and order data.                           |
            //|                                                            |
            //| TASK:                                                      |
            //| From a list of students with properties Name, GradeLevel,   |
            //| and GPA, group students by GradeLevel and then sort each    |
            //| group by GPA in descending order. Print the top student     |
            //| from each grade level.                                      |
            //|                                                            |
            //| SAMPLE DATA:                                               |
            //| +-------+------------+------+                               |
            //| | Name  | GradeLevel | GPA  |                               |
            //| +-------+------------+------+                               |
            //| | Alice | 10         | 3.5  |                               |
            //| | Bob   | 10         | 3.6  |                               |
            //| | Charlie| 11        | 3.7  |                               |
            //| | David | 11        | 3.8  |                               |
            //| +-------+------------+------+                               |
            //|                                                            |
            //| EXPECTED OUTPUT:                                           |
            //| Grade 10 Top Student: Bob with GPA 3.6                      |
            //| Grade 11 Top Student: David with GPA 3.8    
            //Also return empty list if the input is null.

            if (students == null)
            {
                // Return an empty list if the input is null to handle null inputs gracefully.
                return new List<Student>();
            }

            return students
                .GroupBy(student => student.GradeLevel) // Group by GradeLevel
                .Select(group => group.OrderByDescending(student => student.GPA).First()) // Get the top student by GPA in each group
                .ToList(); // Convert the result to a List<Student>

        }



        public static List<School> SchoolsWithTopGrades(List<School> schools)
        {
            //8. LINQ with Complex Objects
            //+-------------------------------------------------------------+
            //| OBJECTIVE:                                                  |
            //| Use LINQ with nested objects and collections.               |
            //|                                                            |
            //| TASK:                                                      |
            //| Given a list of schools where each school has a Name and a  |
            //| list of Students (each student having Name, Age, and Grade),|
            //| use LINQ to find all schools that have at least one student |
            //| with a grade above 90.                                      |
            //|                                                            |
            //| SAMPLE DATA:                                               |
            //| School: HighSchool A                                        |
            //| +-----+-----+-------+                                       |
            //| |Name | Age | Grade |                                       |
            //| +-----+-----+-------+                                       |
            //| | Eva | 17  | 91    |                                       |
            //| | Frank| 16 | 85    |                                       |
            //|                                                            |
            //| School: HighSchool B                                        |
            //| +-----+-----+-------+                                       |
            //| |Name | Age | Grade |                                       |
            //| +-----+-----+-------+                                       |
            //| | Grace| 16 | 89    |                                       |
            //|                                                            |
            //| EXPECTED OUTPUT:                                           |
            //| Schools with students having grade above 90: HighSchool A   |
            //+-------------------------------------------------------------+
            //Also return empty list if the input is null.

            if (schools == null)
            {
                // Return an empty list if the input is null to handle null inputs gracefully.
                return new List<School>();
            }

            // Use LINQ to filter schools
            var schoolsWithTopGrades = schools
                // Filter schools to find ones with any student having a grade above 90
                .Where(school => school.Students.Any(student => student.Grade > 90))
                .ToList();

            return schoolsWithTopGrades;


        }

        public static Dictionary<string, double> CalculateAverageScores(List<Student> students)
        {
            // 9. Calculating Averages with LINQ
            // +-------------------------------------------------------------+
            // | OBJECTIVE:                                                  |
            // | Use LINQ to calculate averages from nested collections.     |
            // |                                                            |
            // | TASK:                                                      |
            // | Given a list of students where each student has a Name and  |
            // | a list of SubjectScores (each having SubjectName and Score),|
            // | calculate the average score for each student across all     |
            // | their subjects.                                             |
            // |                                                            |
            // | SAMPLE DATA:                                               |
            // | Student: Alice                                              |
            // | +-------------+-------+                                     |
            // | |SubjectName  | Score |                                     |
            // | +-------------+-------+                                     |
            // | | Math        | 80    |                                     |
            // | | Science     | 90    |                                     |
            // |                                                            |
            // | Student: Bob                                                |
            // | +-------------+-------+                                     |
            // | |SubjectName  | Score |                                     |
            // | +-------------+-------+                                     |
            // | | Math        | 85    |                                     |
            // | | Science     | 95    |                                     |
            // |                                                            |
            // | EXPECTED OUTPUT:                                           |
            // | {"Alice": 85, "Bob": 90}                                   |
            // +-------------------------------------------------------------+
            // Return an empty dictionary if the input is null to handle null inputs gracefully.
            //Hint: Use Select and ToDictionary methods.

            if (students == null) return new Dictionary<string, double>();

            return students
                .Select(s => new
                {
                    StudentName = s.Name,
                    AverageScore = s.Subject.Average(ss => ss.Score)
                })
                .ToDictionary(x => x.StudentName, x => x.AverageScore);
        }

        public static Dictionary<string, Student> FindTopPerformersInEachSubject(List<School> schools)
        {
            // 10. Finding Top Performers in Each Subject with LINQ
            // +-------------------------------------------------------------+
            // | OBJECTIVE:                                                  |
            // | Use LINQ to find the top performers in each subject across  |
            // | multiple schools.                                           |
            // |                                                            |
            // | TASK:                                                      |
            // | Given a list of schools where each school has a Name and a  |
            // | list of Students (each student having Name, Subject, and    |
            // | Grade), find the top performer in each subject across all   |
            // | schools.                                                    |
            // |                                                            |
            // | SAMPLE DATA:                                               |
            // | Schools: HighSchool A, HighSchool B                         |
            // | HighSchool A Students:                                     |
            // | +------+--------+-------+                                  |
            // | | Name | Subject| Grade |                                  |
            // | +------+--------+-------+                                  |
            // | | Eva  | Math   | 91    |                                  |
            // | | Frank| Science| 85    |                                  |
            // |                                                            |
            // | HighSchool B Students:                                     |
            // | +------+--------+-------+                                  |
            // | | Name | Subject| Grade |                                  |
            // | | Grace| Math   | 95    |                                  |
            // | | Helen| Science| 89    |                                  |
            // |                                                            |
            // | EXPECTED OUTPUT:                                           |
            // | {"Math": Grace, "Science": Eva}                            |
            // +-------------------------------------------------------------+
            // Return an empty dictionary if the input is null to handle null inputs gracefully.
            //Hint: Use SelectMany()
            // Flatten the list of subjects across all students and schools, and then group them by the subject name.

            if (schools == null)
            {
                return new Dictionary<string, Student>();
            }

            // Flatten students from all schools and their subjects into a single collection.
            var subjectScores = schools.SelectMany(school => school.Students
                                                                .SelectMany(student => student.Subject.Select(subject => new { Student = student, Subject = subject })));

            // Group by subject name, then find the top performer for each subject.
            var topPerformers = subjectScores
                .GroupBy(x => x.Subject.Name)
                .Select(g => new
                {
                    SubjectName = g.Key,
                    TopPerformer = g.OrderByDescending(x => x.Subject.Score).First().Student
                })
                .ToDictionary(x => x.SubjectName, x => x.TopPerformer);

            return topPerformers;

        }
    }
}
