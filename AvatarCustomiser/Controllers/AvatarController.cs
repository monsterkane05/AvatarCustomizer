using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace AvatarCustomiser.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AvatarController : Controller
{
    [EndpointDescription("Gets the avatar for the designated user account")]
    [ProducesResponseType(200)]
    [HttpGet]
    public IActionResult Get()
    {
        using var background = Image.Load(@"");
        using var body = Image.Load(@"");
        
        background.Mutate(ctx => ctx.DrawImage(body, new Point(0,0), 1.0f));
        
        //Convert to stream so that the API can return it
        var stream = new MemoryStream();
        background.Save(stream, new PngEncoder());
        stream.Position = 0;
        
        return File(stream, "image/png");
    }
}