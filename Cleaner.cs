using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustSucker2000
{


    class Cleaner
    {

        /// <summary>
        /// Constructor. Initializes the cleaner with a start position and a start direction
        /// </summary>
        /// <param name="StartPosition"></param>
        /// <param name="StartDirection"></param>
        public Cleaner(Position StartPosition, Direction StartDirection, int GroundWidth, int GroundHeight)
        {
            CurrentPosition = StartPosition;
            CurrentDirection = StartDirection;
            this.GroundWidth = GroundWidth;
            this.GroundHeight = GroundHeight;
        }

        /// <summary>
        /// Current position of the cleaner. Units in m
        /// </summary>
        public Position CurrentPosition { get; private set; }

        /// <summary>
        /// Current pointing direction of the cleaner
        /// </summary>
        public Direction CurrentDirection { get; private set; }

        /// <summary>
        /// Gets the width of the ground in m
        /// </summary>
        public int GroundWidth { get; private set; }

        /// <summary>
        /// Gets the height of the ground in m
        /// </summary>
        public int GroundHeight { get; private set; }

        /// <summary>
        /// Con
        /// </summary>
        private List<Action> CurrentRoute { get; set; }

        /// <summary>
        /// Moves the cleaner according to the route (and cleans the ground in the meanwhile)
        /// </summary>
        public void Clean()
        {
            foreach (Action A in CurrentRoute){
                try
                {
                    switch (A)
                    {
                        case Action.MoveForward:
                            MoveForward();
                            break;
                        case Action.TurnLeft:
                            CurrentDirection = (Direction)(((int)CurrentDirection + 4 + 1) % 4);
                            break;
                        case Action.TurnRight:
                            CurrentDirection = (Direction)(((int)CurrentDirection + 4 - 1) % 4);
                            break;
                    }
                }
                catch (Exception e)
                {
                    // Moved into wall, just ignore
                }

            }
        }

        /// <summary>
        /// Loads a new route into the cleaner
        /// </summary>
        public void LoadRoute(List<Action> Route)
        {
            this.CurrentRoute = Route;
        }

        /// <summary>
        /// Moves the cleaner one step forward
        /// </summary>
        private void MoveForward()
        {
            switch (CurrentDirection)
            {
                case Direction.East:
                    if (CurrentPosition.x < GroundWidth-1)
                        CurrentPosition.x += 1;
                    else
                        throw new InvalidOperationException("Cannot move the cleaner outside the boundaries of the ground");
                    break;
                case Direction.North:
                    if (CurrentPosition.y < GroundHeight-1)
                        CurrentPosition.y += 1;
                    else
                        throw new InvalidOperationException("Cannot move the cleaner outside the boundaries of the ground");
                    break;
                case Direction.West:
                    if (CurrentPosition.x > 0)
                        CurrentPosition.x -= 1;
                    else
                        throw new InvalidOperationException("Cannot move the cleaner outside the boundaries of the ground");
                    break;
                case Direction.South:
                    if (CurrentPosition.y > 0)
                        CurrentPosition.y -= 1;
                    else
                        throw new InvalidOperationException("Cannot move the cleaner outside the boundaries of the ground");
                    break;
            }
        }

    }

    /// <summary>
    /// Enumeration of possible directions of the cleaner
    /// </summary>
    enum Direction
    {
        North = 0,
        West = 1,
        South = 2,
        East = 3
    }

    /// <summary>
    /// Enumeration of the available actions
    /// </summary>
    enum Action
    {
        MoveForward,
        TurnRight,
        TurnLeft
    }

}
