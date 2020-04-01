namespace BusinessEntities
{
    public class DetalleFacturaEnt
    {
        //Detalles de factura
        public int IdDetalle { get; set; }
        public decimal PrecioPlu { get; set; }
        public decimal SubTotal { get; set; }
        public string NoSerie { get; set; }
        public string NoCorrelativo { get; set; }
        public int IdPlu { get; set; }
        public short UnidadMedida { get; set; }
        public double Cantidad { get; set; }
    }
}
