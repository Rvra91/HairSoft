using System;
using Telegram.Bot;
using Telegram.Bot.Args;

class Program
{
    private static readonly string Token = "7297737852:AAFKqr7evFu5l1kf5PX7YmXnKDMc9iEABnk";
    private static TelegramBotClient bot;

    static void Main(string[] args)
    {
        try
        {
            bot = new TelegramBotClient(Token);
            bot.OnMessage += Bot_OnMessage;
            bot.StartReceiving();
            Console.WriteLine("Bot está en línea...");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al conectar: " + ex.Message);
        }

        Console.ReadLine(); // Mantener el programa abierto
    }

    private static void Bot_OnMessage(object sender, MessageEventArgs e)
    {
        if (e.Message?.Text != null)
        {
            Console.WriteLine($"Mensaje recibido: {e.Message.Text}");
            bot.SendTextMessageAsync(e.Message.Chat.Id, "Has dicho: " + e.Message.Text);
        }
        else
        {
            Console.WriteLine("Mensaje vacío o sin texto.");
        }
    }
}
