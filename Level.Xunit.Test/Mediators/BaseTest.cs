using Level.Application.Notification;
using System.Collections.Generic;
using System.Net;

namespace Level.Xunit.Test.Mediators
{
    public class BaseTest
    {
        protected BaseTest()
        {

        }
        public static IEnumerable<object[]> ExceptionsData()
        {
            return new List<object[]>
            {
                new object[] { HttpStatusCode.BadRequest, ErrorCode.BadRequest },
                new object[] { HttpStatusCode.Unauthorized, ErrorCode.Unauthorized },
                new object[] { HttpStatusCode.Forbidden, ErrorCode.Forbidden },
                new object[] { HttpStatusCode.NotFound, ErrorCode.NotFound },
                new object[] { HttpStatusCode.MethodNotAllowed, ErrorCode.MethodNotAllowed },
                new object[] { HttpStatusCode.UnprocessableEntity, ErrorCode.UnprocessableEntity },
                new object[] { HttpStatusCode.InternalServerError, ErrorCode.InternalServerError },
                new object[] { HttpStatusCode.BadGateway, ErrorCode.BadGateway },
                new object[] { HttpStatusCode.ServiceUnavailable, ErrorCode.ServiceUnavailable },
                new object[] { HttpStatusCode.GatewayTimeout, ErrorCode.InternalServerError }

            };

        }
    }
}
