namespace infraestructure.Models
{
    public class CuentaModel
    {
        public int Id { get; set; }
        public int id_persona { get; set; }
        public string nombre { get; set; }
        public string numero { get; set; }
        public double saldo { get; set; }
        public double limite_saldo { get; set; }
        public double limite_transferencia { get; set; }
        public bool estado { get; set; }
    }
}