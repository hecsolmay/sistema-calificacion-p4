using problema_3.Presenter;

namespace problema_3.View.Pruebas
{
    public class PruebasView : IPrueba
    {
        int windowWith = Console.WindowWidth;
        PruebaPresenter pruebaPresenter = new PruebaPresenter();
        string[] tareas = {
            "Crear Prueba",
            "Agregar SubPrueba",
            "Listar Pruebas",
            "Mostrar Nota",
            "Mostrar Nota Alumno",
            "Registrar Alumno a la Prueba",
            "Concluir Prueba",
            "Detalles de prueba",
            "Regresar"
        };
        public void AgregarPrueba()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Crear Prueba =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");

            Console.Write("Nota Maxima: ");

            if (!int.TryParse(Console.ReadLine(), out int max))
            {
                Console.WriteLine("La nota maxima debe ser un numero, Intentelo de nuevo presione enter para continuar");
                Console.ReadKey();
                return;
            }

            pruebaPresenter.AgregarPrueba(new Prueba
            {
                NotaMaxima = max
            });

            Console.WriteLine("Prueba Creada");
            Console.ReadKey();
        }

        public void AgregarSubPrueba()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Dame el Identificador de la prueba =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");

            Console.Write("Id: ");
            string id = Console.ReadLine() ?? "";
            var prueba = pruebaPresenter.ObtenerPrueba(id);

            if (prueba is null)
            {
                Console.WriteLine("Prueba no encontrada, Intentalo de nuevo presiona enter para continuar");
                Console.ReadKey();
                return;
            }

            Console.Write("\nNota Maxima de la subprueba: ");

            if (!int.TryParse(Console.ReadLine(), out int max))
            {
                Console.WriteLine("La nota Maxima debe ser un numero, intentalo de nuevo Presiona enter para continuar");
                Console.ReadKey();
                return;
            }


            prueba.AgregarSubPrueba(new Prueba { NotaMaxima = max });
            // pruebaPresenter

            Console.WriteLine("SubPrueba Agregada");
            Console.ReadKey();
        }

        public void DetallesPrueba()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Dame el Identificador de la prueba =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");

            Console.Write("Id: ");
            string id = Console.ReadLine() ?? "";
            var prueba = pruebaPresenter.ObtenerPrueba(id);

            if (prueba is null)
            {
                Console.WriteLine("Prueba no encontrada, Intentalo de nuevo presiona enter para continuar");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Detalles de la prueba =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");
            prueba.MostrarDetalles();
            Console.ReadKey();
        }

        public void ListarPruebas()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Lista de Pruebas =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");
            pruebaPresenter.ListarPruebas();
            Console.ReadKey();
        }

        public void MostrarNota()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Dame el Identificador de la prueba =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");

            Console.Write("Id: ");

            try
            {
                string id = Console.ReadLine() ?? "";
                var prueba = pruebaPresenter.ObtenerPrueba(id);

                if (prueba is null)
                {
                    Console.WriteLine("No se encontro la prueba, Intentalo de nuevo");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine($"La nota maxima es: {prueba.CalcularNota()}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public void MostrarNotaAlumno()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Dame el Identificador de la prueba =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");

            Console.Write("Id: ");
            string id = Console.ReadLine() ?? "";
            Console.Write("Id del Alumno: ");
            string idAlumno = Console.ReadLine() ?? "";

            Console.ReadKey();
        }

        public void RegistrarNotaAlumno()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Dame el Identificador de la prueba =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");

            Console.Write("Id: ");
            string id = Console.ReadLine() ?? "";
            Console.Write("Id del Alumno: ");
            string idAlumno = Console.ReadLine() ?? "";
            Console.Write("Nota del Alumno: ");

            if (!int.TryParse(Console.ReadLine(), out int nota))
            {
                Console.WriteLine("La calificacion debe ser un numero Intentelo de nuevo presione enter para continuar");
                Console.ReadKey();
                return;
            }

            Console.ReadKey();
        }

        public void SelectTask()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("".PadRight(windowWith, '*'));
                Console.WriteLine("====== Seccion Pruebas =".PadRight(windowWith, '='));
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

                if (option == tareas.Length) break;

                switch (option)
                {
                    case 1:
                        AgregarPrueba();
                        break;
                    case 2:
                        AgregarSubPrueba();
                        break;
                    case 3:
                        ListarPruebas();
                        break;
                    case 4:
                        MostrarNota();
                        break;
                    case 5:
                        MostrarNotaAlumno();
                        break;
                    case 6:
                        RegistrarNotaAlumno();
                        break;
                    case 7:
                        TerminarPrueba();
                        break;
                    case 8:
                        DetallesPrueba();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }

            };

        }

        public void TerminarPrueba()
        {
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Dame el Identificador de la prueba =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");

            Console.Write("Id: ");
            string id = Console.ReadLine() ?? "";

            Console.ReadKey();
        }
    }
}