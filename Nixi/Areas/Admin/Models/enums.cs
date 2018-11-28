using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    // AgreedPeriods and AgreedDays
    public enum DayType
    {
        NotComing,
        AM,
        PM,
        FullDay
    }
    // AgreedDays
    public enum AgreedDaysStatus
    {
        FutureDay,
        NoShow,
        Illness,
        ShowUp
    }
    // InvoiceLine
    public enum InvoiceLineType
    {
        DaysAgreed,
        HalfDaysAgreed,
        DaysShowUp,
        HalfdaysShowUp,
        DaysOff,
        HalfDaysOff,
        UnpayedInvoices
    }

    public enum DiaryEntryStatus
    {
        NotArrived,
        Entry,
        Exit,
        Sleeping,
        Awake,
        Eating,
        Diaper,
        VideoMessage,
        Other
    }

    public enum Privacy
    {
        Public,
        All,
        Class,
        Parents
    }

    public enum PaymentStatus
    {
        Open,
        Invoiced,
        Payed
    }

    public enum ClosingDayType
    {
        Holiday,
        PublicHoliday,
        Illness
    }

    public enum Association
    {
        Parent,
        Sibling,
        Pickup
    }

}