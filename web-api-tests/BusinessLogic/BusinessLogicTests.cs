using Contracts;
using HealthService;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace web_api_tests.BusinessLogicForAppointments
{
    public class BusinessLogicTests
    {
        private readonly Mock<IRepositoryWrapper> _mockRepo;
        private readonly BusinessLogic _class;

        public BusinessLogicTests()
        {
            _mockRepo = new Mock<IRepositoryWrapper>();
            _class = new BusinessLogic(_mockRepo.Object);
        }

        [Fact]
        public void Validate_CancelAppointment_ReturnsBool()
        {
            //Act
            var result = _class.CanCancel(DateTime.Now);

            //Assert
            Assert.IsType<bool>(result);
        }
    }
}
