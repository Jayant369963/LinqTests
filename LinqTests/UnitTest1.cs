using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTests
{
    public class Tests
    {
        IReadOnlyCollection<Student> studentList;

        #region Linq
        [SetUp]
        public void Setup()
        {
            studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 20 } ,
                new Student() { StudentID = 7, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 8, StudentName = "Bill" , Age = 20 } ,
                new Student() { StudentID = 9, StudentName = "Ron" , Age = 15 }
            };
        }

        //'select * from dbo.Student where Age < 20'
        [Test]
        public void TestGetStudentsById()
        {
            try
            {
                // Act Functional Code
                Func<Student,  bool> ageFilter = (t) => t.Age > 0;
                var studentsFilteredByAge = studentList.Where(ageFilter).Select(t => t.StudentName);

                var studentFilteredByAgeAndName = studentList.Where(ageFilter).Where(t => t.StudentName.StartsWith("R")).ToList();

                // query languange syntax
                var studentFromQueryLang = from student in studentList where student.StudentID == 1 select student;
                Assert.IsNotNull(studentsFilteredByAge);
                //Assert.AreEqual(studentFromFunctionalCode.First(), "John");

            }
            catch (Exception)
            {
            
            }
            // Assert
          
        }

        #endregion

        #region Covariance and Contravariance & Delegates
        // Covariance
        [Test]
        public void TestFuncDelegateActionDelegate()
        {
            // Arrange
            string str = "test";
            // An object of a more derived type is assigned to an object of a less derived type.
            object obj = str;
            Func<Student, bool> test = new Func<Student, bool>(IsStudentATeenager);

            var student = studentList.First();
            // Act
            var result = test.Invoke(student);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestActionDelegateActionDelegate()
        {
            // Arrange
            var test = new Action<Student>(IncrementAge);
            var student = studentList.First();
            var age = student.Age;

            var uniStudent = new UniversityStudent();
            // Act
            test.Invoke(uniStudent);

            // Assert
            Assert.AreEqual(student.Age, age + 1);
        }

        bool IsStudentATeenager(Student student) => student.Age <= 19;

        void IncrementAge(Student student) => student.Age++;
        #endregion

    }
}