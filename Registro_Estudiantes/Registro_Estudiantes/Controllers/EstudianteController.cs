using Microsoft.AspNetCore.Mvc;
using Registro_Estudiantes.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering; 

namespace Registro_Estudiantes.Controllers
{
    public class EstudiantesController : Controller
    {
       
        private static List<EstudiantesViewModels> listaEstudiantes = new List<EstudiantesViewModels>();

        
        public IActionResult Index()
        {
            
            var model = new EstudiantesViewModels();
            return View(model);
        }

        [HttpPost]
        public IActionResult Registrar(EstudiantesViewModels estudiante)
        {
     
            if (estudiante.EstaBecado && (estudiante.PorcentajeBeca == null || estudiante.PorcentajeBeca < 0 || estudiante.PorcentajeBeca > 100))
            {
                ModelState.AddModelError("PorcentajeBeca", "El porcentaje de beca es obligatorio y debe estar entre 0 y 100 si el estudiante está becado.");
            }
            else if (!estudiante.EstaBecado)
            {
              
                estudiante.PorcentajeBeca = null;
            }

            if (listaEstudiantes.Any(e => e.Matricula == estudiante.Matricula))
            {
                ModelState.AddModelError("Matricula", "Ya existe un estudiante con esta matrícula. La matrícula debe ser única.");
            }

       
            if (ModelState.IsValid)
            {
                listaEstudiantes.Add(estudiante); 
                return RedirectToAction("Lista"); 
            }

        
            return View("index", estudiante);
        }


        public IActionResult Lista()
        {
            
            return View(listaEstudiantes);
        }

       
        
        public IActionResult Editar(string matricula)
        {
   
            var estudiante = listaEstudiantes.FirstOrDefault(e => e.Matricula == matricula);

          
            if (estudiante == null)
                return NotFound();


            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Editar(EstudiantesViewModels estudiante)
        {
          

        
            if (estudiante.EstaBecado && (estudiante.PorcentajeBeca == null || estudiante.PorcentajeBeca < 0 || estudiante.PorcentajeBeca > 100))
            {
                ModelState.AddModelError("PorcentajeBeca", "El porcentaje de beca es obligatorio y debe estar entre 0 y 100 si el estudiante está becado.");
            }
            else if (!estudiante.EstaBecado)
            {
                estudiante.PorcentajeBeca = null;
            }

            
            if (ModelState.IsValid)
            {
              
                var original = listaEstudiantes.FirstOrDefault(e => e.Matricula == estudiante.Matricula);

             
                if (original != null)
                {
                 
                    original.Nombre = estudiante.Nombre;
                    original.Correo = estudiante.Correo;
                    original.Telefono = estudiante.Telefono;
                    original.Edad = estudiante.Edad;
                    original.Genero = estudiante.Genero;
                    original.carrera = estudiante.carrera; 
                    original.Turno = estudiante.Turno;
                    original.TipoIngreso = estudiante.TipoIngreso;
                    original.EstaBecado = estudiante.EstaBecado; 
                    original.PorcentajeBeca = estudiante.PorcentajeBeca;
                    original.TerminosYCondiciones = estudiante.TerminosYCondiciones; 
                }
                return RedirectToAction("Lista"); 
            }
            
            return View(estudiante);
        }

        public IActionResult Eliminar(string matricula)
        {
            
            var estudiante = listaEstudiantes.FirstOrDefault(e => e.Matricula == matricula);

            
            if (estudiante != null)
                listaEstudiantes.Remove(estudiante);

            return RedirectToAction("Lista"); 
        }
    }
}