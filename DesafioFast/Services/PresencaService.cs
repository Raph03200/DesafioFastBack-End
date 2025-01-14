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
                response.Dados = await _dataContext.DbPresenca.ToListAsync();
                response.Mensagem = "Lista de dados retornada";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
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
                    response.Sucesso = false;
                    response.Mensagem = "Ata de presença não encontrada";

                    return response;
                }
                response.Mensagem = "Dado retornado";
                response.Dados = presenca;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
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
                    response.Sucesso = false;
                    response.Mensagem = "Ata de presença não encontrada";

                    return response;
                }

                presenca.WorkshopId = updatePresenca.WorkshopId;
                presenca.ColaboradorIds = updatePresenca.ColaboradorIds;

                await _dataContext.SaveChangesAsync();

                response.Dados = updatePresenca;
                response.Mensagem = "Dado modificado";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
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
                    response.Sucesso = false;
                    response.Mensagem = "Lista de presença não encontrada";

                    return response;
                }

                _dataContext.DbPresenca.Remove(presenca);
                await _dataContext.SaveChangesAsync();

                response.Mensagem = "Ata deletada";
                response.Dados = presenca;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
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
                    response.Sucesso = false;
                    response.Mensagem = "Ata de presença não encontrada";
                    return response;
                }
                if (presenca.ColaboradorIds.IndexOf(colaboradorId) != -1)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Colaborador já incluso na ata de presença";
                    return response;
                }

                ColaboradorModel colaborador = _dataContext.DbColaborador.FirstOrDefault(x => x.Id == colaboradorId);
                if (colaborador == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Colaborador não encontrado";
                    return response;
                }

                presenca.ColaboradorIds.Add(colaboradorId);
                
                await _dataContext.SaveChangesAsync();

                response.Mensagem = "Colaborador adicionado a Ata de presença";
                response.Dados = colaborador;
            }   
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
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
                    response.Sucesso = false;
                    response.Mensagem = "Ata de presença não encontrada";
                    return response;
                }

                ColaboradorModel colaborador = _dataContext.DbColaborador.FirstOrDefault(x => x.Id == colaboradorId);
                if (colaborador == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Colaborador não encontrada";
                    return response;
                }

                presenca.ColaboradorIds.Remove(colaboradorId);

                await _dataContext.SaveChangesAsync();

                response.Mensagem = "Colaborador removido da Ata de presença";
                response.Dados = colaborador;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
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
                
                response.Dados = colaborador;
                response.Mensagem = "Lista de dados retornada";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }
    }
}
