global using problema_3.Models;
global using problema_3.View;
global using problema_3.Interface;


bool flag = true;
Inicio inicio = new Inicio();

do {

  flag = inicio.MostrarInicio();
  
} while(flag);

Console.WriteLine("Hasta Luego");
