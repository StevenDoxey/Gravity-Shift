﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace GravityShift
{
    /// <summary>
    /// Represents the player in the game
    /// </summary>
    class Player : PhysicsObject
    {
        IControlScheme mControls;
        Vector2 mSpawnPoint;

        /// <summary>
        /// Construcs a player object, that can live in a physical realm
        /// </summary>
        /// <param name="content">Content manager for the game</param>
        /// <param name="name">Name of the image resource for the player</param>
        /// <param name="initialPosition">Initial posisition in the level</param>
        /// <param name="scalingFactors">Factor for the image resource(i.e. half the size would be (.5,.5))</param>
        /// <param name="controlScheme">Controller scheme for the player(Controller or keyboard)</param>
        public Player(ContentManager content, String name, Vector2 scalingFactors, 
            Vector2 initialPosition,ref PhysicsEnvironment environment, IControlScheme controlScheme) 
            : base(content, name, scalingFactors, initialPosition,ref environment)
        {
            mControls = controlScheme;
            mSpawnPoint = initialPosition;
        }

        /// <summary>
        /// Updates the player location and the player controls
        /// </summary>
        /// <param name="gametime">The current Gametime</param>
        public override void Update(GameTime gametime)
        {
            base.Update(gametime);

            if (mControls.isDownPressed(gametime)) mEnvironment.GravityDirection = GravityDirections.Down;
            else if (mControls.isUpPressed(gametime)) mEnvironment.GravityDirection = GravityDirections.Up;
            else if (mControls.isLeftPressed(gametime)) mEnvironment.GravityDirection = GravityDirections.Left;
            else if (mControls.isRightPressed(gametime)) mEnvironment.GravityDirection = GravityDirections.Right;
        }

        /// <summary>
        /// Will handle players death TODO - IMPLEMENT ME!!
        /// </summary>
        public override void Kill()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the Unique identifier for this object. Will be used for logging
        /// </summary>
        /// <returns>A string with the Object ID and the object type</returns>
        public override string ToString()
        {
            return  "Object ID:" + this.ObjectID + " Type: Player";
        }
    }
}
