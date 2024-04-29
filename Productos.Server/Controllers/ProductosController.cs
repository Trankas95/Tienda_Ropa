﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productos.Server.Models;

namespace Productos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosContext _context;

        public ProductosController(ProductosContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult>CrearProdcuto(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Producto>>> Lista()
        {
            var productos = await _context.Productos.ToListAsync();

            return Ok(productos);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerProducto(int id)
        {
            Producto producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);

        }

        [HttpPut]
        [Route("editar")]

        public async Task<IActionResult> EditarProducto(int id, Producto producto)
        {
            var productoExistente = await _context.Productos.FindAsync(id);
            
            productoExistente.Color = producto.Color;
            productoExistente.Talla = producto.Talla;
            productoExistente.Precio = producto.Precio;
            productoExistente.Descripcion = producto.Descripcion;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]

        public async Task<IActionResult> EliminarProducto(int id)
        {
            var productoBorrado = await _context.Productos.FindAsync(id);

            _context.Productos.Remove(productoBorrado);

            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
