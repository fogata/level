using FluentAssertions;
using Level.Application.Dto.Repository;
using Level.Application.Interfaces.Queries;
using Level.Application.Mediators.Delivery.GetAll;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Level.Xunit.Test.Mediators.Delivery.GetAll
{
    public class GetAllHandlerTests : BaseTest
    {
        private readonly Mock<IDeliveryQuery> deliveryQueryMock;
        private readonly Mock<ILogger<ICollection<GetAllResponse>>> loggerMock;
        public GetAllHandlerTests()
        {

            deliveryQueryMock = new Mock<IDeliveryQuery>();
            loggerMock = new Mock<ILogger<ICollection<GetAllResponse>>>();
        }

        [Fact]
        public async Task GetAll_should_be_valid_when_a_valid_request_is_submitted()
        {

            var expected = new List<Domain.Entities.Delivery>();
            var userId = Guid.NewGuid();

            deliveryQueryMock
                .Setup(x => x.GetAllAsync())
                    .ReturnsAsync(expected);

            var handler = new GetAllHandler(loggerMock.Object, deliveryQueryMock.Object);
            var command = new GetAllRequest();

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Entity.Count().Should().BeGreaterOrEqualTo(expected.Count);

        }
    }
}
