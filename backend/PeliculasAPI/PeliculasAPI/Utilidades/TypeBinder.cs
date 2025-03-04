using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace PeliculasAPI.Utilidades
{
    public class TypeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var nombreropiedad = bindingContext.ModelName;
            var valor = bindingContext.ValueProvider.GetValue(nombreropiedad);

            if(valor == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            try
            {
                var tipoDestino = bindingContext.ModelMetadata.ModelType;
                var valorDeserializado = JsonSerializer.Deserialize(valor.FirstValue!,
                    tipoDestino, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                bindingContext.Result = ModelBindingResult.Success(valorDeserializado);
            }
            catch
            {
                bindingContext.ActionContext.ModelState.TryAddModelError(nombreropiedad, "El valor dado no es del tipo adecuado");
            }

            return Task.CompletedTask;
        }
    }
}
