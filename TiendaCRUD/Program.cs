
namespace TiendaCRUD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuración inicial de Windows Forms
            ApplicationConfiguration.Initialize();

            // Indicar dónde buscar la base de datos
            AppDomain.CurrentDomain.SetData(
                "DataDirectory",
                AppDomain.CurrentDomain.BaseDirectory);

            // Iniciar el formulario
            Application.Run(new Form1());
        }
    }
}
