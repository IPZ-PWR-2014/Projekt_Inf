/*! 
 *  \brief     Program do obsługi Robota Mimicznego. PWr Mechtronika 2 sem. MGR pod kierunkiem dr hab. inż., prof. nadzw. PWr Zbigniewa Zimniaka
 *  \author    inż. Paweł Duda 188192
 *  \author    inż. Jan Karwasiński 188124
 *  \author    inż. Agnieszka Nowaczyńska 188143
 *  \author    inż. Maciej Pałka 188197
 *  \author    inż. Łukasz Rdzeń 188175
 *  \author    inż. Michał Sarnowski 188199
 *  \date      rok akademicki 2014/2015
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotMimiczny
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
