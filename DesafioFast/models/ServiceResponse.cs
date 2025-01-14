using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFast.models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }
        public String Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}