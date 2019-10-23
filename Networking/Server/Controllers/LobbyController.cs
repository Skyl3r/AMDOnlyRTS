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

    [HttpGet("{gameId?}")]
    public IActionResult GetLobby(Guid? gameId = null)
    {
      if (!gameId.HasValue)
      {
        return Ok(_gameStateContainer.GameStates
          .Select(gs => gs.Value.Lobby));
      }

      if (_gameStateContainer.GameStates.ContainsKey(gameId.Value))
      {
        return Ok(_gameStateContainer.GameStates[gameId.Value].Lobby);
      }

      return BadRequest("That game id doesnt exist");
    }
  }
}