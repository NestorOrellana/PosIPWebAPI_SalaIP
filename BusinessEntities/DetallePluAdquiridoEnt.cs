namespace BusinessEntities
{
    //Entidad detalle plu adquirido
    public class DetallePluAdquiridoEnt
    {
        public int IdDetalle { get; set; }
        public long IdProducto { get; set; }
        public double Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int IdDetalleFactura { get; set; }
    }
}
