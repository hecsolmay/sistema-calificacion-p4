namespace problema_3.Presenter
{
    public class PruebaPresenter
    {
        List<Prueba> pruebas = new List<Prueba>();

        public void ListarPruebas()
        {
            if (pruebas.Count == 0)
            {
                Console.WriteLine("No hay Pruebas");
                return;
            }

            Console.WriteLine($"Identificador - Nota Maxima - Terminada");
            for (int i = 0; i < pruebas.Count; i++)
            {
                var prueba = pruebas[i];
                string icono = prueba.Concluida ? "✅" : "❌";
                Console.WriteLine($"{prueba.Identificador} - {pruebas[i].NotaMaxima} - {icono}");
            }
        }

        public void AgregarPrueba(Prueba prueba)
        {
            pruebas.Add(prueba);
        }

        public Prueba? ObtenerPrueba(string identificador)
        {
            return pruebas.FirstOrDefault(x => x.Identificador == identificador);
        }

        public void RegistrarNotaAlumno(string id, string nombre, int nota) 
        {
            var prueba = pruebas.FirstOrDefault(x => x.Identificador == id);

            if (prueba is null)
            {
                throw new Exception("Prueba no encontrada");
            }

            prueba.RegistrarNotaAlumno(nombre, nota);
        }

        public void TerminarPrueba (string id) 
        {
            var prueba = pruebas.FirstOrDefault(x => x.Identificador == id);

              if (prueba is null)
            {
                throw new Exception("Prueba no encontrada");
            }

            prueba.TerminarPrueba();
        }
    }
}