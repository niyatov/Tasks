/*using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace middleware.Controllers;
[ApiController]
[Route("bot")]
public class TelegramController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hi");
    }
    [HttpPost]
    public async Task PostUpdate(Update update)
    {
        var bot = new TelegramBotClient("5629743558:AAFe92oWnAqYWAclvE64RXF6AJjIpb3cuYw");
        if (update.Type != UpdateType.Message)
            return;
        await bot.SendTextMessageAsync(update.Message.Chat.Id,$"{update.Message.Chat.Id}");

    }
}
*/