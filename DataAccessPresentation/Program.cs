using System;
using System.Windows.Forms;
using Common;
using StructureMap;

namespace DataAccessPresentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ObjectFactory.Initialize(t => t.Scan(x =>
            {
                x.WithDefaultConventions();
                x.AssembliesFromApplicationBaseDirectory();
                x.AddAllTypesOf<IName>().NameBy(n=> n.FullName);
            }));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
