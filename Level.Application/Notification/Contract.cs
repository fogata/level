using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Level.Application.Notification
{
    public class Contract : Notifiable
    {
        public Contract IsFalse(bool val, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsTrue(bool val, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            return IsFalse(!val, property, message, code);
        }

        public Contract Requires()
        {
            return this;
        }

        public Contract Join(params Notifiable[] items)
        {
            if (items != null)
            {
                foreach (Notifiable notifiable in items)
                {
                    if (notifiable.Invalid)
                    {
                        AddNotifications(notifiable.Notifications);
                    }
                }
            }

            return this;
        }

        public Contract IfNotNull(object parameterType, Expression<Func<Contract, Contract>> contractExpression)
        {
            if (parameterType != null)
            {
                contractExpression.Compile()(this);
            }

            return this;
        }

        public Contract IsGreaterThan(DateTime val, DateTime comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(DateTime val, DateTime comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(DateTime val, DateTime comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(DateTime val, DateTime comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsBetween(DateTime val, DateTime from, DateTime to, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (!(val >= from) || !(val <= to))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsNullOrNullable(DateTime? val, string property, string message, NotificationCode code = NotificationCode.FieldMissing)
        {
            if (!val.HasValue || !val.HasValue)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(decimal val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(double val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(float val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(long val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val <= (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(int val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((decimal)val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(decimal val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(double val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(float val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(long val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val < (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(int val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((decimal)val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(decimal val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(double val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(float val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(long val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val >= (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(int val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((decimal)val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(decimal val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(double val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(float val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(long val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val > (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(int val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((decimal)val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(decimal val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(double val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(float val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(long val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val != (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(int val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((decimal)val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(decimal val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(double val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(float val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(long val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val == (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(int val, decimal comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((decimal)val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsBetween(decimal val, decimal from, decimal to, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (!(val >= from) || !(val <= to))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsNullOrNullable(decimal? val, string property, string message, NotificationCode code = NotificationCode.FieldMissing)
        {
            if (!val.HasValue || !val.HasValue)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(decimal val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(double val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(float val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(long val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(int val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(decimal val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(double val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(float val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(long val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(int val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(decimal val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(double val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(float val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(long val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(int val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(decimal val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(double val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(float val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(long val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(int val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(decimal val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(double val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(float val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(long val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(int val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(decimal val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(double val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(float val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(long val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(int val, double comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsBetween(double val, double from, double to, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (!(val >= from) || !(val <= to))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsNullOrNullable(double? val, string property, string message, NotificationCode code = NotificationCode.FieldMissing)
        {
            if (!val.HasValue || !val.HasValue)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(decimal val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val <= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(double val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(float val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(long val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(int val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(decimal val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val < (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(double val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(float val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(long val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(int val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(decimal val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val >= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(double val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(float val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(long val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(int val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(decimal val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val > (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(double val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(float val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(long val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(int val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(decimal val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val != (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(double val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(float val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(long val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(int val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(decimal val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val == (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(double val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(float val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(long val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(int val, float comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((float)val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsBetween(float val, float from, float to, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (!(val >= from) || !(val <= to))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsNullOrNullable(float? val, string property, string message, NotificationCode code = NotificationCode.FieldMissing)
        {
            if (!val.HasValue || !val.HasValue)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(Guid val, Guid comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val.ToString() != comparer.ToString())
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(Guid val, Guid comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val.ToString() == comparer.ToString())
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsEmpty(Guid val, string property, string message, NotificationCode code = NotificationCode.FieldMissing)
        {
            if (val != Guid.Empty)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsNotEmpty(Guid val, string property, string message, NotificationCode code = NotificationCode.FieldMissing)
        {
            if (val == Guid.Empty)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(decimal val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val <= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(double val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(float val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(long val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(int val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(decimal val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val < (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(double val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(float val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(long val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(int val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(decimal val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val >= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(double val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(float val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(long val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(int val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(decimal val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val > (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(double val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(float val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(long val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(int val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(decimal val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val != (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(double val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(float val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(long val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(int val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(decimal val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val == (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(double val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(float val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(long val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(int val, int comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsBetween(int val, int from, int to, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < from || val > to)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsNullOrNullable(int? val, string property, string message, NotificationCode code = NotificationCode.FieldMissing)
        {
            if (!val.HasValue || !val.HasValue)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(decimal val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val <= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(double val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(float val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(int val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(long val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(decimal val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val < (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(double val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(float val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(int val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(long val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(decimal val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val >= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(double val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(float val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(int val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(long val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(decimal val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val > (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(double val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(float val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(int val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(long val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(decimal val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val != (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(double val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(float val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(int val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(long val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val != comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(decimal val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if ((double)val == (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(double val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == (double)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(float val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == (float)comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(int val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(long val, long comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val == comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsBetween(long val, long from, long to, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < from || val > to)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsNull(object obj, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (obj != null)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsNotNull(object obj, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (obj == null)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(object obj, object comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (!obj.Equals(comparer))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(object obj, object comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (obj.Equals(comparer))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsNotNullOrEmpty(string val, string property, string message, NotificationCode code = NotificationCode.FieldMissing)
        {
            if (string.IsNullOrEmpty(val))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsNotNullOrWhiteSpace(string val, string property, string message, NotificationCode code = NotificationCode.FieldMissing)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsNullOrEmpty(string val, string property, string message, NotificationCode code = NotificationCode.FieldMissing)
        {
            if (!string.IsNullOrEmpty(val))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract HasMinLen(string val, int min, string property, string message, NotificationCode code = NotificationCode.FieldInvalidFormat)
        {
            if (string.IsNullOrEmpty(val) || val.Length < min)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract HasMaxLen(string val, int max, string property, string message, NotificationCode code = NotificationCode.FieldInvalidFormat)
        {
            if (string.IsNullOrEmpty(val) || val.Length > max)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract HasLen(string val, int len, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (string.IsNullOrEmpty(val) || val.Length != len)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract Contains(string val, string text, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (!val.Contains(text))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreEquals(string val, string text, string property, string message, NotificationCode code = NotificationCode.FieldInvalid, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            if (!val.Equals(text, comparisonType))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract AreNotEquals(string val, string text, string property, string message, NotificationCode code = NotificationCode.FieldInvalid, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            if (val.Equals(text, comparisonType))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsEmail(string email, string property, string message, NotificationCode code = NotificationCode.FieldInvalidFormat)
        {
            return Matchs(email, "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$", property, message, code);
        }

        public Contract IsEmailOrEmpty(string email, string property, string message, NotificationCode code = NotificationCode.FieldMissing)
        {
            if (string.IsNullOrEmpty(email))
            {
                return this;
            }

            return IsEmail(email, property, message, code);
        }

        public Contract IsUrl(string url, string property, string message, NotificationCode code = NotificationCode.FieldInvalidFormat)
        {
            return Matchs(url, "^(http:\\/\\/www\\.|https:\\/\\/www\\.|http:\\/\\/|https:\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$", property, message, code);
        }

        public Contract IsUrlOrEmpty(string url, string property, string message, NotificationCode code = NotificationCode.FieldMissing)
        {
            if (string.IsNullOrEmpty(url))
            {
                return this;
            }

            return IsUrl(url, property, message, code);
        }

        public Contract Matchs(string text, string pattern, string property, string message, NotificationCode code = NotificationCode.FieldInvalidFormat)
        {
            if (!Regex.IsMatch(text ?? "", pattern))
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsDigit(string text, string property, string message, NotificationCode code = NotificationCode.FieldInvalidFormat)
        {
            return Matchs(text, "^\\d+$", property, message, code);
        }

        public Contract HasMinLengthIfNotNullOrEmpty(string text, int min, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (!string.IsNullOrEmpty(text) && text.Length < min)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract HasMaxLengthIfNotNullOrEmpty(string text, int max, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (!string.IsNullOrEmpty(text) && text.Length > max)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract HasExactLengthIfNotNullOrEmpty(string text, int len, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (!string.IsNullOrEmpty(text) && text.Length != len)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterThan(TimeSpan val, TimeSpan comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val <= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsGreaterOrEqualsThan(TimeSpan val, TimeSpan comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val < comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerThan(TimeSpan val, TimeSpan comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val >= comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsLowerOrEqualsThan(TimeSpan val, TimeSpan comparer, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (val > comparer)
            {
                AddNotification(property, message, code);
            }

            return this;
        }

        public Contract IsBetween(TimeSpan val, TimeSpan from, TimeSpan to, string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            if (!(val >= from) || !(val <= to))
            {
                AddNotification(property, message, code);
            }

            return this;
        }
    }
}
