using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;

namespace StarWarrior.Components
{
    class Expires : Component
    {
        private float lifeTime;

        public Expires() { }

        public Expires(float lifeTime)
        {
            this.lifeTime = lifeTime;
        }

        public float LifeTime
        {
            get { return lifeTime; }
			set { lifeTime = value; }
        }

        public void ReduceLifeTime(float lifeTime)
        {
            this.lifeTime -= lifeTime;
        }

        public bool IsExpired 
        {
            get { return lifeTime <= 0;}
        }
    }
}
