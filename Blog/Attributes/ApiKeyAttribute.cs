using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Attributes;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)] //Aqui indica que será valido para classes e métodos
public class ApiKeyAttribute : Attribute, IAsyncActionFilter //Um atributo é uma classe que herda de Attribute e Implementa IAsyncActionFilter
                                                        //É literalmente um Filtro que ira executar durante o Runtime da execução quando um determinado evento acontecer
{
    public async Task OnActionExecutionAsync( //Esse é o metodo que iremos usar
        ActionExecutingContext context, 
        ActionExecutionDelegate next)
    {   //Caso não encontre a query, retorna 401           //Esse configuration está esperando um "?api_key" na url
        if (!context.HttpContext.Request.Query.TryGetValue(Configuration.ApiKeyName, out var extractedApiKey)) //Aqui ele ira tentar pegar o valor, caso ele consiga, ele ira usar
        {                         //Esse query é quando passamos valor na URL.          ||||                     out var para criar uma variável dessa chave, se não, executar o if
            context.Result = new ContentResult()
            {
                StatusCode = 401,
                Content = "ApiKey não encontrada"
            };
            return;
        }
        //Caso a query não seja igual a ApiKey, retorna 403
        if (!Configuration.ApiKey.Equals(extractedApiKey)) //Se extractedApiKey for diferente do Configuration.ApiKey, ele executa o if
        {
            context.Result = new ContentResult()
            {
                StatusCode = 403,
                Content = "Acesso não autorizado"
            };
            return;
        }

        await next(); //Caso de tudo certo, use next(), que ira continuar a execução do Código
    }
}