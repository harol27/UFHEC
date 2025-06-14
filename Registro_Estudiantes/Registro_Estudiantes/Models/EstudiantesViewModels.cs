using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using Microsoft.AspNetCore.Mvc.Rendering; 


namespace Registro_Estudiantes.Models
{
    public class EstudiantesViewModels
    {
        
        public EstudiantesViewModels()
        {
            opcionescarrera = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = " selecciona una carrera "},
                new SelectListItem { Value = "IngenieriaSoftware", Text = "Ingenieria de Software"},
                new SelectListItem { Value = "Derecho", Text = "Derecho"},
                new SelectListItem { Value = "Medicina", Text = "Medicina"},
                new SelectListItem { Value = "Arquitectura", Text = "Arquitectura"}
            };

            Opcionesturno = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = " selecciona un turno "},
                new SelectListItem { Value = "manana", Text = " mañana "},
                new SelectListItem { Value = "tarde", Text = " tarde "},
                new SelectListItem { Value = "noche", Text = " noche "},
            };

            Opcionestipoingreso = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = " selecciona un tipo de ingreso "},
                new SelectListItem { Value = "nuevo", Text = " nuevo ingreso "},
                new SelectListItem { Value = "transferencia", Text = " transferencia "},
                new SelectListItem { Value = "reingreso", Text = " reingreso "},
            };
        }


        [Required(ErrorMessage = "la matricula es obligatoria ")
            , StringLength(15, MinimumLength = 5, ErrorMessage = "la matricula tiene que tener 8 numero"),
            Display(Name = "Matricula")]
       
        public string Matricula { get; set; } 

        [Required(ErrorMessage = " tu nombre es obligatorio"),
            Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electronico es obligatorio."),
            EmailAddress(ErrorMessage = "Tu correo electronico no es correcto"),
            Display(Name = "correo electronico ")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "la fecha de nacimento es obligatoria."),
            DataType(DataType.Date, ErrorMessage = "la fecha es incorecta ."),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), 
            Display(Name = "fecha de nacimiento")]
        public DateTime Edad { get; set; } 

        [Required(ErrorMessage = "la carrera es obligatorio."), Display(Name = "Carrera")]
        public string carrera { get; set; } 
        public List<SelectListItem> opcionescarrera { get; set; } 


        [Required(ErrorMessage = "por favor, el telefono. ")
            , Phone(ErrorMessage = "Tu telefono no es correcto. "),
            StringLength(10, MinimumLength = 10, ErrorMessage = " Son 10 numero, no 5 animal"),
            Display(Name = "telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = " selecciona un genero por favor."),
            Display(Name = "genero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Toma un turno por favor."),
            Display(Name = "turno")]
        public string Turno { get; set; }
        public List<SelectListItem> Opcionesturno { get; set; } 

        [Required(ErrorMessage = "Eres nuevo si o no?"),
            Display(Name = "tipo de ingreso")]
        public string TipoIngreso { get; set; }
        public List<SelectListItem> Opcionestipoingreso { get; set; } 

        [Display(Name = "...?")]
     
        public bool EstaBecado { get; set; } 

        [Range(0, 100, ErrorMessage = "El porcentaje tiene que ser arriba del promedio ."),
            Display(Name = "porcentaje de beca")]
        public int? PorcentajeBeca { get; set; }

        [Required(ErrorMessage = "Firma para recibir la rumeracion economica ."),
            Range(typeof(bool), "true", "true", ErrorMessage = "..."),
            Display(Name = " acepta lo termino y condiciones ")]

        public bool TerminosYCondiciones { get; set; } 
    }
}