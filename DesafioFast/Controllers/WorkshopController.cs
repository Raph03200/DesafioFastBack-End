using DesafioFast.Interfaces;
using DesafioFast.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesafioFast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkshopController : ControllerBase
    {
        readonly WorkshopInterface _workshopInterface;
        public WorkshopController(WorkshopInterface _workshopInterface)
        {
            this._workshopInterface = _workshopInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<WorkshopModel>>>> GetAllWorkshops()
        {
            ServiceResponse<List<WorkshopModel>> response = await _workshopInterface.GetAllWorkshops();

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<WorkshopModel>>> PostWorkshop( WorkshopModel workshop)
        {
            ServiceResponse<WorkshopModel> response = await _workshopInterface.PostWorkshop(workshop);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<WorkshopModel>>> GetOneWorkshops(int id)
        {
            ServiceResponse<WorkshopModel> response = await _workshopInterface.GetOneWorkshop(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<WorkshopModel>>> PutWorkshop(WorkshopModel updateWorkshop)
        {
            ServiceResponse<WorkshopModel> response = await _workshopInterface.PutWorkshop(updateWorkshop);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<WorkshopModel>>> DeleteWorkshops(int id)
        {
            ServiceResponse<WorkshopModel> response = await _workshopInterface.DeleteWorkshop(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


    }
}
