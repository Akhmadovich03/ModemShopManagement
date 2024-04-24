namespace kurs_ishi_modemlar
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static string path = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=kurs_ishi_modemlar;Integrated Security=True";
        
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Kirish());
        }
    }
}