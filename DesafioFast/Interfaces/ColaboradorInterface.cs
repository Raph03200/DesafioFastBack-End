using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFast.models;

namespace DesafioFast.Interfaces
{
    public interface ColaboradorInterface
    {
        Task<ResponseModel<List<ColaboradorModel>>> GetAllColaboradores();
        Task<ResponseModel<ColaboradorModel>> GetOneColaborador(int id);
        Task<ResponseModel<ColaboradorModel>> PostColaborador(ColaboradorModel colaborador);
        Task<ResponseModel<ColaboradorModel>> PutColaborador(ColaboradorModel updateColaborador);
        Task<ResponseModel<ColaboradorModel>> DeleteColaborador(int id);
    }
}