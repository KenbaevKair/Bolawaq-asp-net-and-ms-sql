using System;
using System.Collections.Generic;

namespace Bolawaq.data;

public partial class Booking
{
    public int Id { get; set; }

    public string? Иин { get; set; }

    public string? Цель { get; set; }

    public DateTime? Дата { get; set; }

    public TimeSpan? Время { get; set; }

    public string? Email { get; set; }
}
