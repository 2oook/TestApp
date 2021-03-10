using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using TestApp.ChequeService;
using System.Text.RegularExpressions;
using System.ServiceModel;

namespace TestApp
{
    /// <summary>
    /// Класс сервиса
    /// </summary>
    public partial class Service : ServiceBase
    {
        /// <summary>
        /// Объект логгера
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Путь к папке для получения чеков
        /// </summary>
        string folderPath;
        /// <summary>
        /// Путь к папке для мусора
        /// </summary>
        string garbagePath;
        /// <summary>
        /// Путь к папке для переданных чеков
        /// </summary>
        string completePath;

        /// <summary>
        /// Регулярное выражение для определения файлов с расширением txt
        /// </summary>
        Regex regexTxt = new Regex(".+\\.txt");

        /// <summary>
        /// Объект доступа к веб-сервису
        /// </summary>
        ChequeServiceClient webService;

        public Service()
        {
            InitializeComponent();

            folderPath = ConfigurationManager.AppSettings["FolderPath"];
            garbagePath = ConfigurationManager.AppSettings["GarbagePath"];
            completePath = ConfigurationManager.AppSettings["CompletePath"];

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!Directory.Exists(garbagePath))
            {
                Directory.CreateDirectory(garbagePath);
            }

            if (!Directory.Exists(completePath))
            {
                Directory.CreateDirectory(completePath);
            }

            webService = new ChequeServiceClient();
        }

        /// <summary>
        /// Метод вызываемый при запуске сервиса
        /// </summary>
        /// <param name="args">Аргументы</param>
        protected override void OnStart(string[] args)
        {
            // создать объект для наблюдения за файловой системой
            var fsw = new FileSystemWatcher(folderPath);
            fsw.Created += Fsw_Created;
            fsw.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Обработчик события появления файла в заданной директории
        /// </summary>
        /// <param name="sender">Объект отправитель</param>
        /// <param name="e">Объект параметров события</param>
        private void Fsw_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                // если название файла не имеет расширения .txt
                if (!regexTxt.IsMatch(e.FullPath))
                {
                    log.Error($"Файл \"{e.Name}\" имеет неверное расширение");
                    File.Move(e.FullPath, garbagePath + e.Name);
                    return;
                }

                // прочитать json из добавленного файла
                var chequeJson = File.ReadAllText(e.FullPath);
                // получить объект чека
                var deserializedCheque = JsonConvert.DeserializeObject<Cheque>(chequeJson);

                // отправить чек веб-сервису
                webService.PassCheque(deserializedCheque);

                // переместить файл в папку complete
                File.Move(e.FullPath, completePath + e.Name);
            }
            catch (JsonSerializationException JsonSerExc)
            {
                log.Error($"Файл \"{e.Name}\" не удалось десериализовать" + Environment.NewLine + JsonSerExc.Message);
                File.Move(e.FullPath, garbagePath + e.Name);
            }
            catch (CommunicationException communicationExc) 
            {
                log.Error($"Возникла проблема соединения с веб-сервисом" + Environment.NewLine + communicationExc.Message);
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка работы с файлом \"{e.Name}\"" + Environment.NewLine + ex.Message);
            }
        }

        #if DEBUG
        public void onDebug()
        {
            OnStart(null);
        }
        #endif
    }
}
