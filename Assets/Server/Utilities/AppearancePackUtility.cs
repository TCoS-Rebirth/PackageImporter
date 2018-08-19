using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class AppearancePackUtility
    {

        public static void Pack(int race, int gender, int body, int head, int bodyColor, int chestTattoo, int leftTattoo, int rightTattoo, int hair, int hairColor,
            int voice, out int appPart1, out int appPart2)
        {
            appPart1 = 0;
            appPart1 = appPart1 | race;
            appPart1 = appPart1 | (gender << 1);
            appPart1 = appPart1 | (body << 2);
            appPart1 = appPart1 | (head << 4);
            appPart1 = appPart1 | (0 << 10);
            appPart1 = appPart1 | (bodyColor << 11);
            appPart1 = appPart1 | (chestTattoo << 19);
            appPart1 = appPart1 | (leftTattoo << 23);
            appPart1 = appPart1 | (rightTattoo << 27);
            appPart1 = appPart1 | ((0 & 1) << 31); //unused tattoo
            appPart2 = 0;
            appPart2 = appPart2 | (0 >> 1); //unused tattoo
            appPart2 = appPart2 | (hairColor << 3);
            appPart2 = appPart2 | (voice << 20);
            appPart2 = appPart2 | (hair << 23);
        }
    }
}
