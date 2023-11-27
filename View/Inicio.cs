using problema_3.View.Alumnos;
using problema_3.View.Asignatura;
using problema_3.View.Pruebas;

namespace problema_3.View
{
    public class Inicio : IView
    {
        string[] opciones = {"Ir a los Alumnos", "Is a Asignaturas", "Ir a Pruebas", "Salir"};
        
        public bool MostrarInicio()
        {
            int windowWith = Console.WindowWidth;
            Console.Clear();
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("====== Hola Bienvenido ¿Que deseas Hacer? =".PadRight(windowWith, '='));
            Console.WriteLine("".PadRight(windowWith, '*'));
            Console.WriteLine("\n");


            for (int i = 0; i < opciones.Length; i++)
            {
                var opcion = opciones[i];
                Console.WriteLine($"{i + 1}.- {opcion}");
            }

            Console.WriteLine("\n");
            Console.Write("Opcion: ");
            if (!int.TryParse(Console.ReadLine(), out int option)) {
                Console.WriteLine("Opcion no valida, Intentelo de nuevo presione enter para continuar");
                Console.ReadKey();
                return true;
            }

            if (option <= 0 || option > opciones.Length)
            {
                Console.WriteLine("Opcion no valida, Intentelo de nuevo presione enter para continuar");
                Console.ReadKey();
                return true;
            }

            if (option == 4) return false;
            

            SwitchCase(option);
            
            return true;
        }

        private void SwitchCase (int option) {
            AsignaturaViewHome asignaturaView = new AsignaturaViewHome();
            AlumnosView alumnosView = new AlumnosView();
            PruebasView pruebasView = new PruebasView();
            
            switch (option)
            {
                case 1: 
                    alumnosView.SelectTask();
                    break;
                case 2:
                    asignaturaView.SelectTask();
                    break;
                case 3:
                    pruebasView.SelectTask();
                    break;
                default:
                    throw new Exception("Opcion no valida");
            }
        }
    }
}