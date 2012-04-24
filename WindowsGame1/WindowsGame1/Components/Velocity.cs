using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;

namespace StarWarrior.Components
{
    class Velocity : Component
    {
        private float velocity;
        private float angle;

        public Velocity()
        {
        }

        public Velocity(float vector)
        {
            velocity = vector;
        }

        public Velocity(float velocity, float angle)
        {
            this.velocity = velocity;
            this.angle = angle;
        }

        public float Speed {
            get { return velocity;}
			set { velocity = value; }
        }

        public float Angle
        {
			get { return angle; }	
            set { angle = angle;}
        }

        public void AddAngle(float a)
        {
            angle = (angle + a) % 360;
        }

        public float AngleAsRadians
        {
            get { return (float)Math.PI * angle / 180.0f; }
        }
    }
}
