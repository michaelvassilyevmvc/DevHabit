namespace DevHabit.Api.DTOs.Habits.Common;

public interface ICollectionResponse<T>
{
    List<T> Items { get; init; }
}
