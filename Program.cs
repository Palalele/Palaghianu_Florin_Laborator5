using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Window3D example = new Window3D())
            {
                // Verificați semnătura funcției în documentația inline oferită de IntelliSense!
                example.Run(30.0, 0.0);
            }
        }
    }
}
