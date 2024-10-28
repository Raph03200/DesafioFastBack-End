using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFast.models;

namespace DesafioFast.Interfaces
{
    public interface PresencaInterface
    {
        Task<ResponseModel<List<PresencaModel>>> GetAllPresencas();
        Task<ResponseModel<PresencaModel>> GetOnePresenca(int id);
        Task<ResponseModel<PresencaModel>> PutPresenca(PresencaModel presenca);
        Task<ResponseModel<PresencaModel>> DeletePresenca(int id);
        Task<ResponseModel<ColaboradorModel>> AddColaborador(int colaboradorId, int presencaId);
        Task<ResponseModel<ColaboradorModel>> RemoveColaborador(int colaboradorId, int presencaId);
        Task<ResponseModel<List<ColaboradorModel>>> GetAllColaboradoresInWorkshop( int workshopId);

    }
}
