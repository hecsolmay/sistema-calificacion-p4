using problema_3.Presenter;

namespace problema_3.View.Alumnos
{
    public class AlumnosView : IAlumnos
    {
        int windowWith = Console.WindowWidth;
        string[] tareas = { "Crear Alumno", "Listar Alumnos", "Regresar" };
        AlumnosPresenter alumnosPresenter = new AlumnosPresenter();
        public void CrearAlumno()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Dame el nombre del Alumno =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");

            Console.Write("Alumno: ");

            string nombre = Console.ReadLine() ?? "";
            alumnosPresenter.CrearAlumno(nombre);
            Console.WriteLine("Alumno Creado");
            Console.ReadKey();
        }

        public void ListarAlumnos()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Lista de Alumno =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");
            alumnosPresenter.ListarAlumnos();
            Console.ReadKey();
        }

        public void SelectTask()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("".PadRight(windowWith, '*'));
                Console.WriteLine("====== Seccion Alumnos =".PadRight(windowWith, '='));
                Console.WriteLine("".PadRight(windowWith, '*'));
                Console.WriteLine("\n");
                Console.WriteLine("Selecciona una opcion:\n");

                for (int i = 0; i < tareas.Length; i++)
                {
                    var tarea = tareas[i];
                    Console.WriteLine($"{i + 1}.- {tarea}");
                }

                Console.Write("\nOpcion: ");

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Opcion no valida, Intentelo de nuevo presione enter para continuar");
                    Console.ReadKey();
                    continue;
                }

                if (option <= 0 || option > tareas.Length)
                {
                    Console.WriteLine("Opcion no valida, Intentelo de nuevo presione enter para continuar");
                    Console.ReadKey();
                    continue;
                }

                if (option == 3) break;

                switch (option)
                {
                    case 1:
                        CrearAlumno();
                        break;
                    case 2:
                        ListarAlumnos();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }

            };
        }
    }
}