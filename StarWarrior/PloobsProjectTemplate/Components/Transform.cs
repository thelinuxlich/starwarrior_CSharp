using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;

namespace StarWarrior.Components
{
    class Transform : Component
    {
        private float x;
	    private float y;
	    private float rotation;

	    public Transform() {
	    }

	    public Transform(float x, float y) {
		    this.x = x;
		    this.y = y;
	    }

	    public Transform(float x, float y, float rotation) {
		    this.x = x;
            this.y = y;
		    this.rotation = rotation;
	    }

	    public void AddX(float x) {
		    this.x += x;
	    }

	    public void AddY(float y) {
		    this.y += y;
	    }

	    public float GetX() {
		    return x;
	    }

	    public void SetX(float x) {
		    this.x = x;
	    }

	    public float GetY() {
		    return y;
	    }

	    public void SetY(float y) {
		    this.y = y;
	    }

	    public void SetLocation(float x, float y) {
		    this.x = x;
		    this.y = y;
	    }

	    public float GetRotation() {
		    return rotation;
	    }

	    public void SetRotation(float rotation) {
		    this.rotation = rotation;
	    }

	    public void AddRotation(float angle) {
		    rotation = (rotation + angle) % 360;
	    }

	    public double GetRotationAsRadians() {
            return Math.PI * rotation / 180.0;
	    }
	
	    public float GetDistanceTo(Transform t) {
		    return Artemis.Utils.Distance(t.GetX(), t.GetY(), x, y);
	    }
    }
}
