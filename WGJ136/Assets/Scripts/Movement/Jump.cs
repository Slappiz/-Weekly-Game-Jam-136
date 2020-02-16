using System;
using UnityEngine;

namespace WGJ136.Movement
{
    public class Jump 
    {
        private float jumpForce = 3f;
        private float fallMultiplier = 2.5f;
        private float lowJumpMultiplier = 2f;

        private Rigidbody2D rb;
        // Start is called before the first frame update

        public Jump(Rigidbody2D rb)
        {
            this.rb = rb;
        }
    
        // Update is called once per frame
        public void Update(bool isJumpPressed)
        {
            BetterJump(isJumpPressed);
        }
    
        public void StartJump()
        {
            // rb.velocity = new Vector2(rb.velocity.x, 0);
            // rb.velocity += Vector2.up * jumpForce;
            rb.velocity = Vector2.up * jumpForce;
        }

        private void BetterJump(bool isJumpPressed)
        {
            if (rb.velocity.y < 0)
            {
                //rb.velocity += Vector2.up * (fallMultiplier - 1) * Time.deltaTime;
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            } else if (rb.velocity.y > 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }
}
