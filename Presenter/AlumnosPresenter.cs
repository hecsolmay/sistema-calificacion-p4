namespace problema_3.Presenter
{
    public class AlumnosPresenter
    {
        List<Alumno> alumnos = new List<Alumno>();

        public void ListarAlumnos ()
        {
            if (alumnos.Count == 0)
            {
                Console.WriteLine("No hay Alumnos");
                return;
            }

            for (int i = 0; i < alumnos.Count; i++)
            {
                Console.WriteLine($"{i + 1}.- {alumnos[i].Nombre}");
            }
        }

        public void CrearAlumno (string nombre) {
            Alumno newAlumno = new Alumno {Nombre = nombre.Trim().ToLower()};
            alumnos.Add(newAlumno);
        }
    }
}