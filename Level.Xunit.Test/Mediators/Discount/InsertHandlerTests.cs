using FluentAssertions;
using Level.Application.Dto.Mediator;
using Level.Application.Mediators.Discount.Insert;
using Level.Application.Notification;
using Level.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Level.Xunit.Test.Mediators.Discount
{
    public class InsertHandlerTests
    {
        private readonly Mock<IDiscountRepository> discountRepositoryMock;
        private readonly Mock<IUnitOfWork> unitOfWork;
        private readonly Actions _action = Actions.INSERT;
        private readonly Mock<ILogger<ICollection<InsertResponse>>> loggerMock;

        public InsertHandlerTests()
        {
            unitOfWork = new Mock<IUnitOfWork>();
            discountRepositoryMock = new Mock<IDiscountRepository>();
            loggerMock = new Mock<ILogger<ICollection<InsertResponse>>>();
        }

        InsertHandler GetHandler()
        {
            return new InsertHandler(unitOfWork.Object, discountRepositoryMock.Object, loggerMock.Object);
        }

        [Fact]
        public async Task Should_return_a_invalid_response()
        {
            var handler = GetHandler();
            var lstPost = new List<DiscountPost>();
            var post = new DiscountPost
            {
                articleId = 1,
                total = 0,
                type = "",
                userId = System.Guid.Empty
            };
            lstPost.Add(post);

            var discountExpetected = new Domain.Entities.Discount
            {
                articleId = 1,
                total = 10,
                type = "amount",
                userId = System.Guid.NewGuid()
            };

            var request = new InsertRequest(lstPost);
            var result = new EntityResult<InsertResponse>(_action, request.Notifications);

            discountRepositoryMock
                .Setup(x => x.InsertAsync(It.IsAny<Domain.Entities.Discount>()))
                .Returns(Task.FromResult(discountExpetected));

            //Act
            result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.Valid.Should().BeFalse();
            result.Notifications.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task Should_return_a_valid_response()
        {
            var handler = GetHandler();
            var lstPost = new List<DiscountPost>();
            var post = new DiscountPost
            {
                articleId = 1,
                total = 10,
                type = "amount",
                userId = System.Guid.NewGuid()
            };
            lstPost.Add(post);

            var discountExpetected = new Domain.Entities.Discount
            {
                articleId = 1,
                total = 10,
                type = "amount",
                userId = System.Guid.NewGuid()
            };

            var request = new InsertRequest(lstPost);
            var result = new EntityResult<InsertResponse>(_action, request.Notifications);

            discountRepositoryMock
                .Setup(x => x.InsertAsync(It.IsAny<Domain.Entities.Discount>()))
                .Returns(Task.FromResult(discountExpetected));

            //Act
            result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.Valid.Should().BeTrue();
            result.Notifications.Count.Should().Be(0);
        }
    }
}
