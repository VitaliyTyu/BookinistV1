using Microsoft.Extensions.Hosting;
using System;

namespace BookinistV1
{
    class Program
    {
        //для dependency IoC DI исползуется бпблиотека майкрософт(DI), но она уже есть в установленном пакете
        //новая точка входа проекта, это надо указать в свойствах - Application - startup object
        //CreateHostBuilder описываем в Program, т.к. EF ищет иго именно здесь (на самом деле это не так, от класса програм можно избавиться и описать CreateHostBuilder в App)
        [STAThread]
        static void Main(string[] args)
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(App.ConfigureServices); //Передаем процесс создания хоста в класс App
    }
}
