using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLoop {
    static class Program {
        //static FastLoop _fastLoop = new FastLoop( GameLoop );

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Form1() );
        }

        static void GameLoop(double elapsedTime) {
            //input
            //state
            //render
        }
    }
}
