using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Graphics;



namespace Project
{
    public class Axes
    {

        private bool _visibility;
        private float _axeSize;
        private Color _xColor;
        private Color _yColor;
        private Color _zColor;
        private const int AXIS_LENGTH = 75;

        public Axes()
        {
            _axeSize = 200;

            _xColor = Color.CornflowerBlue;
            _yColor = Color.ForestGreen;
            _zColor = Color.IndianRed;

            _visibility = true;
        }

        public bool GetVisibility()
        {
            return _visibility;
        }

        public void Show()
        {
            _visibility = true;
        }

        public void Hide()
        {
            _visibility = false;
        }


       
        public void Draw()
        {

            if (!_visibility)
            {
                return;
            }


            GL.LineWidth(1.0f);

            GL.Begin(PrimitiveType.Lines);
            //x
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(AXIS_LENGTH, 0, 0);
            //y
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, AXIS_LENGTH, 0);
            //z
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, AXIS_LENGTH);
            GL.End();
        }
    }
}
