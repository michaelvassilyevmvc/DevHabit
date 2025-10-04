namespace DevHabit.Api.DTOs.Tags;

public sealed class TagDto
{
    public required string Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
}
