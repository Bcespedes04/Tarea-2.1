using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tarea_2.Models
{
    public class Triangulo
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El lado a debe ser mayor que 0")]
        public double a { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El lado b debe ser mayor que 0")]
        public double b { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El lado c debe ser mayor que 0")]
        public double c { get; set; }

        // Resultados calculados
        public double Perimetro { get; set; }
        public double Semiperimetro { get; set; }
        public double Area { get; set; }
        public string Tipo { get; set; }
        public double AnguloAlpha { get; set; }
        public double AnguloBeta { get; set; }
        public double AnguloGamma { get; set; }
    }
}
