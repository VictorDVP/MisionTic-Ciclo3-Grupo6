using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        private static IRepositorioSignoVital _repoSignoVital = new RepositorioSignoVital(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Entity Framework!");
            //AddPaciente();
            //BuscarPaciente(1);
            //AddSignoVital();
            AsignSignoVital();
            //AsignIdPaciente();
        }

        private static void AddPaciente()
        {
            var paciente = new Paciente{
                Nombre="Juan",
                Apellidos="Perez",
                NumeroTelefono="3001456",
                Genero=Genero.Masculino,
                Direccion="Clle 46 45 67",
                Longitud=5.07062F,
                Latitud=-75.52290F,
                Ciudad="Manizales",
                FechaNacimiento= new DateTime(1990,04,12)
            };
            _repoPaciente.AddPaciente(paciente);
        }

        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine(paciente.Nombre+" "+paciente.Apellidos);
        }

        private static void AddSignoVital()
        {
            var signoVital = new SignoVital{
                
                FechaHora= new DateTime(2021,09,29),
                Valor = 30.01234f,
                Signo = TipoSigno.TemperaturaCorporal

            };
            _repoSignoVital.AddSignoVital(signoVital);
        }

        private static void AsignSignoVital()
        {
            _repoPaciente.AsignSignoVital(1,2);
        }


    }
}
