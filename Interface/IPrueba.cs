using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace problema_3.Interface
{
    public interface IPrueba
    {
        void AgregarPrueba();
        void AgregarSubPrueba();
        void ListarPruebas();
        void MostrarNota();
        void MostrarNotaAlumno();
        void RegistrarNotaAlumno();
        void TerminarPrueba();
        void DetallesPrueba();
        void SelectTask();
    }
}