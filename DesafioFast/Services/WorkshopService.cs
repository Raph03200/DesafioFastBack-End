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
                response.Data = _dataContext.DbWorkshop.ToList();
                response.Message = "Lista de dados retornada";
            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
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
                    response.Message = "Dados não informados corretamente";
                    response.IsSuccess = false;

                    return response;
                }
                WorkshopModel workshopExisting = _dataContext.DbWorkshop.FirstOrDefault(x => x.Name == workshop.Name);
                if( workshopExisting != null)
                {
                    response.Message = "Já existe um workshop com esse nome";
                    response.IsSuccess = false;

                    return response;
                }
                
                await _dataContext.AddAsync(workshop);
                await _dataContext.SaveChangesAsync();
                response.Message = "Workshop salvo no banco";

                int workshopId = _dataContext.DbWorkshop.FirstOrDefault(x => x.Name == workshop.Name).Id;
                RecordModel record = new RecordModel() { WorkshopId = workshopId };

                await _dataContext.AddAsync(record);
                await _dataContext.SaveChangesAsync();
                response.Message += "\nLista de presença criada no banco" ; 

                response.Data = workshop;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
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
                    response.IsSuccess = false;
                    response.Message = "Workshop não existente";

                    return response;
                }
                response.Message = "Dado retornada";
                response.Data = workshop;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
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
                    response.IsSuccess = false;
                    response.Message = "Workshop não existente";

                    return response;
                }
                workshop.Name = updateWorkshop.Name;
                workshop.Description = updateWorkshop.Description;
                workshop.RealizationDate = updateWorkshop.RealizationDate;

                await _dataContext.SaveChangesAsync();

                response.Data = updateWorkshop;
                response.Message = "Dado modificado";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
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
                    response.IsSuccess = false;
                    response.Message = "Workshop não existente";

                    return response;
                }

                _dataContext.DbWorkshop.Remove(workshop);
                await _dataContext.SaveChangesAsync();

                response.Message = "Dado deletado";
                response.Data = workshop;
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
