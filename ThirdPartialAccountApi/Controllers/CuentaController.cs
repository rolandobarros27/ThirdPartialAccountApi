﻿using infraestructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;


namespace ThirdPartialAccountApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : Controller
    {
        // GET: CuentaController
        /*private string ConnectionString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";*/
        private CuentaService CuentaService;
        private IConfiguration configuration;

        /*public CuentaController()*/
        public CuentaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.CuentaService = new CuentaService(configuration.GetConnectionString("postgresDB"));
        }

        [Authorize]
        [HttpGet("ListarCuenta")]
        public ActionResult<List<CuentaModel>> ListarCuenta()
        {
            var resultado = CuentaService.ListarCuenta();
            return Ok(resultado);
        }

        [Authorize]
        [HttpGet("ConsultarCuenta/{id}")]
        /*public ActionResult<CuentaModel> getById(int id, string documento)*/
        public ActionResult<CuentaModel> ConsultarCuenta(int id)
        {
            var result = this.CuentaService.ConsultarCuenta(id);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("InsertarCuenta")]
        public ActionResult<string> insert(CuentaModel models)
        {
            /*return Ok("Ok");*/
            var result = this.CuentaService.InsertarCuenta(new infraestructure.Models.CuentaModel
            {
                id_persona = models.id_persona,
                nombre = models.nombre,
                numero = models.numero,
                saldo = models.saldo,
                limite_saldo = models.limite_saldo,
                limite_transferencia = models.limite_transferencia,
                estado = models.estado
            });
            return Ok(result);
        }
        // endpoint for Cuenta modify
        [Authorize]
        [HttpPut("ModificarCuenta/{id}")]
        public ActionResult<string> ModificarCuenta(CuentaModel models, int id)
        {

            var result = this.CuentaService.ModificarCuenta(new infraestructure.Models.CuentaModel
            {
                id_persona = models.id_persona,
                nombre = models.nombre,
                numero = models.numero,
                limite_saldo = models.limite_saldo,
                saldo = models.saldo,
                limite_transferencia = models.limite_transferencia,
                estado = models.estado
        }, id);
            return Ok(result);
        }

        // endpoint for Cuenta delete
        [Authorize]
        [HttpDelete("EliminarCuenta/{id}")]
        public ActionResult<string> eliminar(int id)
        {
            var result = this.CuentaService.EliminarCuenta(id);
            return Ok(result);
        }
    }
}
