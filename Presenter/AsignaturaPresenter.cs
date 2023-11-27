using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace problema_3.Presenter
{
    public class AsignaturaPresenter
    {
        List<Asignatura> asignaturas = new List<Asignatura>();

        public void AgregarAsignatura(Asignatura asignatura)
        {
            asignaturas.Add(asignatura);
        }

        public void ListarAsignaturas()
        {
            if (asignaturas.Count == 0)
            {
                Console.WriteLine("No hay asignaturas");
                return;
            }

            for (int i = 0; i < asignaturas.Count; i++)
            {
                Console.WriteLine($"{i + 1}.- {asignaturas[i].Nombre}");
            }
        }

        public Asignatura? ObtenerAsignatura (string nombre) {
            return asignaturas.FirstOrDefault(x => x.Nombre.Trim().ToLower() == nombre.Trim().ToLower());
        }
    }
}