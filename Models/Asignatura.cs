namespace problema_3.Models
{
    public class Asignatura
    {
        public string Nombre { get; set; } = string.Empty;
        public List<Prueba> Pruebas { get; set; } = new List<Prueba>();
        public List<Alumno> Alumnos { get; set; } = new List<Alumno>();

        public void AgregarPrueba(Prueba prueba)
        {
            Pruebas.Add(prueba);
        }

        public void CalcularNotaFinal()
        {
            // Lógica para calcular la nota final de los alumnos en la asignatura
        }

        
    }
}