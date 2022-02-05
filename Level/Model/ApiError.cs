using Level.Application.Extension;
using Level.Application.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Level.Model
{
    public class ApiError
    {
        /// <summary>
        /// High level textual error code, to help categorize the errors.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// A unique reference for the error instance, for audit purposes, in case of unknown/unclassified errors.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Brief Error message, e.g., 'There is something wrong with the request parameters provided'
        /// </summary>
        public string Message { get; set; }
        public ICollection<ErrorData> Errors { get; set; }

        public ApiError(string code, string id, string message, ICollection<Notification> errors)
        {
            Code = code;
            Id = id;
            Message = message;
            Errors = errors.Select(x => (ErrorData)x).ToList();
        }

        public ApiError(ICollection<Notification> errors, ErrorCode? error = null)
        {
            Code = error.ToString();
            Errors = errors.Select(x => (ErrorData)x).ToList();
        }

        public static ApiError FromResult(Result result)
        {
            var code = string.Concat(result.Action, '_', result.Error).ToUpper().Replace('_', '-');
            var id = string.Concat((int)result.Action, (int)result.Error);
            var message = string.Format((result.Error ?? ErrorCode.BadRequest).GetEnumDescription(), result.Action.GetEnumDescription().ToLower(), "Controller");
            var notifications = result.Notifications.ToList();
            return new ApiError(code, id, message, notifications);
        }
    }
}
