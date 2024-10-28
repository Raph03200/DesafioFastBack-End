using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFast.models;

namespace DesafioFast.Interfaces
{
    public interface ColaboradorInterface
    {
        Task<ServiceResponse<List<ColaboradorModel>>> GetAllColaboradores();
        Task<ServiceResponse<ColaboradorModel>> GetOneColaborador(int id);
        Task<ServiceResponse<ColaboradorModel>> PostColaborador(ColaboradorModel colaborador);
        Task<ServiceResponse<ColaboradorModel>> PutColaborador(ColaboradorModel updateColaborador);
        Task<ServiceResponse<ColaboradorModel>> DeleteColaborador(int id);
    }
}