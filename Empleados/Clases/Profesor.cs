namespace Empleados.Clases
{
    class Profesor:Empleado
    {
        private string Escolaridad { get; set; }

        public Profesor(string claveProfesor, string nombreProfesor, int edadProfesor, string escolaridadProfesor)
            : base(claveProfesor, nombreProfesor, edadProfesor)
        {
            this.Escolaridad = escolaridadProfesor;
        }
    }
}
