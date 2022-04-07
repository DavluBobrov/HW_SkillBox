using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Block_10_1
{
    class TelegramClient
    {
        private MainWindow w;

        TelegramBotClient client;

        public ObservableCollection<MessageLog> MsLogCollect { get; set; }

        protected CancellationTokenSource cts = new CancellationTokenSource();

        ReceiverOptions receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { } // receive all update types
        };
        //private ChatId chatID;

        public TelegramClient(MainWindow W)
        {
            this.w = W;
            MsLogCollect = new ObservableCollection<MessageLog>();
            client = new TelegramBotClient("5232639348:AAE8zMwAtLSiE0EfD2alL7R4oM4oeEUcmKE");
            client.StartReceiving(OnMassageHandler,
                                  ErrorHandler,
                                  receiverOptions,
                                  cts.Token);
            //Debug.ReadLine();
        }

        public async Task OnMassageHandler(ITelegramBotClient bot, Update update, CancellationToken cts)
        {
            if (update.Message != null)
            {
                var chatID = update.Message.Chat.Id;
                var Name = update.Message.Chat.Username;
                string textlog = string.Empty;              // Лог во вью
                #region Создание папки для пользователя и получение списка файлов
                System.IO.DirectoryInfo dir = new DirectoryInfo($@"download\{Name}");
                if (!dir.Exists)
                    dir.Create();
                var files = dir.GetFiles();
                #endregion
                // Мониторинг работы бота в консоли
                Debug.WriteLine($"Chat ID = {chatID}, {Name} write: {update.Message.Text}  Type: {update.Message.Type}");
                // Поиск файлов в папке по названию и отправка
                if (System.IO.File.Exists(@$"{dir.FullName}\" + update.Message.Text))
                {
                    using (FileStream stream = System.IO.File.OpenRead(@$"{dir.FullName}\" +
                        update.Message.Text))
                    {
                        InputOnlineFile inputOnlineFile = new InputOnlineFile(stream, @$"{dir.FullName}\" +
                        update.Message.Text);
                        await client.SendDocumentAsync(chatID,
                                                       inputOnlineFile,
                                                       replyToMessageId: update.Message.MessageId);
                    }
                }
                // Обработка типов сообщений
                switch (update.Message.Type)
                {
                    // обработка команд
                    case MessageType.Text:
                        switch (update.Message.Text)
                        {
                            case "/start":
                                await client.SendTextMessageAsync(chatID,
                                                                  text: System.IO.File.ReadAllText(@"..\..\..\_start.txt"),
                                                                  cancellationToken: cts);
                                textlog = update.Message.Text;
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
                                                                  cancellationToken: cts);
                                textlog = update.Message.Text;
                                break;
                            default: textlog = update.Message.Text; break;
                        }
                        break;
                    case MessageType.Document:
                        DownLoad(update.Message.Document.FileId, @$"{dir.FullName}\" + update.Message.Document.FileName,
                            update.Message.Document.FileSize, update, cts);
                        textlog = "Send file: " + update.Message.Document.FileName;
                        break;
                    case MessageType.Photo:
                        var test = client.GetFileAsync(update.Message.Photo[update.Message.Photo.Length - 1].FileId);
                        string[] imagepath = test.Result.FilePath.Split('/');
                        string newImagePath = imagepath[imagepath.Length - 1];
                        // Вывод имени файла в консоль
                        string message = $"Тип файла: '{update.Message.Type}' сохранен! Название файла: {newImagePath}.";
                        Debug.WriteLine(message);
                        await client.SendTextMessageAsync(chatID,
                                                          text: message,
                                                          replyToMessageId: update.Message.MessageId,
                                                          cancellationToken: cts);
                        DownLoad(update.Message.Photo[update.Message.Photo.Length - 1].FileId, @$"{dir.FullName}\" + newImagePath,
                            update.Message.Photo[update.Message.Photo.Length - 1].FileSize, update, cts);
                        textlog = "Send file: " + newImagePath;
                        break;
                    case MessageType.Video:
                        string name = string.IsNullOrEmpty(update.Message.Video.FileName) ? "video" : update.Message.Video.FileName;
                        DownLoad(update.Message.Video.FileId, @$"{dir.FullName}\" + name,
                            update.Message.Video.FileSize, update, cts);
                        textlog = "Send file: " + update.Message.Video.FileName;
                        break;
                    case MessageType.Audio:
                        DownLoad(update.Message.Audio.FileId, @$"{dir.FullName}\" + update.Message.Audio.FileName,
                            update.Message.Audio.FileSize, update, cts);
                        textlog = "Send file: " + update.Message.Audio.FileName;
                        break;
                    case MessageType.Voice:
                        DownLoad(update.Message.Voice.FileId, @$"{dir.FullName}\" + $"Voice_{DateTime.Now.ToString().Replace(':', '_')}",
                            update.Message.Voice.FileSize, update, cts);
                        textlog = "Send file: " + update.Message.Voice.FileId;
                        break;
                    default:
                        break;
                }
                string text = $"{DateTime.Now.ToLongTimeString()}: {update.Message.Chat.FirstName} {update.Message.Chat.Id} {update.Message.Text}";

                Debug.WriteLine($"{text} TypeMessage: {update.Message.Type.ToString()}");
                
                w.Dispatcher.Invoke(() =>
               {
                   MsLogCollect.Add(
                   new MessageLog(textlog, update, cts));
               });
            }
        }

        /// <summary>
        /// Загрузка файлов отправленные в чат
        /// </summary>
        /// <param name="fileId">ID файла</param>
        /// <param name="path">Полныое имя сохраняемого файла</param>
        /// <param name="fileSize">размер файла</param>
        /// <param name="update"></param>
        /// <param name="cts">Токен отмены</param>
        async void DownLoad(string fileId, string path, int? fileSize, Update update, CancellationToken cts)
        {
            if (fileSize <= 20 * 1000000)                               // Проверка, что файл меньше 20МБ
            {
                var file = await client.GetFileAsync(fileId);
                path = IfSameFileName(path);

                using (FileStream fs = new(path, FileMode.Create))
                {
                    await client.DownloadFileAsync(file.FilePath, fs);
                }
                Thread.Sleep(100);
            }
            else
            {
                await client.SendTextMessageAsync(update.Message.Chat.Id,
                                                          text: "Максимальный размер файла не должен превышать 20МБ",
                                                          replyToMessageId: update.Message.MessageId,
                                                          cancellationToken: cts);
            }
        }

        /// <summary>
        /// Проверка наличия файла по пути, при существовании возвращает новый путь с новым именем FileName(i)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string IfSameFileName(string path)
        {
            if (System.IO.File.Exists(path))
            {
                string name = Path.GetFileNameWithoutExtension(path) + "(1)";
                uint i = 0;
                while (true)
                {
                    i++;
                    var newname = $"{name[0..^3]}({i}){Path.GetExtension(path)}";
                    if (System.IO.File.Exists($"{Path.GetDirectoryName(path)}\\{name[0..^3]}({i}){Path.GetExtension(path)}"))
                    {
                        continue;
                    }
                    else
                    {
                        name = name.Substring(0, name.Length - 3) + $"({i})";
                        return $"{Path.GetDirectoryName(path)}\\{name}{Path.GetExtension(path)}";
                    }
                }
            }
            else
            {
                //Такого файла не существует в конечной папке, можно копировать
                return path; //Переместить файл
            }
        }

        private Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Отправка сообщение пользователю
        /// </summary>
        /// <param name="chatID">ID чата</param>
        /// <param name="res">Отправляемый текст пользователю</param>
        /// <param name="cts">Токен отмены</param>
        /// <param name="MessageId">ID сообщения, на которое отвечает </param>
        /// <param name="IsReplyMess">Флаг опдтверждения ответа на сообщение</param>
        public void SendMessege(ChatId chatID, string res, CancellationToken cts, int MessageId, bool IsReplyMess = true)
        {
            client.SendTextMessageAsync(chatID,
                                  text: res,
                                  replyToMessageId: (IsReplyMess) ? MessageId : null,
                                  cancellationToken: cts
                                  );
        }

    }
}
