namespace DevHabit.Api.DTOs.Habits;

public interface ICollectionResponse<T>
{
    List<T> Items { get; init; }
}
