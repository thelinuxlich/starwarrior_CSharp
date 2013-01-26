using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;
using Microsoft.Xna.Framework;

namespace StarWarrior.Components
{
    ///just to show how to use the pool =P (just add this annotation and extend ArtemisComponentPool =P)
    [Artemis.Attributes.ArtemisComponentPool(InitialSize=5,Resizes=true, ResizeSize=20, isSupportMultiThread=false)]
    class Transform : ComponentPoolable
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
            return Vector2.Distance(new Vector2(t.X, t.Y), new Vector2(X, Y));
	    }

        #region ComponentPoolable Members

        public void Cleanup()
        {
             coords = Vector3.Zero;
        }

        #endregion
    }
}