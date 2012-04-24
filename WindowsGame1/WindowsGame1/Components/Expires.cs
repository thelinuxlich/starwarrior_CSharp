using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;

namespace StarWarrior.Components
{
    class Expires : Component
    {
        private int lifeTime;

        public Expires() { }

        public Expires(int lifeTime)
        {
            this.lifeTime = lifeTime;
        }

        public int LifeTime
        {
            get { return lifeTime; }
			set { lifeTime = value; }
        }

        public void ReduceLifeTime(int lifeTime)
        {
            this.lifeTime -= lifeTime;
        }

        public bool IsExpired 
        {
            get { return lifeTime <= 0;}
        }
    }
}
