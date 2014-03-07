using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustSucker2000
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                // Read width and height of ground
                string[] groundBoundariesStr = Console.ReadLine().Split(' ');
                int width = int.Parse(groundBoundariesStr[0]);
                int height = int.Parse(groundBoundariesStr[1]);
                
                // Read cleaner init state
                string[] initStateStr = Console.ReadLine().Split(' ');
                Direction dir;
                switch(initStateStr[0]){
                    case "N":
                        dir = Direction.North;
                        break;
                    case "W":
                        dir = Direction.West;
                        break;
                    case "E":
                        dir = Direction.East;
                        break;
                    case "S":
                        dir = Direction.South;
                        break;
                    default:
                        throw new ArgumentException("Error: The initial direction of the cleaner was not correctly given");
                }
                Position initPos = new Position(int.Parse(initStateStr[1]), int.Parse(initStateStr[2]));

                // Read and parse cleaner route
                string routeStr = Console.ReadLine();
                List<Action> route = new List<Action>();
                foreach(char c in routeStr){
                    switch(c){
                        case 'A':
                            route.Add(Action.MoveForward);
                            break;
                        case 'R':
                            route.Add(Action.TurnRight);
                            break;
                        case 'L':
                            route.Add(Action.TurnLeft);
                            break;
                        default:
                            throw new ArgumentException("Error: The route was not correctly given");
                    }
                }
    
		        // Create a new cleaner object
                Cleaner cleaner = new Cleaner(initPos, dir, width, height);

                // Load route
                cleaner.LoadRoute(route);

                // Simulate clean
                cleaner.Clean();

                // Write output
                Console.WriteLine("\nDustSucker2000 simulator by Tobias Norlund\n");
                Console.WriteLine("Simulator for the DustSucker 2000. Predicts the end position and direction of the cleaner. If the cleaner is commanded to move outside the world boundaries, it simply ignores the command.\n");
                Console.WriteLine("Result: " + cleaner.CurrentDirection.ToString()[0] + " "  + cleaner.CurrentPosition.x + " " + cleaner.CurrentPosition.y);

	        }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
	        catch (Exception e)
	        {
                Console.WriteLine("Error: Someting in the input were not formatted as it should");
	        }
            finally
            {
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
