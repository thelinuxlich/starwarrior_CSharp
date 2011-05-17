using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;

namespace StarWarrior.Components
{
    class Transform : Component
    {
        private double x;
	    private double y;
	    private double rotation;

	    public Transform() {
	    }

	    public Transform(double x, double y) {
		    this.x = x;
		    this.y = y;
	    }

	    public Transform(double x, double y, double rotation) {
		    this.x = x;
            this.y = y;
		    this.rotation = rotation;
	    }

	    public void AddX(double x) {
		    this.x += x;
	    }

	    public void AddY(double y) {
		    this.y += y;
	    }

	    public double GetX() {
		    return x;
	    }

	    public void SetX(double x) {
		    this.x = x;
	    }

	    public double GetY() {
		    return y;
	    }

	    public void SetY(double y) {
		    this.y = y;
	    }

	    public void SetLocation(double x, double y) {
		    this.x = x;
		    this.y = y;
	    }

	    public double GetRotation() {
		    return rotation;
	    }

	    public void SetRotation(double rotation) {
		    this.rotation = rotation;
	    }

	    public void AddRotation(double angle) {
		    rotation = (rotation + angle) % 360;
	    }

	    public double GetRotationAsRadians() {
            return Math.PI * rotation / 180.0;
	    }
	
	    public double GetDistanceTo(Transform t) {
		    return Artemis.Utils.Distance(t.GetX(), t.GetY(), x, y);
	    }
    }
}
