using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using DesafioFast.DataContext;
using DesafioFast.Interfaces;
using DesafioFast.models;
using Microsoft.EntityFrameworkCore;

namespace DesafioFast.Services
{  
    public class WorkshopService : WorkshopInterface
    {
        readonly ApplicationDbContext _dataContext;
        public WorkshopService(ApplicationDbContext _dataContext)
        {
            this._dataContext = _dataContext;
        }

      public async Task<ServiceResponse<List<WorkshopModel>>> GetAllWorkshops()
        {
            ServiceResponse<List<WorkshopModel>> response = new ServiceResponse<List<WorkshopModel>>();
            try
            {
                response.Dados = _dataContext.DbWorkshop.ToList();
                response.Mensagem = "Lista de dados retornada";
            } catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }
  
        public async Task<ServiceResponse<WorkshopModel>> PostWorkshop( WorkshopModel workshop )
        {
            ServiceResponse<WorkshopModel> response = new ServiceResponse<WorkshopModel>();
            try
            {
                if ( workshop == null )
                {
                    response.Mensagem = "Dados não informados corretamente";
                    response.Sucesso = false;

                    return response;
                }
                WorkshopModel workshopExisting = _dataContext.DbWorkshop.FirstOrDefault(x => x.Nome == workshop.Nome);
                if( workshopExisting != null)
                {
                    response.Mensagem = "Já existe um workshop com esse nome";
                    response.Sucesso = false;

                    return response;
                }
                
                await _dataContext.AddAsync(workshop);
                await _dataContext.SaveChangesAsync();
                response.Mensagem = "Workshop salvo no banco";

                int workshopId = _dataContext.DbWorkshop.FirstOrDefault(x => x.Nome == workshop.Nome).Id;
                PresencaModel record = new PresencaModel() { WorkshopId = workshopId };

                await _dataContext.AddAsync(record);
                await _dataContext.SaveChangesAsync();
                response.Mensagem += "\nLista de presença criada no banco" ; 

                response.Dados = workshop;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public async Task<ServiceResponse<WorkshopModel>> GetOneWorkshop(int id)
        {
            ServiceResponse<WorkshopModel> response = new ServiceResponse<WorkshopModel>();
            try
            {
                WorkshopModel workshop =  _dataContext.DbWorkshop.FirstOrDefault(x => x.Id == id);

                if( workshop == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Workshop não existente";

                    return response;
                }
                response.Mensagem = "Dado retornada";
                response.Dados = workshop;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public async Task<ServiceResponse<WorkshopModel>> PutWorkshop(WorkshopModel updateWorkshop)
        {
            ServiceResponse<WorkshopModel> response = new ServiceResponse<WorkshopModel>();
            try
            {
                WorkshopModel workshop =  _dataContext.DbWorkshop.FirstOrDefault(x => x.Id == updateWorkshop.Id);

                if ( workshop == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Workshop não existente";

                    return response;
                }
                workshop.Nome = updateWorkshop.Nome;
                workshop.Descricao = updateWorkshop.Descricao;
                workshop.DataRealizacao = updateWorkshop.DataRealizacao;

                await _dataContext.SaveChangesAsync();

                response.Dados = updateWorkshop;
                response.Mensagem = "Dado modificado";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }
        public async Task<ServiceResponse<WorkshopModel>> DeleteWorkshop(int id)
        {
            ServiceResponse<WorkshopModel> response = new ServiceResponse<WorkshopModel>();
            try
            {
                WorkshopModel workshop = _dataContext.DbWorkshop.FirstOrDefault(x => x.Id == id);

                if ( workshop == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Workshop não existente";

                    return response;
                }

                _dataContext.DbWorkshop.Remove(workshop);
                await _dataContext.SaveChangesAsync();

                response.Mensagem = "Dado deletado";
                response.Dados = workshop;
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
