using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFast.models;

namespace DesafioFast.Interfaces
{
    public interface PresencaInterface
    {
        Task<ServiceResponse<List<PresencaModel>>> GetAllPresencas();
        Task<ServiceResponse<PresencaModel>> GetOnePresenca(int id);
        Task<ServiceResponse<PresencaModel>> PutPresenca(PresencaModel presenca);
        Task<ServiceResponse<PresencaModel>> DeletePresenca(int id);
        Task<ServiceResponse<ColaboradorModel>> AddColaborador(int colaboradorId, int presencaId);
        Task<ServiceResponse<ColaboradorModel>> RemoveColaborador(int colaboradorId, int presencaId);
        Task<ServiceResponse<List<ColaboradorModel>>> GetAllColaboradoresInWorkshop( int workshopId);

    }
}
