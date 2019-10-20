using AmdOnlyRts.Domain.Classes.Networking;
using Microsoft.AspNetCore.Mvc;
using System;
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

    [HttpGet()]
    public IActionResult GetLobby(Guid? gameId = null)
    {
      if (!gameId.HasValue)
      {
        return Ok(_gameStateContainer.GameStates
          .Select(gs => gs.Value.Lobby));
      }

      return Ok(_gameStateContainer.GameStates[gameId.Value].Lobby);
    }
  }
}