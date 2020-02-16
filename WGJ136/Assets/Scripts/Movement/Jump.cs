using System;
using UnityEngine;

namespace WGJ136.Movement
{
    public class Jump 
    {
        private float jumpForce = 2f;
        private float fallMultiplier = 2.5f;

        private Rigidbody2D rb;
        // Start is called before the first frame update

        public Jump(Rigidbody2D rb)
        {
            this.rb = rb;
        }
    
        // Update is called once per frame
        public void Update()
        {
            BetterJump();
        }
    
        public void StartJump()
        {
            if(rb.velocity.y <= 0.01f) rb.velocity += Vector2.up * jumpForce;
        }

        private void BetterJump()
        {
            if (rb.velocity.y < 0)
            {
                //rb.velocity += Vector2.up * (fallMultiplier - 1) * Time.deltaTime;
                rb.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime);
            }
        }
    }
}
