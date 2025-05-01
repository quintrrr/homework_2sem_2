using homework_2sem_2.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace homework_2sem_2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            const string connectionString = "Host=193.176.190.148;Port=5432;Database=lottery;Username=homework;Password=qwerty";
            var options = new DbContextOptionsBuilder<AppDbContext>().UseNpgsql(connectionString).Options;
            using var db = new AppDbContext(options);
            Application.Run(new MainForm());
        }
    }
}