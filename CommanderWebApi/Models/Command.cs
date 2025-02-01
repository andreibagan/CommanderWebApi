namespace CommanderWebApi.Models;

public class Command
{
    [Key]
    public int Id { get; init; }

    [Required]
    [MaxLength(250)]
    public string HowTo { get; init; }

    [Required]
    public required string Line { get; init; }

    public required string Platform { get; init; }

    public static bool IsWindowsPlatform(Command command)
    {
        return command switch
        {
            {
                Platform: "Windows"
            } => true,
            _ => false
        };
    }
}