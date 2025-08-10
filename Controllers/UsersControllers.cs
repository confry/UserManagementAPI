using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
       
        private static List<User> users = new List<User>();
        private static int nextId = 1;

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = users.FirstOrDefault(u => u.Id == id);
                if (user == null) return NotFound($"Usuario con id {id} no encontrado.");
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            try
            {
           
                if (string.IsNullOrWhiteSpace(newUser.FirstName))
                    return BadRequest("El nombre es obligatorio.");

                if (string.IsNullOrWhiteSpace(newUser.LastName))
                    return BadRequest("El apellido es obligatorio.");

                if (string.IsNullOrWhiteSpace(newUser.Email) || !newUser.Email.Contains("@"))
                    return BadRequest("El correo electrónico es inválido.");

                newUser.Id = nextId++;
                users.Add(newUser);

                return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            try
            {
                var existingUser = users.FirstOrDefault(u => u.Id == id);
                if (existingUser == null) return NotFound($"Usuario con id {id} no encontrado.");

                if (string.IsNullOrWhiteSpace(updatedUser.FirstName))
                    return BadRequest("El nombre es obligatorio.");

                if (string.IsNullOrWhiteSpace(updatedUser.LastName))
                    return BadRequest("El apellido es obligatorio.");

                if (string.IsNullOrWhiteSpace(updatedUser.Email) || !updatedUser.Email.Contains("@"))
                    return BadRequest("El correo electrónico es inválido.");

                existingUser.FirstName = updatedUser.FirstName;
                existingUser.LastName = updatedUser.LastName;
                existingUser.Email = updatedUser.Email;

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = users.FirstOrDefault(u => u.Id == id);
                if (user == null) return NotFound($"Usuario con id {id} no encontrado.");

                users.Remove(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
