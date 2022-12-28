using AutoMapper;
using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.Business.BrandModule;
using BigOn.Domain.Models.Dtos.Brand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigOn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public BrandsController(IMediator mediator,
            IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        //[Authorize(Policy = "admin.brands.index")]
        public async Task<IActionResult> Get([FromRoute] BrandsAllQuery query)
        {
            try
            {
                var response = await mediator.Send(query);

                var dtoModel = mapper.Map<List<BrandDto>>(response, cfg =>
                {
                    cfg.Items.AddFromHeader(Request, "dateFormat");
                });
                return Ok(dtoModel);
            }
            catch (Exception)
            {
                //
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] BrandSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NoContent();
            }

            var dtoModel = mapper.Map<BrandDto>(response, cfg =>
            {

                //cfg.Items.Add("dateFormat", format);
                cfg.Items.AddFromHeader(Request, "dateFormat");
            });

            return Ok(dtoModel);
        }


        [HttpPost]
        [Authorize(Policy = "admin.brands.create")]
        public async Task<IActionResult> Add(BrandCreateCommand command)
        {
            var response = await mediator.Send(command);

            //mapping
            var dtoModel = mapper.Map<BrandDto>(response, cfg =>
            {
                cfg.Items.AddFromHeader(Request, "dateFormat");
            });

            return CreatedAtAction(nameof(Get), new
            {
                id = dtoModel.Id
            }
            , dtoModel);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(BrandEditCommand command)
        {
            var response = await mediator.Send(command);

            if (response == null)
                return BadRequest();

            //mapping
            var dtoModel = mapper.Map<BrandDto>(response);
            return Ok(dtoModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] BrandRemoveCommand command)
        {
            var response = await mediator.Send(command);

            if (response == null)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
