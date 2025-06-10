using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea_2.Models;

namespace Tarea_2.Controllers
{
    public class TrianguloController : Controller
    {
        public ActionResult Index()
        {
            return View(new Triangulo());
        }

        [HttpPost]
        public ActionResult Index(Triangulo t)
        {
            if (!ModelState.IsValid)
                return View(t);

            // Validación de desigualdad triangular
            double[] lados = { t.a, t.b, t.c };
            Array.Sort(lados);
            if (lados[0] + lados[1] <= lados[2])
            {
                ModelState.AddModelError("", "La suma de los dos lados menores debe ser mayor que el mayor para cumplir la desigualdad triangular. ");
                return View(t);
            }

            t.Perimetro = t.a + t.b + t.c;
            t.Semiperimetro = t.Perimetro / 2;
            t.Area = Math.Sqrt(t.Semiperimetro *
                               (t.Semiperimetro - t.a) *
                               (t.Semiperimetro - t.b) *
                               (t.Semiperimetro - t.c));

            if (t.a == t.b && t.b == t.c)
                t.Tipo = "Equilátero";
            else if (t.a == t.b || t.a == t.c || t.b == t.c)
                t.Tipo = "Isósceles";
            else
                t.Tipo = "Escaleno";

            // Cálculo de ángulos con Ley de Cosenos
            t.AnguloAlpha = CalcularAngulo(t.b, t.c, t.a);
            t.AnguloBeta = CalcularAngulo(t.a, t.c, t.b);
            t.AnguloGamma = CalcularAngulo(t.a, t.b, t.c);

            return View(t);
        }

        private double CalcularAngulo(double x, double y, double opuesto)
        {
            double cos = (x * x + y * y - opuesto * opuesto) / (2 * x * y);
            return Math.Acos(cos) * (180 / Math.PI);
        }
    }
}