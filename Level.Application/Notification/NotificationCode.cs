using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level.Application.Notification
{
    public enum NotificationCode
    {
        [Description("Field.Expected")]
        FieldExpected = 1010,
        [Description("Field.Invalid")]
        FieldInvalid = 1020,
        [Description("Field.InvalidFormat")]
        FieldInvalidFormat = 1030,
        [Description("Field.Missing")]
        FieldMissing = 1040,
        [Description("Field.NotFound")]
        FieldNotFound = 1050,
        [Description("Header.Expected")]
        HeaderExpected = 2010,
        [Description("Header.Invalid")]
        HeaderInvalid = 2020,
        [Description("Header.InvalidFormat")]
        HeaderInvalidFormat = 2030,
        [Description("Header.Missing")]
        HeaderMissing = 2040,
        [Description("Header.NotFound")]
        HeaderNotFound = 2050,
        [Description("Header.Unexpected")]
        HeaderUnexpected = 2070,
        [Description("CPQD.TransactionHeld")]
        TransactionHeld = 3010,
        [Description("CPQD.TransactionDenied")]
        TransactionDenied = 3020,
        [Description("UnexpectedError.Unexpected")]
        UnexpectedErrorUnexpected = 4070,
        [Description("Unsupported.Scheme")]
        UnsupportedScheme = 4090,
        [Description("Resource.Expected")]
        ResourceExpected = 5010,
        [Description("Resource.Invalid")]
        ResourceInvalid = 5020,
        [Description("Resource.InvalidFormat")]
        ResourceInvalidFormat = 5030,
        [Description("Resource.Missing")]
        ResourceMissing = 5040,
        [Description("Resource.NotFound")]
        ResourceNotFound = 5050,
        [Description("Resource.Unexpected")]
        ResourceUnexpected = 5070
    }
}
