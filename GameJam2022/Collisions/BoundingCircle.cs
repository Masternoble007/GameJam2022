using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace GameJam2022.Collisions
{
    /// <summary>
    /// A struct representing circular bounds
    /// </summary>
    public class BoundingCircle
    {
        /// <summary>
        /// The center of the BoundingCircle
        /// </summary>
        public Vector2 Center;

        /// <summary>
        /// The radius of the BounndingCircle
        /// </summary>
        public float Radius;

        /// <summary>
        /// Constructs a new Bouding Cirle
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        public BoundingCircle(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// Tests for a collision between this and another bounding circle
        /// </summary>
        /// <param name="other">The another bounding circle</param>
        /// <returns>true for collisions, false otherwise</returns>
        public bool Collideswith(BoundingCircle other)
        {
            return CollisionHelper.Collides(this, other);
        }

        public bool CollidesWith(BoundingRectangle other)
        {
            return CollisionHelper.Collides(this, other);
        }

        public bool CollidesWith(BoundingCircle other)
        {
            return CollisionHelper.Collides(this, other);
        }
    }
}