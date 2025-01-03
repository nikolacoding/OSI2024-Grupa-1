namespace User {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // program je prvobitno zavisio od LoginForm, medjutim nisam pronasao nacin da
            // zatvorim glavni LoginForm kada zatvaram MainForm pa bi program ostao raditi
            // u pozadini
            Application.Run(new MainForm());
        }
    }
}