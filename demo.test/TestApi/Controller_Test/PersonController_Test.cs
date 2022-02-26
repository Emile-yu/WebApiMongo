using demo.IService;
using demo.mongo.common.Model;
using demo.server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestApi.Controller_Test
{
    public class PersonController_Test
    {
        PersonController controller;

        Mock<IPersonService> mockPersonService = new Mock<IPersonService>();

        public PersonController_Test()
        {
            mockPersonService.Setup(o => o.FindById("111")).Returns(new Person 
            { Id = "sss", Age = 8, Name = "Alice", Score = 99 
            });

            controller = new PersonController(mockPersonService.Object);
        }

        [Fact]
        public void Test_FindById_Ok()
        {
            IActionResult actionResult = controller.Get("111");

            var oKObjectResult = Assert.IsType<OkObjectResult>(actionResult);

            var result = Assert.IsAssignableFrom<Person>(oKObjectResult.Value);

            Assert.Equal(8, result.Age);

        }

        [Fact]
        public void Test_FindById_NotFound()
        {
            //IActionResult actionResult = controller.Get("222");

            //var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(actionResult);

            //Assert.Equal("id person not found", notFoundObjectResult.Value.ToString());
        }
    }
}
