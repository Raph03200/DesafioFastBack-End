using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFast.DataContext;
using DesafioFast.Interfaces;
using DesafioFast.models;
using Microsoft.EntityFrameworkCore;

namespace DesafioFast.Services
{
    public class PresencaService : PresencaInterface
    {
        readonly ApplicationDbContext _dataContext;

        public PresencaService(ApplicationDbContext _dataContext)
        {
            this._dataContext = _dataContext;
            
        }

        public async Task<ServiceResponse<List<PresencaModel>>> GetAllPresencas()
        {
            ServiceResponse<List<PresencaModel>> response = new ServiceResponse<List<PresencaModel>>();
            try
            {
                response.Data = await _dataContext.DbPresenca.ToListAsync();
                response.Message = "Lista de dados retornada";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;

        }

        public async Task<ServiceResponse<PresencaModel>> GetOnePresenca(int id)
        {
            ServiceResponse<PresencaModel> response = new ServiceResponse<PresencaModel>();
            try
            {
                PresencaModel presenca = _dataContext.DbPresenca.FirstOrDefault(x => x.Id == id);

                if (presenca == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ata de presença não encontrada";

                    return response;
                }
                response.Message = "Dado retornado";
                response.Data = presenca;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ServiceResponse<PresencaModel>> PutPresenca(PresencaModel updatePresenca)
        {
            ServiceResponse<PresencaModel> response = new ServiceResponse<PresencaModel>();
            try
            {
                PresencaModel presenca = _dataContext.DbPresenca.AsNoTracking().FirstOrDefault(x => x.Id == updatePresenca.Id);

                if (presenca == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ata de presença não encontrada";

                    return response;
                }

                presenca.WorkshopId = updatePresenca.WorkshopId;
                presenca.ColaboradorIds = updatePresenca.ColaboradorIds;

                await _dataContext.SaveChangesAsync();

                response.Data = updatePresenca;
                response.Message = "Dado modificado";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        
        public async Task<ServiceResponse<PresencaModel>> DeletePresenca(int id)
        {
            ServiceResponse<PresencaModel> response = new ServiceResponse<PresencaModel>();
            try
            {
                PresencaModel presenca = _dataContext.DbPresenca.FirstOrDefault(x => x.Id == id);

                if (presenca == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Lista de presença não encontrada";

                    return response;
                }

                _dataContext.DbPresenca.Remove(presenca);
                await _dataContext.SaveChangesAsync();

                response.Message = "Ata deletada";
                response.Data = presenca;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }


        public async Task<ServiceResponse<ColaboradorModel>> AddColaborador(int colaboradorId, int presencaId)
        {
            ServiceResponse<ColaboradorModel> response = new ServiceResponse<ColaboradorModel>();
            try
            {
                PresencaModel presenca = _dataContext.DbPresenca.FirstOrDefault(x => x.Id == presencaId);
                if (presenca == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ata de presença não encontrada";
                    return response;
                }
                if (presenca.ColaboradorIds.IndexOf(colaboradorId) != -1)
                {
                    response.IsSuccess = false;
                    response.Message = "Colaborador já incluso na ata de presença";
                    return response;
                }

                ColaboradorModel colaborador = _dataContext.DbColaborador.FirstOrDefault(x => x.Id == colaboradorId);
                if (colaborador == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Colaborador não encontrado";
                    return response;
                }

                presenca.ColaboradorIds.Add(colaboradorId);
                
                await _dataContext.SaveChangesAsync();

                response.Message = "Colaborador adicionado a Ata de presença";
                response.Data = colaborador;
            }   
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;

        }

        public async Task<ServiceResponse<ColaboradorModel>> RemoveColaborador(int colaboradorId, int presencaId)
        {
            ServiceResponse<ColaboradorModel> response = new ServiceResponse<ColaboradorModel>();
            try
            {
                PresencaModel presenca = _dataContext.DbPresenca.FirstOrDefault(x => x.Id == presencaId);
                if (presenca == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Ata de presença não encontrada";
                    return response;
                }

                ColaboradorModel colaborador = _dataContext.DbColaborador.FirstOrDefault(x => x.Id == colaboradorId);
                if (colaborador == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Colaborador não encontrada";
                    return response;
                }

                presenca.ColaboradorIds.Remove(colaboradorId);

                await _dataContext.SaveChangesAsync();

                response.Message = "Colaborador removido da Ata de presença";
                response.Data = colaborador;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<ColaboradorModel>>> GetAllColaboradoresInWorkshop( int workshopId)
        {
            ServiceResponse<List<ColaboradorModel>> response = new ServiceResponse<List<ColaboradorModel>>();
            try
            {
                List<int> colaboradorIds = _dataContext.DbPresenca.First( x => x.WorkshopId == workshopId).ColaboradorIds;
                List<ColaboradorModel> colaborador = _dataContext.DbColaborador.Where(x => colaboradorIds.Contains(x.Id)).ToList();
                
                response.Data = colaborador;
                response.Message = "Lista de dados retornada";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
