﻿using System;

namespace BusinessEntities
{
    public class FacturaEEnt
    {
        public string Nit { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Total { get; set; }
        public string Correlativo { get; set; }
        public string NumeroSerie { get; set; }
        public short IdSucursal { get; set; }
        /// <summary>
        /// 1 = Emitida, 0 = Anulada
        /// </summary>
        public short Estado { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public byte EstadoTraslado { get; set; }
        public string TipoPago { get; set; }
        public long NumeroAutorizacion { get; set; }
    }
}
