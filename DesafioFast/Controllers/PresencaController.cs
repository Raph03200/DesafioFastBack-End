using DesafioFast.Interfaces;
using DesafioFast.models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresencaController : ControllerBase
    {
        readonly PresencaInterface _presencaInterface;
        public PresencaController(IPresencaInterface _presencaInterface)
        {
            this._presencaInterface = _presencaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PresencaModel>>>> GetAllPresencas()
        {
            ServiceResponse<List<PresencaModel>> response = await _presencaInterface.GetAllPresencas();

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PresencaModel>>> GetOnePresenca(int id)
        {
            ServiceResponse<PresencaModel> response = await _presencaInterface.GetOnePresenca(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<PresencaModel>>> PutPresenca(PresencaModel updatePresenca)
        {
            ServiceResponse<PresencaModel> response = await _presencaInterface.PutPresenca(updatePresenca);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<PresencaModel>>> DeletePresenca(int id)
        {
            ServiceResponse<PresencaModel> response = await _presencaInterface.DeletePresenca(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}/AddColaborador")]
        public async Task<ActionResult<ServiceResponse<ColaboradorModel>>> AddColaborador(int colaborador_Id, int id)
        {
            ServiceResponse<ColaboradorModel> response = await _presencaInterface.AddColaborador(colaborador_Id, id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}/RemoveColaborador")]
        public async Task<ActionResult<ServiceResponse<ColaboradorModel>>> RemoveColaborador(int colaborador_Id, int id)
        {
            ServiceResponse<ColaboradorModel> response = await _presencaInterface.RemoveColaborador(colaborador_Id, id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetAllColaboradoresInWorkshop/{workshopId}")]
        public async Task<ActionResult<ServiceResponse<List<ColaboradorModel>>>> GetAllColaboradoresInWorkshop(int workshop_Id)
        {
            ServiceResponse<List<ColaboradorModel>> response = await _presencaInterface.GetAllColaboradorsInWorkshop(workshop_Id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
