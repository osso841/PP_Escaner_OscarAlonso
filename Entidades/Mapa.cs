using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        //atributos
        private int alto;
        private int ancho;

        //propiedades
        /// <summary>
        /// obtener alto del mapa
        /// </summary>
        public int Alto
        {
            get => this.alto;
        }

        /// <summary>
        /// obtener ancho del mapa
        /// </summary>
        public int Ancho
        {
            get => this.ancho;
        }

        /// <summary>
        /// sobtener la superficie del mapa
        /// </summary>
        public int Superficie
        {
            get => this.ancho * this.alto;
        }

        //Constructor
        /// <summary>
        /// se crea una nueva instancia de la clase Mapa
        /// </summary>
        /// <param name="titulo">titulo del mapa</param>
        /// <param name="autor">autor del mapa</param>
        /// <param name="anio">anio del la obra</param>
        /// <param name="numNormalizado">numero de referencia del mapa</param>
        /// <param name="barcode">codigo de barras del mapa</param>
        /// <param name="ancho">ancho del mapa</param>
        /// <param name="alto">alto del mapa</param>
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        //Metodos
        /// <summary>
        /// Devuelve una cadena que representa al objeto acttual
        /// </summary>
        /// <returns>una cadena que tiene los detalles del Mapa</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Superficie: {this.alto} * {this.ancho} = {this.Superficie} cm2");
            return sb.ToString();
        }

        //comparadores
        /// <summary>
        /// Sobrecarga del operador == para comparar dos instancias de la clase Mapa.
        /// </summary>
        /// <param name="a">La Primera Instancia de Mapa</param>
        /// <param name="b">La Segunda Instancia de Mapa</param>
        /// <returns><c>True</c></returns> si los codigos de barra (Barcode) son iguales 
        /// o si los titulos(Titulo), autores (Autor), anios(Anio) y superficies(Superficie) son iguales
        /// de lo contrario <c>False</c>.
        public static bool operator ==(Mapa a, Mapa b)
        {
            bool compararBarcode = a.Barcode == b.Barcode;
            bool compararDatos = a.Titulo == b.Titulo
                                 && a.Autor == b.Autor
                                 && a.Anio == b.Anio
                                 && a.Superficie == b.Superficie;
            return compararBarcode || compararDatos;
        }

        /// <summary>
        /// Sobrecarga del operador != para comparar dos instancias de la clase Mapa
        /// </summary>
        /// <param name="a">La primera instancia de Mapa.</param>
        /// <param name="b">La segunda instancia de Mapa.</param>
        /// <returns><c>True</c> si las instancias no son iguales segun los criterios del operador ==;
        /// de lo contrario <c>false</c></returns>
        public static bool operator !=(Mapa a, Mapa b)
        {
            return !(a == b);
        }
    }
}

