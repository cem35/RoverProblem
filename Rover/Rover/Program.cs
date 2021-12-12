using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover
{
    public class Program
    {
        public static int[] coordinates = new int[2];
        public static int edgeX, edgeY;
        public static char  currentPosition;
        public static string retVal="";
        public static void Main(string[] args)
        {
            string edges,readDirection,moveCommands, holder="";
            bool flag = true;
            edges = Console.ReadLine();
            edgeX = Int32.Parse(edges.Substring(0, 1));
            edgeY = Int32.Parse(edges.Substring(1, 1));
            while(flag)
            {
                if (holder == "") readDirection = Console.ReadLine();
                else readDirection = holder;
                string[] inputs = readDirection.Split(' ');
                coordinates[0] = Int32.Parse(inputs[0]);
                coordinates[1] = Int32.Parse(inputs[1]);
                currentPosition = char.ToUpper(char.Parse(inputs[2]));
                moveCommands = Console.ReadLine();
                action(moveCommands);
                if (!retVal.Equals("Sinir disi")) retVal += coordinates[0] + " " + coordinates[1] + " " + currentPosition + "\n";
                else retVal = "Belirtilen sınırların dışında \n";
                holder = Console.ReadLine();
                if (holder == "") flag = false;
            }            
            Console.WriteLine(retVal);
            Console.ReadLine();
        }


        public static void action(string moveCommands)
        {
            char[] moves = moveCommands.ToCharArray();
            bool flag = true;
            foreach(char item in moves)
            {
                char tempItem = char.ToUpper(item);
                flag = control();
                if (!flag) retVal = "Sinir disi";
                if (tempItem == 'L' || tempItem == 'R') positions(tempItem);
                else progress();
            }
        }

        public static char positions(char direction)
        {
            if(currentPosition == 'W') return direction == 'L' ? currentPosition = 'S' : currentPosition = 'N';
            else if(currentPosition == 'S') return direction == 'L' ? currentPosition = 'E' : currentPosition = 'W';
            else if(currentPosition == 'E') return direction == 'L' ? currentPosition = 'N' : currentPosition = 'S';
            else return direction == 'L' ? currentPosition = 'W' : currentPosition = 'E';
        }

        public static void progress()
        {
            if (currentPosition == 'W') coordinates[0] -= 1;
            else if (currentPosition == 'S') coordinates[1] -= 1; 
            else if (currentPosition == 'E') coordinates[0] += 1;
            else coordinates[1] += 1;
        }

        public static bool control()
        {
            if (coordinates.Contains(-1)) return false;
            if (coordinates[0] > edgeX || coordinates[1] > edgeY) return false;
            return true;
        }
    }
}
