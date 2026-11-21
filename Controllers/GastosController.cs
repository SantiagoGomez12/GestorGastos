using Microsoft.AspNetCore.Mvc;
using GestorGastos.Models;

namespace GestorGastos.Controllers
{
    public class GastosController : Controller
    {
        private static List<Gasto> gastos = new List<Gasto>();

        private static int contador = 1;

        public IActionResult Index()
        {
            decimal totalMes = 0;

                    foreach (var gasto in gastos)
                    {
                        if (gasto.Fecha.Month == DateTime.Now.Month &&
                            gasto.Fecha.Year == DateTime.Now.Year)
                        {
                            totalMes += gasto.Costo;
                        }
                    }

                ViewBag.TotalMes = totalMes;
                ViewBag.Error = TempData["Error"];

                return View("~/Views/Home/Index.cshtml", gastos);
        }

        [HttpPost]
        public IActionResult Agregar(string descripcion, decimal valor, string categoria)
        {
                    if (string.IsNullOrWhiteSpace(descripcion))
                    {
                        TempData["Error"] = "ERROR: Escribe una descripcion.";
                        return RedirectToAction("Index");
                    }

                    if (valor <= 0)
                    {
                        TempData["Error"] = "ERROR: El valor debe ser mayor a cero.";
                        return RedirectToAction("Index");
                    }

                            Gasto nuevoGasto = new Gasto();

                            nuevoGasto.Id = contador;
                            nuevoGasto.Descripcion = descripcion;
                            nuevoGasto.Costo = valor;
                            nuevoGasto.Categoria = categoria;
                            nuevoGasto.Fecha = DateTime.Now;

                            gastos.Add(nuevoGasto);

                            contador++;

                            return RedirectToAction("Index");
                        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
                    for (int i = 0; i < gastos.Count; i++)
                    {
                        if (gastos[i].Id == id)
                        {
                            gastos.RemoveAt(i);
                            break;
                        }
                    }

                    return RedirectToAction("Index");
        }
    }
}
