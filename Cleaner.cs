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
        /// Current position of the cleaner. Units in m
        /// </summary>
        public Position CurrentPosition { get; set; }

        /// <summary>
        /// Current pointing direction of the cleaner
        /// </summary>
        public Direction CurrentDirection { get; set; }


        /// <summary>
        /// Con
        /// </summary>
        private List<Actions> CurrentRoute { get; set; }

        /// <summary>
        /// Moves the cleaner according to the route and cleans the ground in the meanwhile
        /// </summary>
        public void Clean()
        {
            
        }

        /// <summary>
        /// Loads a new route into the cleaner
        /// </summary>
        public void LoadRoute()
        {

        }

    }

    /// <summary>
    /// Enumeration of possible directions of the cleaner
    /// </summary>
    enum Direction
    {
        North,
        West,
        South,
        East
    }

    /// <summary>
    /// Enumeration of the available actions
    /// </summary>
    enum Actions
    {
        MoveForward,
        TurnRight,
        TurnLeft
    }

}
