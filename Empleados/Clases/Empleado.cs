namespace Empleados.Clases
{
    class Empleado
    {
        private string Clave { get; set; }
        private string Nombre { get; set; }
        private int Edad { get; set; }


        public Empleado(string claveEmpleados, string nombreEmpleado, int edadEmpleado)
        {
            this.Clave = claveEmpleados;
            this.Nombre = nombreEmpleado;
            this.Edad = edadEmpleado;
        }

  
    }
}
