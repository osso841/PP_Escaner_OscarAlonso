using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
        //Atributos
        private int anio;
        private string autor;
        private string barcode;
        private Paso estado;
        private string numNormalizado;
        private string titulo;

        //Propiedades
        /// <summary>
        /// obtener el anio del documento
        /// </summary>
        public int Anio
        {
            get => this.anio;
        }

        /// <summary>
        /// obtener el autor del documento
        /// </summary>
        public string Autor
        {
            get => this.autor;
        }

        /// <summary>
        /// obtener el codigo de barras del documento
        /// </summary>
        public string Barcode
        {
            get => this.barcode;
        }

        /// <summary>
        /// obtener el estado del documento
        /// </summary>
        public Paso Estado
        {
            get => this.estado;
        }

        /// <summary>
        /// obtener el numero Normalizado del documento
        /// </summary>
        protected string NumNormalizado
        {
            get => this.numNormalizado;
        }

        /// <summary>
        /// obtener el titulo del documento
        /// </summary>
        public string Titulo
        {
            get => this.titulo;
        }

        //Constructores
        /// <summary>
        /// se inicializa una nueva instancia de la clase documento 
        /// </summary>
        /// <param name="titulo">titulo del documento</param>
        /// <param name="autor">autor del documento</param>
        /// <param name="anio">anio del documento</param>
        /// <param name="numNormalizado">numero referencia del documento</param>
        /// <param name="barcode">codigo de barras del documento</param>
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }

        //Metodos
        /// <summary>
        /// avanza el estado del documento al siguiente paso
        /// </summary>
        /// <returns>
        /// <c>true</c> si el estado se avanzo con exito;
        /// <c>false</c> si el documento ya esta en el estado <see cref="Paso.Terminado"/>
        /// </returns>
        public bool AvanzarEstado()
        {
            bool retorno = true;

            if (this.estado == Paso.Terminado)
            {
                retorno = false;
            }
            else
            {
                this.estado++;
            }
            return retorno;
        }

        /// <summary>
        /// Devuelve una cadena que representa al objeto actual
        /// </summary>
        /// <returns>una cadena que tiene los detalles del documento</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Titulo: {this.titulo}");
            sb.AppendLine($"Autor: {this.autor}");
            sb.AppendLine($"Año: {this.anio}");
            sb.Append($"Cód. de barras: {barcode}");
            return sb.ToString();
        }

        //Enumerado
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

    }
}