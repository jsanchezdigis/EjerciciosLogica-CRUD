using Microsoft.AspNetCore.Mvc;

namespace PL_MVC.Controllers;

public class PersonaController : Controller
{
    [HttpGet]
    public IActionResult GetAll()
    {
        ML.Result result = BL.Persona.GetAll();
        if (result.Correct)
        {
            ML.Persona persona = new()
            {
                Personas = result.Objects
            };
            return View(persona);
        }
        else
        {
            ML.Persona persona = new();
            return View(persona);
        }
    }

    [HttpGet]
    public IActionResult Form(int IdPersona)
    {
        if (IdPersona == 0)
        {
            return View();
        }
        else
        {
            ML.Result result = BL.Persona.GetById(IdPersona);
            if (result.Correct)
            {
                ML.Persona persona = (ML.Persona)result.Object;
                return View(persona);
            }
            else
            {
                ViewBag.Message = "no se encuentra el registro";
                return PartialView("Modal");
            }
        }
    }

    [HttpPost]
    public IActionResult Form(ML.Persona persona)
    {
        if (persona.IdPersona == 0)
        {
            ML.Result result = BL.Persona.Add(persona);
            if (result.Correct)
            {
                ViewBag.Message = "Se inserto correctamente el registro";
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al inserto el registro";
            }
            return PartialView("Modal");
        }
        else
        {
            ML.Result result = BL.Persona.Update(persona);
            if (result.Correct)
            {
                ViewBag.Message = "Se actualizo correctamente el registro";
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al actualizar el registro";
            }
            return PartialView("Modal");
        }
    }

    [HttpGet]
    public IActionResult Delete(int IdPersona)
    {
        ML.Result result = BL.Persona.Delete(IdPersona);
        if (result.Correct)
        {
            ViewBag.Message = "Se inactivo correctamente el registro";
        }
        else
        {
            ViewBag.Message = "Ocurrió un error al inactivar el registro";
        }
        return PartialView("Modal");
    }
}
