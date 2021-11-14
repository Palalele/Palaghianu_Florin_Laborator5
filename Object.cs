using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace Project
{
    class Object
    {
        private bool visibility;
        private bool gravityBound;
        private Color color;
        private List<Vector3> coordList;
        private Randomizer random;

        private const int Gravity_Offset = 1;


        public Object(bool gravity_status)
        {
            gravityBound = gravity_status;
            visibility = true;

            random = new Randomizer();
            color = random.RandomColor();

            int size_offset = random.RandomInt(5);
            int height_offset = random.RandomInt(40, 60);
            int radial_offest = random.RandomInt(5, 15);

            coordList = new List<Vector3>();
            coordList.Add(new Vector3(0 * size_offset + radial_offest, 0 * size_offset + height_offset, 5 * size_offset + radial_offest));
            coordList.Add(new Vector3(0 * size_offset + radial_offest, 0 * size_offset + height_offset, 0 * size_offset + radial_offest));
            coordList.Add(new Vector3(5 * size_offset + radial_offest, 0 * size_offset + height_offset, 5 * size_offset + radial_offest));
            coordList.Add(new Vector3(5 * size_offset + radial_offest, 0 * size_offset + height_offset, 0 * size_offset + radial_offest));
            coordList.Add(new Vector3(5 * size_offset + radial_offest, 5 * size_offset + height_offset, 5 * size_offset + radial_offest));
            coordList.Add(new Vector3(5 * size_offset + radial_offest, 5 * size_offset + height_offset, 0 * size_offset + radial_offest));
            coordList.Add(new Vector3(0 * size_offset + radial_offest, 5 * size_offset + height_offset, 5 * size_offset + radial_offest));
            coordList.Add(new Vector3(0 * size_offset + radial_offest, 5 * size_offset + height_offset, 0 * size_offset + radial_offest));
            coordList.Add(new Vector3(0 * size_offset + radial_offest, 0 * size_offset + height_offset, 5 * size_offset + radial_offest));
            coordList.Add(new Vector3(0 * size_offset + radial_offest, 0 * size_offset + height_offset, 0 * size_offset + radial_offest));
        }

        public void Draw()
        {
            if (visibility)
            {
                GL.Color3(color);
                GL.Begin(PrimitiveType.QuadStrip);
                foreach (Vector3 v in coordList)
                {
                    GL.Vertex3(v);
                }
                GL.End();
            }
        }

        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        public void UpdatePosition(bool gravity_status)
        {
            if (visibility && gravity_status && !GroundCollisionDetected())
            {
                for (int i = 0; i < coordList.Count; i++)
                {
                    coordList[i] = new Vector3(coordList[i].X, coordList[i].Y - Gravity_Offset, coordList[i].Z);
                }
            }
        }

        public bool GroundCollisionDetected()
        {
            foreach (Vector3 v in coordList)
            {
                if (v.Y <= 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
