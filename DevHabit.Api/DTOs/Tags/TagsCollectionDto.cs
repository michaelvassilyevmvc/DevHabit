using DevHabit.Api.DTOs.Habits;
using DevHabit.Api.DTOs.Habits.Common;

namespace DevHabit.Api.DTOs.Tags;

public sealed record TagsCollectionDto: ICollectionResponse<TagDto>
{
    public List<TagDto> Items { get; init; }
}
