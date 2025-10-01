namespace DevHabit.Api.DTOs.HabitTags;

public record UpsertHabitTagsDto
{
    public required List<string> TagIds { get; init; }
}
