namespace CommanderWebApi.Dtos;

public class CommandCreateDto
{
    [Required]
    [MaxLength(250)]
    public string HowTo { get; init; }

    [Required]
    public string Line { get; init; }

    public string Platform { get; init; }
}