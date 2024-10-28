using DesafioFast.Interfaces;
using DesafioFast.models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColaboradorController : ControllerBase
    {
        readonly ColaboradorInterface _colaboradorInterface;

        public ColaboradorController(ColaboradorInterface _colaboradorInterface)
        {
            this._colaboradorInterface = _colaboradorInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ColaboradorModel>>>> GetAllColaboradores()
        {
            ServiceResponse<List<ColaboradorModel>> response = await _colaboradorInterface.GetAllColaboradores();
            
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ColaboradorModel>>> PostColaborador(ColaboradorModel colaborador)
        {
            ServiceResponse<ColaboradorModel> response = await _colaboradorInterface.PostColaborador(colaborador);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ColaboradorModel>>> GetOneColaborador(int id)
        {
            ServiceResponse<ColaboradorModel> response = await _colaboradorInterface.GetOneColaborador(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<ColaboradorModel>>> PutColaborador(ColaboradorModel updateColaborador)
        {
            ServiceResponse<ColaboradorModel> response = await _colaboradorInterface.PutColaborador(updateColaborador);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<ColaboradorModel>>> DeleteColaborador(int id)
        {
            ServiceResponse<ColaboradorModel> response = await _colaboradorInterface.DeleteColaborador(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
