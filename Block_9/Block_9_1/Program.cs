using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

class Programm
{
    //private static string token { get; set; } = "5232639348:AAE8zMwAtLSiE0EfD2alL7R4oM4oeEUcmKE";
    static TelegramBotClient client = new TelegramBotClient("5232639348:AAE8zMwAtLSiE0EfD2alL7R4oM4oeEUcmKE");

    static void Main()
    {
        var cts = new CancellationTokenSource();

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { } // receive all update types
        };
        client.StartReceiving(OnMassageHandler,
                              ErrorHandler,
                              receiverOptions,
                              cts.Token);
        Console.ReadLine();
    }

    async static Task OnMassageHandler(ITelegramBotClient client, Update update, CancellationToken cToken)
    {
        if (update.Type == UpdateType.Message)
        {
            var chatID = update.Message.Chat.Id;
            var Name = update.Message.Chat.Username;
            #region Создание папки для пользователя и получение списка файлов
            System.IO.DirectoryInfo dir = new DirectoryInfo($@"download\{Name}");
            if (!dir.Exists)
                dir.Create();
            var files = dir.GetFiles();
            #endregion
            // Мониторинг работы бота в консоли
            Console.WriteLine($"Chat ID = {update.Message.Chat.Id}, {Name} write: {update.Message.Text}  Type: {update.Message.Type}");
            // Поиск файлов в папке по названию и отправка
            if (System.IO.File.Exists(@$"{dir.FullName}\" + update.Message.Text))
            {
                using (FileStream stream = System.IO.File.OpenRead(@$"{dir.FullName}\" +
                    update.Message.Text))
                {
                    InputOnlineFile inputOnlineFile = new InputOnlineFile(stream, @$"{dir.FullName}\" +
                    update.Message.Text);
                    await client.SendDocumentAsync(chatID, inputOnlineFile);
                }
            }
            // Проверка типа присланного сообщения
            switch (update.Message.Type)
            {
                case MessageType.Text:
                    // Свич на команды чата
                    switch (update.Message.Text)
                    {
                        case "/start":
                            await client.SendTextMessageAsync(chatID, text: System.IO.File.ReadAllText(@"..\..\..\_start.txt"),
                                                              cancellationToken: cToken);
                            break;
                        case "/download":
                            string res = string.Empty;
                            foreach (var n in files)
                            {
                                res += n.Name + "\n";
                            }
                            if (res == "") res = "Файлов пока нет!";
                            await client.SendTextMessageAsync(chatID,
                                                              text: res,
                                                              cancellationToken: cToken);
                            break;
                    }
                    break;
                case MessageType.Document:
                    DownLoad(update.Message.Document.FileId, @$"{dir.FullName}\" + update.Message.Document.FileName);
                    break;
                case MessageType.Photo:
                    var test = client.GetFileAsync(update.Message.Photo[update.Message.Photo.Length - 1].FileId);
                    string[] imagepath = test.Result.FilePath.Split('/');
                    string newImagePath = imagepath[imagepath.Length - 1];
                    // Вывод имени файла в консоль
                    string text = $"Тип файла: '{update.Message.Type}' сохранен! Название файла: {newImagePath}.";
                    Console.WriteLine(text);
                    await client.SendTextMessageAsync(chatID,
                                                      text: text,
                                                      replyToMessageId: update.Message.MessageId,
                                                      cancellationToken: cToken);
                    DownLoad(update.Message.Photo[update.Message.Photo.Length - 1].FileId, @$"{dir.FullName}\" + newImagePath);
                    break;
                case MessageType.Video:
                    DownLoad(update.Message.Video.FileId, @$"{dir.FullName}\" + update.Message.Video.FileName);
                    break;
                case MessageType.Audio:
                    DownLoad(update.Message.Document.FileId, @$"{dir.FullName}\" + update.Message.Audio.FileName);
                    break;
                default:
                    break;
            }
        }

        async void DownLoad(string fileId, string path)
        {
            var file = await client.GetFileAsync(fileId);
            using FileStream fs = new FileStream(path, FileMode.Create);
            {
                await client.DownloadFileAsync(file.FilePath, fs);
            }
        }
    }

    async static Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
    {
    }
}