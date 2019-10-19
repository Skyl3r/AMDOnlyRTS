using AmdOnlyRts.Domain.Classes.Networking;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AmdOnlyRts.Networking.Server.Controllers
{
  [Route("api/lobby")]
  public class LobbyController : ControllerBase
  {
    private readonly GameStateContainer _gameStateContainer;
    public LobbyController(GameStateContainer gameStateContainer)
    {
        _gameStateContainer = gameStateContainer;
    }

    [HttpGet("GetLobbyListing")]
    public IActionResult GetLobbyListing()
    {
      return Ok(_gameStateContainer.GameStates
        .Select(gs => gs.Value.Lobby));
    }
  }
}