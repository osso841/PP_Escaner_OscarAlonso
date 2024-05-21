using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PP_Escaner_OscarAlonso";
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            int extension;
            int cantidad;
            string resumen;

            Escaner eLibros = new Escaner("Exo", Escaner.TipoDoc.libro);
            Escaner eMapas = new Escaner("Samsung", Escaner.TipoDoc.mapa);

            //OBJETOS MAPAS
            Mapa m1 = new Mapa("Bs. As.", "pepito robredo", 2010, "", "2384-2834", 42, 10);
            Mapa m2 = new Mapa("Cordoba", "jose pepe", 2000, "", "3245-5334", 50, 40);
            Mapa m3 = new Mapa("Santa Fe", "Gonzales Arugue", 1995, "", "8092-5689", 50, 85);
            Mapa m4 = new Mapa("CABA", "Martin Rodriguez", 2018, "", "2382-2852", 89, 100);
            Mapa m5 = new Mapa("CABA", "Martin Rodriguez", 2018, "", "8982-9999", 89, 100);//m5 repetido mapas repetidos m4           
            Mapa m6 = new Mapa("santa f", "Arugue", 1995, "", "8092-5689", 50, 50);//m6 repetido mapas repetidos m3
            Mapa m7 = new Mapa("Argentina", "urregui", 2020, "", "8293-4328", 100, 200);

            //OBJETOS LIBROS
            Libro l1 = new Libro("Clasicos", "John Wesley", 2021, "212-a", "9781087703237", 425);
            Libro l2 = new Libro("Padre Rico, Padre Pobre", "Robert Kiyosaki", 2022, "234-2", "9789877253146", 411);
            Libro l3 = new Libro("El Talento Nunca es Suficiente", "John Maxwell", 2007, "23-23", "9780881130720", 321);
            Libro l4 = new Libro("La odisea", "Homero", 2007, "234-533", "9789978809525", 360);
            Libro l5 = new Libro("Don Quijote de la Mancha", "Manuel Cervantes", 2012, "6534-35", "9789978808405", 270);
            Libro l6 = new Libro("el artexsano", "ruben gonzales", 1994, "3345-234", "78998754123", 400);
            Libro l7 = new Libro("el artesano", "ruben gonzales", 1994, "3345-234", "78998754123", 400);// l7 repetido libros repetidos
            Libro l8 = new Libro("La iliada", "Homero", 2016, "234-46367", "978997883245", 500);
            Libro l9 = new Libro("La iliada", "Homero", 2007, "234-533", "9789978809525", 360);//l9 repetido libros repetidos

            //COLOCAMOS DIRECTAMENTE EL LIBRO EN DISTRIBUCION 
            Libro l10 = new Libro("Dejados Atras", "Tim LaHaye", 1997, "8923-2859", "9780789915504", 341);
            l10.AvanzarEstado();//estado distribuido
            Libro l11 = new Libro("Penetrando La Oscuridad", "Frank E. Peretti", 1989, "3784-2348", "9780829752298", 528);
            l11.AvanzarEstado();
            l11.AvanzarEstado();//estado revision

            Console.WriteLine(eMapas + l1); //VERIFICACION. !!!NO SE PUEDE CARGAR UN MAPA EN EL SCANER DE LIBROS Y VICEVERSA
            Console.WriteLine(eLibros + m1); //VERIFICACION. !!!NO SE PUEDE CARGAR UN MAPA EN EL SCANER DE LIBROS Y VICEVERSA

            Console.WriteLine();

            Console.WriteLine("CARGA EN ESCANER EXO LIBROS");
            Console.WriteLine("Carga de Libros en el scaner de libros");
            Console.WriteLine(eLibros + l8);
            Console.WriteLine(eLibros + l9);// no debe cargar. return false
            Console.WriteLine(eLibros + l6);
            Console.WriteLine(eLibros + l7);// no debe cargar. return false
            Console.WriteLine(eLibros + l1);
            Console.WriteLine(eLibros + l2);
            Console.WriteLine(eLibros + l3);
            Console.WriteLine(eLibros + l4);
            Console.WriteLine(eLibros + l5);
            Console.WriteLine(eLibros + l10);// false, no debe cargar. el estado no esta en INICIO
            Console.WriteLine(eLibros + l11);//false, no debe cargar, el estado no esta en INICIO

            Console.WriteLine();

            Libro L100 = new Libro("meditaciones", "Julio Cesar", 1990, "3824-3842", "9123482394", 190);//estado inicio
            Mapa M100 = new Mapa("Chile", "alberto", 1940, "3238-8239", "38572982839", 200, 300); //estado inicio

            Console.WriteLine("El escaner de mapa no debe aceptar libros y viceversa!!");
            Console.WriteLine(eMapas + L100); //VERIFICACION. 
            Console.WriteLine(eLibros + M100); //VERIFICACION.

            Console.WriteLine();

            eLibros.CambiarEstadoDocumento(l1);
            eLibros.CambiarEstadoDocumento(l2);
            eLibros.CambiarEstadoDocumento(l2);
            eLibros.CambiarEstadoDocumento(l3);
            eLibros.CambiarEstadoDocumento(l3);
            eLibros.CambiarEstadoDocumento(l3);
            eLibros.CambiarEstadoDocumento(l3);
            eLibros.CambiarEstadoDocumento(l3);

            Console.WriteLine();

            //MOSTRAR DATOS LIBROS
            Informes.MostrarDistribuidos(eLibros, out extension, out cantidad, out resumen);
            Console.WriteLine("DISTRIBUIDOS");
            Console.WriteLine($"cantidad de paginas: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad} \n");
            Console.WriteLine(resumen);

            //EN ESCANER
            Informes.MostrarEnEscaner(eLibros, out extension, out cantidad, out resumen);
            Console.WriteLine("ESCANER");
            Console.WriteLine($"cantidad de paginas: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            //MOSTRAR EN REVISION
            Informes.MostrarEnRevision(eLibros, out extension, out cantidad, out resumen);
            Console.WriteLine("REVISION");
            Console.WriteLine($"cantidad de paginas: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad} \n");
            Console.WriteLine(resumen);

            //MOSTRAR EN TERMINADO
            Informes.MostrarTerminados(eLibros, out extension, out cantidad, out resumen);
            Console.WriteLine("TERMINADOS");
            Console.WriteLine($"cantidad de paginas: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            Console.WriteLine("\n***********************************\n");

            Console.WriteLine("CARGA EN ESCANER SAMSUNG MAPAS");
            Console.WriteLine("Carga de Mapas en el scaner de mapas");
            Console.WriteLine(eMapas + m1);
            Console.WriteLine(eMapas + m2);
            Console.WriteLine(eMapas + m3);
            Console.WriteLine(eMapas + m4);
            Console.WriteLine(eMapas + m5); // no debe cargar. return false
            Console.WriteLine(eMapas + m6); // no debe cargar. return false
            Console.WriteLine(eMapas + m7);

            eMapas.CambiarEstadoDocumento(m2);
            eMapas.CambiarEstadoDocumento(m3);
            eMapas.CambiarEstadoDocumento(m3);
            eMapas.CambiarEstadoDocumento(m4);
            eMapas.CambiarEstadoDocumento(m4);
            eMapas.CambiarEstadoDocumento(m4);
            eMapas.CambiarEstadoDocumento(m7);
            eMapas.CambiarEstadoDocumento(m7);
            eMapas.CambiarEstadoDocumento(m7);
            eMapas.CambiarEstadoDocumento(m7);
            eMapas.CambiarEstadoDocumento(m7);

            Console.WriteLine();

            Informes.MostrarDistribuidos(eMapas, out extension, out cantidad, out resumen);
            Console.WriteLine("DISTRIBUIDOS");
            Console.WriteLine($"total de superficie: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            Informes.MostrarEnEscaner(eMapas, out extension, out cantidad, out resumen);
            Console.WriteLine("ESCANER");
            Console.WriteLine($"total de superficie: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            Informes.MostrarEnRevision(eMapas, out extension, out cantidad, out resumen);
            Console.WriteLine("REVISION");
            Console.WriteLine($"total de superficie: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad} \n");
            Console.WriteLine(resumen);

            Informes.MostrarTerminados(eMapas, out extension, out cantidad, out resumen);
            Console.WriteLine("TERMINADOS");
            Console.WriteLine($"total de superficie: {extension}");
            Console.WriteLine($"Cantidad de documentos: {cantidad}\n");
            Console.WriteLine(resumen);

            //VERIFICACION DE DOCUMENTOS CAMBIANDO DE ESTADO
            Console.ReadKey();
        }
    }
}
