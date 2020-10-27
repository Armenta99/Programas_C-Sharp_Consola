using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussJordan
{
    class Program
    {
     
        //Función estatico que permite redondear a 7 cifras significativas para que el error sea más pequeño
        //(Puede modificarlo para que me de las cifras significativas que yo desee)
        static double redondeo(double numero)
        {
            return (Math.Round(numero * 1000000) / 1000000);

        }
        //Método que permite revisar si en el pivote fue ingresado un 0 y reordena las ecuaciones
        static void revisarpivote(double[,] Gauss, int incognitas)
        {
            double auxiliar;
            
            for (int i = 0; i < incognitas; i++)
            {
                for (int j = 0; j < incognitas; j++)
                {
                    if (j == i)
                    {
                        //Compara si el pivote 0 esta en el primer renglon para ordenarlo en otra posicion
                        if (Gauss[0, 0] == 0)
                        {
                            //Reordena pasando lo que esta en 0 en el siguiente renglon
                            Console.WriteLine("Reordenamiento.");
                            for (int k = 0; k < incognitas + 1; k++)
                            {
                                auxiliar = Gauss[0, k];
                                Gauss[0, k] = Gauss[1,k];
                                Gauss[1, k] = auxiliar;
                            }
                            i = 0;
                            j = 0;
                        }

                         if (Gauss[i, j] == 0)


                        {
                            //Reordena colocando el renglon con el pivote 0 en el renglon 1 y viceversa
                            Console.WriteLine("Reordenamiento.");
                            for (int k = 0; k < incognitas + 1; k++)
                             {
                                 auxiliar = Gauss[i, k];
                                 Gauss[i, k] = Gauss[0,k];
                                 Gauss[0, k] = auxiliar;
                             }
                             i = 0;
                             j = 0;
                         }
                         
                    }

                }



            }


        }

            static void Main(string[] args)
        {
            int incognitas = 0;
            //Aqui se genera la ecuacion y se ingresa en la matriz___________________________
            Console.WriteLine("Dame el numero de incognitas: ");
            incognitas = int.Parse(Console.ReadLine());
            double[,] Gauss = new double[incognitas, incognitas + 1];


            for (int i = 0; i < incognitas; i++)
            {
                Console.WriteLine("R" + (i + 1));
                for (int j = 0; j < incognitas; j++)
                {
                    Console.Write("X" + (j + 1) + " = ");

                    Gauss[i, j] = redondeo(double.Parse(Console.ReadLine()));
                   
                }
                Console.Write("b" + (i+1) + " = ");
                Gauss[i, incognitas] = double.Parse(Console.ReadLine());


            }
            //_______________________________________________________________________
            revisarpivote(Gauss,incognitas);
            //IMPRESION INICIAL
        for (int i = 0; i < incognitas; i++)
        {


            for (int j = 0; j < incognitas; j++)
            {
                Console.Write(Gauss[i, j] + " ");

            }
            Console.WriteLine(" = " + Gauss[i, incognitas]);



        }
        //operaciones______________________________________________________________
        for (int pivote = 0; pivote < incognitas; pivote++)
        {


            double normal = Gauss[pivote, pivote];
            //NORMALIZAR ()
            for (int j = 0; j < incognitas + 1; j++)
            {
                    //Dividimos todo el renglon entre el pivote
                Gauss[pivote, j] = redondeo((Gauss[pivote, j] / normal));

            }




            for (int fila = incognitas - 1; fila >= 0; fila--)
            {
                    //OBTENCION DEL COEFICIENTE DEL RENGLON PIVOTE
                double coeficiente = Gauss[fila, pivote];

                if (fila != pivote)
                {
                    for (int columnas = 0; columnas < incognitas + 1; columnas++)
                    {
                            //Realizamos la resta del renglon con el coeficiente multiplicadondo en el pivote
                        Gauss[fila, columnas] = redondeo(Gauss[fila, columnas] - (Gauss[pivote, columnas] * coeficiente));

                    }
                }

            }
            //Imprime como va el procedimiento de eliminacion de cada fila de la matriz
            Console.WriteLine("\n________________________________________\n");
            for (int i = 0; i < incognitas; i++)
            {


                for (int j = 0; j < incognitas; j++)
                {
                    Console.Write(Gauss[i, j] + " ");

                }
                Console.WriteLine(" = " + Gauss[i, incognitas]);

            }
            Console.WriteLine("\n________________________________________\n");

            }

            

            Console.WriteLine("\n\nResultados: ");
            //Resultados
            for (int i = 0; i < incognitas; i++)
            {
                Console.WriteLine($"X{i+1} = {redondeo(Gauss[i, incognitas])}");
            }
            Console.ReadKey();
        }

       
    }


   
    
}
