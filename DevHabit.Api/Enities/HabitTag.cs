﻿namespace DevHabit.Api.Enities;

public sealed class HabitTag
{
    public string HabitId { get; set; }
    public string TagId { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}
