using Microsoft.AspNetCore.Mvc;

namespace desafio_cda.api.Controllers;

[ApiController]
[Consumes(contentType: "application/json")]
[Produces(contentType: "application/json")]
[Route("/api")]
public class BaseController : ControllerBase
{
}
