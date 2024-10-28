using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFast.DataContext;
using DesafioFast.Interfaces;
using DesafioFast.models;

namespace DesafioFast.Services
{
    public class ColaboradorService : ColaboradorInterface
    {
        readonly ApplicationDbContext _dataContext;
        public ColaboradorService(ApplicationDbContext _dataContext)
        {
            this._dataContext = _dataContext;
        }

        public async Task<ServiceResponse<List<ColaboradorModel>>> GetAllColaboradores()
        {
            ServiceResponse<List<ColaboradorModel>> response = new ServiceResponse<List<ColaboradorModel>>();
            try
            {
                response.Data = _dataContext.DbColaborador.ToList();
                response.Message = "Lista de dados retornada";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ServiceResponse<ColaboradorModel>> PostColaborador(ColaboradorModel colaborador)
        {
            ServiceResponse<ColaboradorModel> response = new ServiceResponse<ColaboradorModel>();
            try
            {
                if (colaborador == null)
                {
                    response.Message = "Dados Inválidos";
                    response.IsSuccess = false;

                    return response;
                }

                _dataContext.Add(colaborador);
                await _dataContext.SaveChangesAsync();

                response.Data = colaborador;
                response.Message = "Dados salvos no banco";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ServiceResponse<ColaboradorModel>> GetOneColaborador(int id)
        {
            ServiceResponse<ColaboradorModel> response = new ServiceResponse<ColaboradorModel>();
            try
            {
                ColaboradorModel colaborador = _dataContext.DbColaborador.FirstOrDefault(x => x.Id == id);
                if (colaborador == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Colaborador não encontrado";

                    return response;
                }
                response.Data = colaborador;
                response.Message = "Dados retornados";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ServiceResponse<ColaboradorModel>> PutColaborador(ColaboradorModel updateColaborador)
        {
            ServiceResponse<ColaboradorModel> response = new ServiceResponse<ColaboradorModel>();
            try
            {
                ColaboradorModel colaborador = _dataContext.DbColaborador.FirstOrDefault(x => x.Id == updateColaborador.Id);
                
                if (colaborador == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Colaborador não encontrado";

                    return response;
                }

                colaborador.Name = updateColaborador.Name;

                await _dataContext.SaveChangesAsync();

                response.Data = updateColaborador;
                response.Message = "Colaborador modificado";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ServiceResponse<ColaboradorModel>> DeleteColaborador(int id)
        {
            ServiceResponse<ColaboradorModel> response = new ServiceResponse<ColaboradorModel>();
            try
            {
                ColaboradorModel colaborador = _dataContext.DbColaborador.FirstOrDefault(x => x.Id == id);
                
                if (colaborador == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Colaborador não encontrado";

                    return response;
                }

                _dataContext.DbColaborador.Remove(colaborador);
                await _dataContext.SaveChangesAsync();

                response.Data = colaborador;
                response.Message = "Colaborador deletado";
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
