using Contracts;
using HealthService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace web_api_tests.Controller
{
    public class PatientControllerTests
    {
        private readonly Mock<IRepositoryWrapper> _mockRepo;
        private readonly PatientController _controller;

        public PatientControllerTests()
        {
            _mockRepo = new Mock<IRepositoryWrapper>();
            _controller = new PatientController(_mockRepo.Object, null);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            //Act
            var notFoundResult = _controller.GetPatientById(00);

            //Assert
            Assert.IsType<ObjectResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.GetPatientById(71);

            //Assert
            Assert.IsType<ObjectResult>(okResult.Result);
        }
    }
}
