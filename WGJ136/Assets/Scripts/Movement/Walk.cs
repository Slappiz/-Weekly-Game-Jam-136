using System;
using UnityEngine;

namespace WGJ136.Movement
{
    public class Walk
    {
        private float speed = 1f;

        private Rigidbody2D rb;

        public Walk(Rigidbody2D rb)
        {
            this.rb = rb;
        }
    
        public void Move(Vector2 direction)
        {
            rb.velocity = (new Vector2(direction.x * speed, rb.velocity.y));
        }
    }   
}
