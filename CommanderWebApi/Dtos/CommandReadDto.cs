namespace CommanderWebApi.Dtos;

public record CommandReadDto(int Id, string HowTo, string Line, string Platform)
{
    public int Id { get; init; } = Id;
    public string HowTo { get; init; } = HowTo;
    public string Line { get; init; } = Line;
    public string Platform { get; init; } = Platform;
}