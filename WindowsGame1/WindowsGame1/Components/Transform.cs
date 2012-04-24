using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;

namespace StarWarrior.Components
{
    class Transform : Component
    {
        private Vector3 coords;

        public Transform()
        {
        }

	    public Transform(Vector3 coords) {
		    this.coords = coords;
	    }

        public Vector3 Coords {
			get { return coords; }
            set { coords = value; }
        }

	    public float X {
		    get { return coords.X; }
			set { coords.X = value; }
	    }

	    public float Y {
		    get { return coords.Y;}
			set { coords.Y = value; }
	    }

	    public void SetLocation(float x, float y) {
		    this.coords.X = x;
		    this.coords.Y = y;
	    }

	    public float Rotation {
		    get { return coords.Z;}
			set { coords.Z = value;}
	    }
		
	    public void AddRotation(float angle) {
		    coords.Z = (coords.Z + angle) % 360;
	    }

	    public float RotationAsRadians {
            get { return (float)Math.PI * coords.Z / 180.0f;}
	    }
	
	    public float DistanceTo(Transform t) {
		    return Artemis.Utils.Distance(t.X, t.Y, X, Y);
	    }
    }
}