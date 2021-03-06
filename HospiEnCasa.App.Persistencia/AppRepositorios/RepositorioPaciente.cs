using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
using System;
using Microsoft.EntityFrameworkCore;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        /// <summary>
        /// Referencia al contexto de Paciente
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioPaciente(AppContext appContext)
        {
            _appContext = appContext;
        }


        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
        {
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;

        }

        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado == null)
                return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes()
        {
            return _appContext.Pacientes;
        }

        Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
        {
            return _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
        }

        Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            if (pacienteEncontrado != null)
            {
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellidos = paciente.Apellidos;
                pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
                pacienteEncontrado.Genero = paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Longitud = paciente.Longitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteEncontrado.Familiar = paciente.Familiar;
                pacienteEncontrado.Enfermera = paciente.Enfermera;
                pacienteEncontrado.Medico = paciente.Medico;
                pacienteEncontrado.Historia = paciente.Historia;

                _appContext.SaveChanges();


            }
            return pacienteEncontrado;
        }

        SignoVital IRepositorioPaciente.AsignSignoVital(int idPaciente, int idSignoVital)
        {
            var pacienteEncontrado = _appContext.Pacientes
            .Where(p => p.Id == idPaciente)
            .Include(p => p.SignosVitales)
            .SingleOrDefault();
            if (pacienteEncontrado != null)
            {
                Console.WriteLine("Paciente encontrado");
                var signoVitalEncontrado = _appContext.SignosVitales.Find(idSignoVital);
                if (signoVitalEncontrado != null)
                {
                    Console.WriteLine(signoVitalEncontrado.Valor);
                    //signoVitalEncontrado.PacienteId = pacienteEncontrado.Id;
                    pacienteEncontrado.SignosVitales.Add(signoVitalEncontrado);
                    _appContext.SaveChanges();
                }
                return signoVitalEncontrado;
            }
            return null;
        }

    }  
}