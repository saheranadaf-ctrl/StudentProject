using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentApi.Controllers;
using StudentAPI.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace StudentApiTesting;

public class UnitTest1
{
    [Fact]
    public void GetAll_ReturnsOk()
    {
        // Arrange
        var dbContextMock = new Mock<StudentDataContext>();
        var controller = new StudentController(dbContextMock.Object);
        var students = new List<Student>
            {
                new Student
                {
                    StudentId = "STDN00482",
                    Gender = "M",
                    NationalIty = "indian",
                    PlaceofBirth = "Odisha",
                    StageId = "MiddleSchool",
                    GradeId = "G-08",
                    SectionId = "D",
                    Topic = "ECC",
                    Semester = "8th",
                    Relation = "Son",
                    Raisedhands = 5,
                    VisItedResources = 12,
                    AnnouncementsView = 13,
                    Discussion = 6,
                    ParentAnsweringSurvey = "Yes",
                    ParentschoolSatisfaction = "good",
                    StudentAbsenceDays = "below-7",
                    StudentMarks = 87,
                    Class = "A"
                }
            };

        var studentQuery = students.AsQueryable();
        var dbSetMock = new Mock<DbSet<Student>>();

        dbSetMock.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(studentQuery.Provider);
        dbSetMock.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(studentQuery.Expression);
        dbSetMock.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(studentQuery.ElementType);
        dbSetMock.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(() => studentQuery.GetEnumerator());

        dbContextMock.Setup(x => x.Students).Returns(dbSetMock.Object);

        // Act
        var result = controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Student>>(okResult.Value);
        Assert.Equal(students, model);
    }
}