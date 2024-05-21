using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        //atributos

        private int numPaginas;

        //propiedades
        /// <summary>
        /// obtener el numNormalizado del libro
        /// </summary>
        public string ISBN
        {
            get => NumNormalizado;
        }

        /// <summary>
        /// obtener el numero de pagina del Libro
        /// </summary>
        public int NumPaginas
        {
            get => this.numPaginas;
        }

        //constructor
        /// <summary>
        /// se crea una instancia de la clase libro
        /// </summary>
        /// <param name="titulo">titulo del Libro</param>
        /// <param name="autor">autor del Libro</param>
        /// <param name="anio">anio del Libro</param>
        /// <param name="numNormalizado">ISBN del Libro</param>
        /// <param name="barcode">codigo de barras del Libro</param>
        /// <param name="numPaginas">cantidad de paginas del Libro</param>
        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = numPaginas;
        }

        //metodos
        /// <summary>
        /// Devuelve una cadena que representa al objeto acttual
        /// </summary>
        /// <returns>una cadena que tiene los detalles del libro</returns>
        public override string ToString()
        {
            string[] partes = base.ToString().Split('\n');

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(partes[0]);
            sb.AppendLine(partes[1]);
            sb.AppendLine(partes[2]);
            sb.AppendLine($"ISBN: {ISBN}");
            sb.AppendLine(partes[3]); //indice 3 cod. de barras
            sb.AppendLine($"Número de páginas: {this.numPaginas}.");
            return sb.ToString();
        }

        //comparadores
        /// <summary>
        /// Sobrecarga del operador == para comparar dos instancias de la clase Libro.
        /// </summary>
        /// <param name="a">La Primera Instancia de Libro</param>
        /// <param name="b">La Segunda Instancia de Libro</param>
        /// <returns><c>True</c> si los codigos de barra (Barcode), 
        /// los titulos(Titulo) y autores (Autor) o el ISBN son iguales
        /// de lo contrario <c>False</c>.</returns>
        public static bool operator ==(Libro a, Libro b)
        {
            return a.Barcode == b.Barcode || a.ISBN == b.ISBN || (a.Titulo == b.Titulo && a.Autor == b.Autor);
        }

        /// <summary>
        /// Sobrecarga del operador != para comparar dos instancias de la clase Libro
        /// </summary>
        /// <param name="a">La primera instancia de Libro.</param>
        /// <param name="b">La segunda instancia de Libro.</param>
        /// <returns><c>True</c> si las instancias no son iguales segun los criterios del operador ==;
        /// de lo contrario <c>false</c></returns>
        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }
    }
}

