using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    //entidad Serie Facturañ
    public class ViewFacturaSerieEnt
    {
        public short idSerie { get; set; }
        public string numeroSerie { get; set; }
        public short idRuta { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }
        public string resolucion { get; set; }
        public string datoAdicional1 { get; set; }
        public string datoAdicional2 { get; set; }
        public string datoAdicional3 { get; set; }
        public string datoAdicional4 { get; set; }
        public string datoAdicional5 { get; set; }
        public string datoAdicional6 { get; set; }
        public string datoAdicional7 { get; set; }
        public string datoAdicional8 { get; set; }
        public string datoAdicional9 { get; set; }
        public string datoAdicional10 { get; set; }
        public string datoAdicional11 { get; set; }
        public string DatoAdicional12 { get; set; }
        public long correlativo { get; set; }
        public string estado { get; set; }
        public string nit { get; set; }
        public string nombre { get; set; }
        public string tipo_documento { get; set; }
        public string moneda { get; set; }
        public short? idSeccion { get; set; }
        public long? numeroDel { get; set; }
        public long? numeroAl { get; set; }
        public string SerieNC { get; set; }
        public long? CorrelativoNC { get; set; }
        public long? NumeroReciboCesta { get; set; }
        public byte? idtiposerie { get; set; }
        public string TipoDocumento { get; set; }
        public byte? idestado { get; set; }
        public string EstadoDocumento { get; set; }
    }
}
