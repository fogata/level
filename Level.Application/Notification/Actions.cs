using System.ComponentModel;

namespace Level.Application.Notification
{
    public enum Actions
    {
        [Description("create")]
        INSERT = 10,
        [Description("get")]
        GET = 20,
        [Description("list")]
        GETALL = 21,
        [Description("update")]
        UPDATE = 30,
        [Description("delete")]
        DELETE = 40,
    }
}
