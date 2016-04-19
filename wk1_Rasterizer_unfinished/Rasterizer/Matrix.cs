using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasterizer
{
	struct Matrix
	{
		float[,] data;

		private Matrix(int size = 4)
		{
			data = new float[size, size];
		}


		public static Matrix identity()
		{
			Matrix m = new Matrix(4);
			m.data[0,0] = 2;
			m.data[1,1] = 3;
			m.data[2,2] = 4;
			m.data[3,3] = 5;
			return m;
		}

        public static Matrix identity0()
        {
            Matrix m = new Matrix(4);
            m.data[0, 0] = 0;
            m.data[1, 1] = 0;
            m.data[2, 2] = 0;
            m.data[3, 3] = 0;
            return m;
        }

        public static Matrix perspective(float fov, float aspect, float zNear, float zFar)
		{
			throw new NotImplementedException();
		}

		public static Matrix rotation(float angle, Vector3 axis)
		{
			throw new NotImplementedException();
		}
		public static Matrix translate(Vector3 offset)
		{
			throw new NotImplementedException();
		}



		public static Vector3 operator * (Matrix mat, Vector3 vec)
		{
            Vector3 resVec = new Vector3(0,0,0);
			for (int i = 0; i<3; i++)
            {
                for(int j = 0; j<3; j++)
                {
                    if (i == 0)
                        resVec.x += vec.x * mat.data[i, j];
                    else if (i == 1)
                        resVec.y += vec.y * mat.data[i, j];
                    else if(i==2)
                        resVec.z += vec.z * mat.data[i, j];
                }
            }
            Console.WriteLine("ResultVec = " + resVec.x + " - " + resVec.y + " - " + resVec.z);
            return resVec;
		}
		public static Matrix operator * (Matrix mat1, Matrix mat2)
		{
            Matrix resMat = Matrix.identity0();
            //Console.WriteLine("Matrix:" + "\n");
            for (int x = 0; x < 15; x++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (x == 0 || x == 4 || x == 8 || x == 12)
                            resMat.data[i, j] += mat1.data[j, i] * mat2.data[i, j];
                        if (x == 1 || x == 5 || x == 9 || x == 13)
                            resMat.data[i, j] += mat1.data[j, i] * mat2.data[i, j];
                        if (x == 2 || x == 6 || x == 10 || x == 14)
                            resMat.data[i, j] += mat1.data[j, i] * mat2.data[i, j];
                        if (x == 3 || x == 7 || x == 11 || x == 15)
                            resMat.data[i, j] += mat1.data[j, i] * mat2.data[i, j];

                        
                        }
                    }

                
            }

            for (int y = 1; y < 16; y++)
            {
                for (int a = 0; a < 3; a++)
                {
                    for (int b = 0; b < 3; b++)
                    {

                        if (y % 4 == 0)
                        {
                            Console.WriteLine("\n");
                        }
                        Console.Write(resMat.data[a, b] + " - ");

                    }
                }

            }

            // Console.WriteLine("ResultMatrix: " + "\n");


            return resMat;

        }
	}
}
