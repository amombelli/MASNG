namespace Empleados.Clases
{
    class Chofer:Empleado
    {
        private char Licencia { get; set; }

        public Chofer(string claveChofer, string nombreChofer, int edadChofer, char licenciaChofer)
            : base(claveChofer, nombreChofer, edadChofer)
        {
            this.Licencia = licenciaChofer;
        }
    }
}
