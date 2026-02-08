using System.Numerics;

namespace Core
{   
    // Camera
    public struct Camera
    {   
        // Public Data
        public Vector3 Position;
        public Vector3 Forward;
        public Vector3 Right;
        public Vector3 Up;

        public int Width;
        public int Height;
        public float Fov; // Radians

        public Vector3 GetRayDirection(int x, int y)
        {
            float nx = (x + 0.5f) / Width * 2f - 1f;
            float ny = 1f - (y + 0.5f) / Height;

            float aspect = (float)Width / Height;
            float scale = MathF.Tan(Fov * 0.5f);

            Vector3 dir =
                Forward +
                Right * (nx * aspect * scale) +
                Up * (ny * scale);

            return Vector3.Normalize(dir);
        }
        
        public Ray GetRay(int x, int y)
        {
            return new Ray
            {
                Origin = Position,
                Direction = GetRayDirection(x, y)
            };
        }
    }
    
    // Ray
    public struct Ray
    {
        public Vector3 Origin;
        public Vector3 Direction;
    }

}
