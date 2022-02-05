using FluentAssertions;
using Level.Application.Interfaces.Queries;
using Level.Application.Mediators.Article.GetAll;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Level.Xunit.Test.Mediators.Article
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
