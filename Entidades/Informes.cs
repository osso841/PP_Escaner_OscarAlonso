using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Informes
    {
        /// <summary>
        /// Muestra los documentos del escáner que tienen un estado específico y calcula la extensión total de esos documentos.
        /// </summary>
        /// <param name="e">El escáner.</param>
        /// <param name="estado">El estado de los documentos a mostrar.</param>
        /// <param name="extension">La extensión total de los documentos mostrados
        /// cantidad de paginas totales en el caso de Libro; superficie total en el caso de Mapas
        /// </param>
        /// <param name="cantidad">La cantidad de documentos mostrados.</param>
        /// <param name="resumen">Un resumen de los documentos mostrados.</param>
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            StringBuilder sb = new StringBuilder();
            extension = 0;
            resumen = "";
            cantidad = 0;

            foreach (Documento d in e.ListaDocumentos)
            {
                if (d.Estado == estado)
                {
                    if (e.Tipo == Escaner.TipoDoc.libro)
                    {
                        Libro miLibro = (Libro)d;
                        extension += miLibro.NumPaginas;
                    }
                    else if (e.Tipo == Escaner.TipoDoc.mapa)
                    {
                        Mapa miMapa = (Mapa)d;
                        extension += miMapa.Superficie;
                    }
                    resumen += $"{d}\n";
                    cantidad++;
                }
            }
        }

        /// <summary>
        /// Muestra los documentos distribuidos en escáner.
        /// </summary>
        /// <param name="e">El escáner.</param>
        /// <param name="extension">La extensión total de los documentos distribuidos.</param>
        /// <param name="cantidad">La cantidad de documentos distribuidos.</param>
        /// <param name="resumen">Un resumen de los documentos distribuidos.</param>
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);

        }

        /// <summary>
        /// Muestra los documentos En Escaner.
        /// </summary>
        /// <param name="e">El escáner.</param>
        /// <param name="extension">La extensión total de los documentos en Escaner.</param>
        /// <param name="cantidad">La cantidad de documentos en Escaner.</param>
        /// <param name="resumen">Un resumen de los documentos en Escaner.</param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos En Revision del escaner.
        /// </summary>
        /// <param name="e">El escáner.</param>
        /// <param name="extension">La extensión total de los documentos En Revision del escaner.</param>
        /// <param name="cantidad">La cantidad de documentos En Revision del escaner.</param>
        /// <param name="resumen">Un resumen de los documentos En Revision del escaner.</param>
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra los documentos Terminados.
        /// </summary>
        /// <param name="e">El escáner.</param>
        /// <param name="extension">La extensión total de los documentos Terminados.</param>
        /// <param name="cantidad">La cantidad de documentos Terminados.</param>
        /// <param name="resumen">Un resumen de los documentos Terminados.</param>
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}

