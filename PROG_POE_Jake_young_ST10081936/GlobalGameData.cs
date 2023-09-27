using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_POE_Jake_young_ST10081936
{
    static class GlobalGameData
    {
        //global game data
        //time that the game has taken
        private static string gameTime = "00:00";

        public static string GameTime { get => gameTime; set => gameTime = value; }
    }
}
