using Microsoft.Extensions.Hosting;
using System;

namespace BookinistV1
{
    public class Program
    {
        //новая точка входа проекта, это надо указать в свойствах - Application - startup object
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
