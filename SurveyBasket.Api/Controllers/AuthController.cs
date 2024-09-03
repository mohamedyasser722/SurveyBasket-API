﻿using Azure.Core;
using SurveyBasket.Api.Services.Services.Interfaces;

namespace SurveyBasket.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService, ILogger<AuthController> logger) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        private readonly ILogger<AuthController> _logger = logger;

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Login request received for {Email} and password: {password}", request.Email, request.Password);

            var response = await _authService.GetTokenAsync(request.Email, request.Password, cancellationToken);

            if (response.IsFailure)
                return response.ToProblem();

            return Ok(response.Value);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

            if (response.IsFailure)
                return response.ToProblem();

            return Ok(response.Value);
        }

        [HttpPost("revoke-refresh-token")]
        public async Task<IActionResult> RevokeRefreshTokenAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

            if (response.IsFailure)
                return response.ToProblem();

            return NoContent();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _authService.RegisterAsync(request, cancellationToken);

            if (response.IsFailure)
                return response.ToProblem();

            return Ok();
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _authService.ConfirmEmailAsync(request);

            if (response.IsFailure)
                return response.ToProblem();

            return Ok();
        }


        [HttpPost("resend-confirmation-email")]
        public async Task<IActionResult> ResendConfirmationEmail([FromBody] ResendConfirmationEmailRequest request, CancellationToken cancellationToken = default)
        {
            var response = await _authService.ResendConfirmationEmailAsync(request);
            if (response.IsFailure)
                return response.ToProblem();

            return Ok();
        }
    }
}
