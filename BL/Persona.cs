using Microsoft.EntityFrameworkCore;
using ML;

namespace BL;

public class Persona
{
    public static Result Add(ML.Persona persona)
    {
        Result result = new();
        try
        {
            using DL.JsanchezCrudPersonasContext context = new();

            var query = context.Database.ExecuteSql($"PersonaAdd {persona.Nombre},{persona.ApellidoPaterno},{persona.ApellidoMaterno}");
            if (query >= 1)
            {
                result.Correct = true;
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "No se inserto el registro";
            }
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
            result.Ex = ex;
        }
        return result;
    }

    public static Result Update(ML.Persona persona)
    {
        Result result = new();
        try
        {
            using DL.JsanchezCrudPersonasContext context = new();

            var query = context.Database.ExecuteSql($"PersonaUpdate {persona.IdPersona},{persona.Nombre},{persona.ApellidoPaterno},{persona.ApellidoMaterno}");
            if (query >= 1)
            {
                result.Correct = true;
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "No se actualizo el registro";
            }
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
            result.Ex = ex;
        }
        return result;
    }

    public static Result Delete(int IdPersona)
    {
        Result result = new();
        try
        {
            using DL.JsanchezCrudPersonasContext context = new();

            var query = context.Database.ExecuteSql($"PersonaDelete {IdPersona}");
            if (query >= 1)
            {
                result.Correct = true;
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "No se inactivo el registro";
            }
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
            result.Ex = ex;
        }
        return result;
    }

    public static Result GetAll()
    {
        Result result = new();
        try
        {
            using DL.JsanchezCrudPersonasContext context = new();

            var query = context.Personas.FromSqlRaw("PersonaGetAll").ToList();
            result.Objects = [];
            if (query != null)
            {
                foreach (var item in query)
                {
                    ML.Persona persona = new()
                    {
                        IdPersona = item.Idpersona,
                        Nombre = item.Nomrre,
                        ApellidoPaterno = item.Apellidopaterno,
                        ApellidoMaterno = item.Apellidomaterno
                    };
                    result.Objects.Add(persona);
                }
                result.Correct = true;
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrió un error al realizar la consulta";
            }
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
            result.Ex = ex;
        }
        return result;
    }

    public static Result GetById(int IdPersona)
    {
        Result result = new();
        try
        {
            using DL.JsanchezCrudPersonasContext context = new();

            var query = context.Personas.FromSql($"PersonaGetById {IdPersona}").AsEnumerable().FirstOrDefault();
            if (query != null)
            {
                var item = query;
                result.Object = new();
                ML.Persona persona = new()
                {
                    IdPersona = item.Idpersona,
                    Nombre = item.Nomrre,
                    ApellidoPaterno = item.Apellidopaterno,
                    ApellidoMaterno = item.Apellidomaterno
                };
                result.Object = persona;
                result.Correct = true;
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrió un error al realizar la consulta";
            }
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
            result.Ex = ex;
        }
        return result;
    }
}
