using Microsoft.Extensions.Configuration;
using Netclip.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace NetCLip.TelegramBot.TelegramCommands
{
    public class TelegramBotSend
    {
        private readonly ITelegramBotClient _botClient;

        public TelegramBotSend(IConfiguration config)
        {
            _botClient = new TelegramBotClient(config["TelegramBotAPIKey"]);
        }

        public async ValueTask SendMessageToTelegramBot(Order order)
        {
            var text = $"ID: {order.Id}\nName: {order.Name}\nPhone Number: {order.Phone}\nCcilka: {order.ccilka}\nEmail: {order.Email}\nTask: {order.Task}";

            await _botClient.SendTextMessageAsync(
                chatId: 677944112,
                text: text);
        }

    }
}
