namespace DevHabit.Api.DTOs.Tags;

public record UpdateTagDto
{
    public required string Name { get; set; } 
    public string? Description { get; set; }
}
