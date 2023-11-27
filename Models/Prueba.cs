namespace problema_3.Models
{
    public class Prueba
    {
        private string _identificador = string.Empty;

        private int _notaMaxima = 0;

        public string Identificador { get; set; } = Random.Shared.Next(1000).ToString();
        public int NotaMaxima
        {
            get => _notaMaxima;
            set
            {
                if ((value >= 0) && (value <= 10))
                {
                    _notaMaxima = value;
                }
                else
                {
                    _notaMaxima = 0;
                }
            }
        }
        public List<Prueba> Subpruebas { get; set; } = new List<Prueba>();
        public Dictionary<Alumno, int> NotasAlumnos { get; set; } = new Dictionary<Alumno, int>();
        public bool Concluida { get; set; } = false;

        public void RegistrarNotaAlumno(Alumno alumno, int nota)
        {
            NotasAlumnos[alumno] = nota;
        }

        public int CalcularNota()
        {
            isConcluida();

            return 0;
        }

        public int CalcularNota(Alumno alumno)
        {
            isConcluida();

            var found = NotasAlumnos.Keys.FirstOrDefault(x => x == alumno);

            if (found == null)
            {
                throw new Exception($"Alumno no encontrado en la prueba {Identificador}");
            }


            if (Subpruebas.Count == 0)
            {
                return NotasAlumnos[alumno];
            }

            int suma = Subpruebas.Sum(x => x.CalcularNota(alumno)) + NotasAlumnos[alumno];

            return suma;
        }

        public bool VerificarConclusión()
        {
            // Lógica para verificar si la prueba ha sido concluida
            if (this.Subpruebas.Count == 0)
            {
                return this.Concluida;
            }

            bool isConcluida = this.Subpruebas.TrueForAll(x => x.VerificarConclusión());

            return isConcluida;
        }

        public void AgregarSubPrueba(Prueba subPrueba)
        {
            this.Subpruebas.Add(subPrueba);
        }

        private void isConcluida()
        {
            if (!this.VerificarConclusión())
            {
                throw new Exception("La prueba no ha sido concluida");
            }
        }

        public void MostrarDetalles()
        {
            Console.WriteLine($"Identificador: {Identificador}");
            Console.WriteLine($"Nota Maxima: {NotaMaxima}");
            string icon = Concluida ? "✅" : "❌";
            Console.WriteLine($"Terminada: {icon}");
            Console.WriteLine("Subpruebas: \n");

            for (int i = 0; i < Subpruebas.Count; i++)
            {
                var sub = Subpruebas[i];
                string terminada = sub.Concluida ? "✅" : "❌";
                Console.WriteLine($"id: {sub.Identificador} - Terminada: {terminada} - Nota Maxima: {sub.NotaMaxima}");
            }
        }
    }
}