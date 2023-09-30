using StudentAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using StudentAPI.DataAccess;
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Controllers;




namespace StudentAPI.Tests
{
    [TestClass]
    public class StudentControllerTests
    {
        private DbContextOptions<StudentDataContext> _options;

        [TestInitialize]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<StudentDataContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryStudentDatabase")
                .Options;

            using (var context = new StudentDataContext(_options))
            {
                // Seed in-memory database with test data
                context.Students.Add(new Student { StudentId = "S1234567", Gender = "Male", /* other properties */ });
                context.SaveChanges();
            }
        }

        [TestMethod]
        public async Task CreateStudent_ShouldReturn200StatusCode()
        {
            using (var context = new StudentDataContext(_options))
            {
                // Arrange
                var controller = new StudentController(context);
                var newStudent = new Student { StudentId = "S7654321", Gender = "Female", /* other properties */ };

                // Act
                var result = await controller.CreateStudent(newStudent);

                // Assert
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
                var createdAtActionResult = (CreatedAtActionResult)result.Result;
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, createdAtActionResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task UpdateStudent_ShouldReturn200StatusCode()
        {
            using (var context = new StudentDataContext(_options))
            {
                // Arrange
                var controller = new StudentController(context);
                var updatedStudent = new Student { StudentId = "S1234567", Gender = "Updated Gender", /* updated properties */ };

                // Act
                var result = await controller.UpdateStudent("S1234567", updatedStudent);

                // Assert
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(OkObjectResult));
                var okObjectResult = (OkObjectResult)result;
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, okObjectResult.StatusCode);
            }
        }

        [TestMethod]
        public async Task DeleteStudent_ShouldReturn200StatusCode()
        {
            using (var context = new StudentDataContext(_options))
            {
                // Arrange
                var controller = new StudentController(context);

                // Act
                var result = await controller.DeleteStudent("S1234567");

                // Assert
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(OkObjectResult));
                var okObjectResult = (OkObjectResult)result;
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, okObjectResult.StatusCode);
            }
        }

        [TestMethod]
        public void GetAllStudents_ShouldReturn200StatusCode()
        {
            using (var context = new StudentDataContext(_options))
            {
                // Arrange
                var controller = new StudentController(context);

                // Act
                var result = controller.GetAll();

                // Assert
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
                var okObjectResult = (OkObjectResult)result.Result;
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, okObjectResult.StatusCode);
            }
        }

        [TestMethod]
        public void GetStudentById_ShouldReturn200StatusCode()
        {
            using (var context = new StudentDataContext(_options))
            {
                // Arrange
                var controller = new StudentController(context);

                // Act
                var result = controller.GetStudentById("S1234567");

                // Assert
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
                var okObjectResult = (OkObjectResult)result.Result;
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, okObjectResult.StatusCode);
            }
        }
    }
}
