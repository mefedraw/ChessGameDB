﻿using SigmaChess.Contracts.Contracts;
using Microsoft.AspNetCore.Mvc;
using SigmaChess.Core.Abstractions;

namespace SigmaChess.Controllers;

[ApiController]
[Route("api/v1/game-session")]
public class GameSessionController : ControllerBase
{
    private readonly IGameSessionRepository _gameSessionRepository;
    
    public GameSessionController(IGameSessionRepository gameSessionRepository)
    {
        _gameSessionRepository = gameSessionRepository;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreateGame([FromQuery] string inviteLink, [FromQuery] string gameCreatorTgId)
    {
        await _gameSessionRepository.CreateGame(inviteLink, gameCreatorTgId);
        return CreatedAtAction(nameof(CreateGame), new { gameCreatorTgId }, null);
    }
    
    [HttpPost("accept")]
    public async Task<ActionResult> AcceptGame([FromQuery] string inviteLink, [FromQuery] string AcceptedByPlayerTgId)
    {
        await _gameSessionRepository.AcceptGame(inviteLink, AcceptedByPlayerTgId);
        return CreatedAtAction(nameof(AcceptGame), new { AcceptedByPlayerTgId }, null);
    }
}