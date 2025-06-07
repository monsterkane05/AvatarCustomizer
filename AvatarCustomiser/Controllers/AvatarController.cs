using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace AvatarCustomiser.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AvatarController(ContentResolver contentResolver) : Controller
{
    private readonly ContentResolver _contentResolver = contentResolver;


    [EndpointDescription("Gets the avatar for the designated user account")]
    [ProducesResponseType(200)]
    [HttpGet]
    public IActionResult Get(int background = 0, int body = 0, int lower = 0, int upper = 0)
    {
        using var backgroundImg = Image.Load(_contentResolver.GetBackground(background));
        using var bodyImg = Image.Load(_contentResolver.GetBody(body));
        using var lowerImg = Image.Load(_contentResolver.GetLower(lower));
        using var upperImg = Image.Load(_contentResolver.GetUpper(upper));

        backgroundImg.Mutate(ctx => ctx.DrawImage(bodyImg, new Point(0, 0), 1.0f));
        backgroundImg.Mutate(ctx => ctx.DrawImage(lowerImg, new Point(0, 0), 1.0f));
        backgroundImg.Mutate(ctx => ctx.DrawImage(upperImg, new Point(0, 0), 1.0f));
        
        //Convert to stream so that the API can return it
        var stream = new MemoryStream();
        backgroundImg.Save(stream, new PngEncoder());
        stream.Position = 0;

        return File(stream, "image/png");
    }
}