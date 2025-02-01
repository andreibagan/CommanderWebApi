using CommanderWebApi.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CommanderWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommandsController : ControllerBase
{
    private readonly ICommanderRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommanderRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
    {
        var commandItems = _repository.GetAllCommands();

        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
    }

    [HttpGet("{id}", Name = "GetCommandById")]
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
        var commandItem = _repository.GetCommandById(id);

        if (commandItem == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CommandReadDto>(commandItem));
    }

    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
    {
        var command = _mapper.Map<Command>(commandCreateDto);
        _repository.CreateCommand(command);
        _repository.SaveChanges();

        var commandReadDto = _mapper.Map<CommandReadDto>(command);

        return CreatedAtRoute(nameof(GetCommandById), new { id = commandReadDto.Id }, commandReadDto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
    {
        var command = _repository.GetCommandById(id);
        if (command == null)
        {
            return NotFound();
        }

        _mapper.Map(commandUpdateDto, command);

        _repository.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
    {
        var command = _repository.GetCommandById(id);
        if (command == null)
        {
            return NotFound();
        }

        var commandToPatch = _mapper.Map<CommandUpdateDto>(command);
        patchDoc.ApplyTo(commandToPatch, ModelState);

        if (!TryValidateModel(commandToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(commandToPatch, command);

        _repository.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCommand(int id)
    {
        var command = _repository.GetCommandById(id);
        if (command == null)
        {
            return NotFound();
        }

        _repository.DeleteCommand(command);
        _repository.SaveChanges();

        return NoContent();
    }
}