namespace CommanderWebApi.Profiles;

file class CommandsProfile : Profile
{
    public CommandsProfile()
    {
        CreateMap<Command, CommandReadDto>();
        CreateMap<CommandCreateDto, Command>();
        CreateMap<CommandUpdateDto, Command>();
        CreateMap<Command, CommandUpdateDto>();
    }
}