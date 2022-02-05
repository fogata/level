using FluentAssertions;
using Level.Application.Dto.Repository;
using Level.Application.Interfaces.Queries;
using Level.Test.Mediators;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Level.Application.Mediators.Cart.GetAll.Tests
{
    [TestClass()]
    public class GetAllHandlerTests : BaseTest
    {
        private readonly Mock<ICartQuery> cartQueryMock;
        private readonly Mock<IDiscountQuery> discountQueryMock;
        private readonly Mock<IDeliveryQuery> deliveryQueryMock;
        private readonly Mock<ILogger<ICollection<GetAllResponse>>> loggerMock;
        public GetAllHandlerTests()
        {
            cartQueryMock = new Mock<ICartQuery>();
            discountQueryMock = new Mock<IDiscountQuery>();
            deliveryQueryMock = new Mock<IDeliveryQuery>();
            loggerMock = new Mock<ILogger<ICollection<GetAllResponse>>>();
        }

        [Fact]
        public async Task Should_be_invalid_and_return_a_invalid_response()
        {
            //Arrange
            var handler = new GetAllHandler(loggerMock.Object, cartQueryMock.Object
                , deliveryQueryMock.Object, discountQueryMock.Object);
            var request = new GetAllRequest(Guid.Empty);


            //Act
            var result = await handler.Handle(request, CancellationToken.None);


            //Assert
            result.Invalid.Should().BeTrue();
            cartQueryMock.Verify(x => x.GetAllAsync(It.IsAny<Guid>()));
        }

        [Fact]
        public async Task GetAll_should_be_valid_when_a_valid_request_is_submitted()
        {

            var expected = new List<CartSum>();
            var userId = Guid.NewGuid();

            cartQueryMock
                .Setup(x => x.GetAllAsync(userId))
                    .ReturnsAsync(expected);

            var handler = new GetAllHandler(loggerMock.Object, cartQueryMock.Object
                , deliveryQueryMock.Object, discountQueryMock.Object);
            var command = new GetAllRequest(userId);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Entity.Count().Should().BeGreaterOrEqualTo(expected.Count);

        }
    }
}