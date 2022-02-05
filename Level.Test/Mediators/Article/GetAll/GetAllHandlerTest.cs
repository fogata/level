using Level.Application.Interfaces.Queries;
using Level.Application.Mediators.Article.GetAll;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Level.Test.Mediators.Article.GetAll
{
    public class GetAllHandlerTest : BaseTest
    {
        private readonly Mock<IArticleQuery> articleQueryMock;
        private readonly Mock<ILogger<ICollection<GetAllResponse>>> loggerMock;
        public GetAllHandlerTest()
        {
            articleQueryMock = new Mock<IArticleQuery>();
            loggerMock = new Mock<ILogger<ICollection<GetAllResponse>>>();
        }

        [Fact]
        public async Task Should_be_invalid_and_return_a_invalid_response()
        {
            //Arrange
            var handler = new GetAllHandler(loggerMock.Object, articleQueryMock.Object);
            var request = new GetAllRequest();

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.Invalid.Should().BeTrue();
            articleQueryMock.Verify(x => x.GetAllAsync());
        }

        [Fact]
        public async Task GetAll_should_be_valid_when_a_valid_request_is_submitted()
        {

            var expected = new List<Domain.Entities.Articles>();

            articleQueryMock
                .Setup(x => x.GetAllAsync())
                    .ReturnsAsync(expected);

            var handler = new GetAllHandler(loggerMock.Object, articleQueryMock.Object);
            var command = new GetAllRequest();

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Entity.Count().Should().BeGreaterOrEqualTo(expected.Count);
        }
    }
}
