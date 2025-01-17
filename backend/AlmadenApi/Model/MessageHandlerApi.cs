using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmadenApi.Model
{
    public class MessageHandlerApi<T>
    {
        public bool Success { get; set; }  // Indica se a operação foi bem-sucedida
            public string Message { get; set; }  // Mensagem de sucesso ou erro
            public T Data { get; set; }  // Dados adicionais (opcional)
    }
}