using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CubeDecoratorFile 
{
    //Interface (Base)
    public interface ICubeDecorator
    {
        public string GetPowerup();
    }

    //Implementation
    public class Cube : ICubeDecorator
    {
        public string GetPowerup()
        {
            return "Normal cube.";
        }
    }

    //Base Decorator
    public class BaseCubeDecorator : ICubeDecorator
    {
        private ICubeDecorator _cubeDecorator;

        public BaseCubeDecorator(ICubeDecorator otherDecorators)
        {
            _cubeDecorator = otherDecorators;
        }

        public virtual string GetPowerup()
        {
            return "";
        }
    }

    //Decorators
    public class SpeedyCube : BaseCubeDecorator
    {
        //this decorator makes the cube faster
        public SpeedyCube(ICubeDecorator otherDecorators) : base(otherDecorators)
        {
            //this is intentionally left blank 
        }

        public override string GetPowerup()
        {
            string type = base.GetPowerup();
            type += "With speed!";
            return type;
        }
    }

    public class JumpyCube : BaseCubeDecorator
    {
        //this decorator makes the cube faster
        public JumpyCube(ICubeDecorator otherDecorators) : base(otherDecorators)
        {
            //this is intentionally left blank 
        }

        public override string GetPowerup()
        {
            string type = base.GetPowerup();
            type += "With jumpy!";
            return type;
        }
    }

    public class RedCube : BaseCubeDecorator
    {
        //this decorator makes the cube faster
        public RedCube(ICubeDecorator otherDecorators) : base(otherDecorators)
        {
            //this is intentionally left blank 
        }

        public override string GetPowerup()
        {
            string type = base.GetPowerup();
            type += "With red color!";
            return type;
        }
    }

    public class BlueCube : BaseCubeDecorator
    {
        //this decorator makes the cube faster
        public BlueCube(ICubeDecorator otherDecorators) : base(otherDecorators)
        {
            //this is intentionally left blank 
        }

        public override string GetPowerup()
        {
            string type = base.GetPowerup();
            type += "With blue color!";
            return type;
        }
    }


}
