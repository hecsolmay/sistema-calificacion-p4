using problema_3.Presenter;

namespace problema_3.View.Asignatura
{
    public class AsignaturaViewHome : IAsignatura
    {
        AsignaturaPresenter presenter = new AsignaturaPresenter();

        string[] tareas = { "Crear Asignatura", "Ver Asignaturas", "Agregar Prueba", "Regresar" };
        int windowWith = Console.WindowWidth;

        public void AgregarPrueba()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Escribe el identificador de la Asignatura =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");

            Console.Write("Asignatura: ");
            string nombre = Console.ReadLine() ?? "";

            var asignatura = presenter.ObtenerAsignatura(nombre);

            if (asignatura == null)
            {
                Console.WriteLine("Asignatura no encontrada");
                Console.ReadKey();
                return;
            }

            Console.Write("Nota Maxima: ");
            if (!int.TryParse(Console.ReadLine(), out int max))
            {
                Console.WriteLine("Opcion no valida, Intentelo de nuevo presione enter para continuar");
                Console.ReadKey();
                return;
            }

            asignatura.AgregarPrueba(new Models.Prueba
            {
                NotaMaxima = max
            });

            Console.WriteLine("Prueba Creada");
            Console.ReadKey();
        }

        public void CrearAsignatura()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Dame el nombre de la Asignatura =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");

            Console.Write("Asignatura: ");

            string asignatura = Console.ReadLine() ?? "";
            presenter.AgregarAsignatura(new Models.Asignatura
            {
                Nombre = asignatura
            });

            Console.WriteLine("Asignatura Creada");
            Console.ReadKey();
        }

        public void ListarAsignaturas()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Lista de asignaturas =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");
            presenter.ListarAsignaturas();
            Console.ReadKey();
        }

        public void SelectTask()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("".PadRight(windowWith, '*'));
                Console.WriteLine("====== Seccion Asignaturas =".PadRight(windowWith, '='));
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

                if (option == 4) break;

                switch (option)
                {
                    case 1:
                        CrearAsignatura();
                        break;
                    case 2:
                        ListarAsignaturas();
                        break;
                    case 3:
                        AgregarPrueba();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }

            };

        }
    }
}