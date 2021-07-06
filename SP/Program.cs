using SP.AsstLabs;
using SP.Final;
using SP.Final.Q8;
using System;
using System.Windows.Forms;

namespace SP
{
    class Program
    {
        /// <summary>
        /// Main method for console based solutions
        /// </summary>
        static void Main(string[] args)
        {
            Q9.main(args);
            Console.ReadKey();
        }

        /// <summary>
        /// Main method for form based solutions
        /// </summary>
        // [STAThread]
        // static void Main()
        // {
        //     Application.EnableVisualStyles();
        //     Application.SetCompatibleTextRenderingDefault(false);
        //     Application.Run(new Final.Q7.Server());
        // }
    }
}
