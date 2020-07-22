using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSA_StudentSIMS.Data;
using MSA_StudentSIMS.Models;

namespace MSA_StudentSIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentsController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return  await _context.Student.Include(s => s.addresses).ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        { 
            var student = await _context.Student.Include(s => s.addresses).FirstOrDefaultAsync(i => i.studentId == id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST: api/Students
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.studentId }, student);
        }

        // PUT: api/Students/5
        // This API **update** information excluding addresses for a student using studentId.
        // Even if some additional addresses was contained in the JSON object of a student sent from client side, the update of addresses would be ignored.
        // To change address of a student, use AddAddressForStudent, UpdateAddressForStudent, DeleteAddressForStudent
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, [Bind("studentId,firstName,middleName,lastName,emailAddress,phoneNumber,timeCreated")] Student student)
        {

            if (id != student.studentId)
            {
                return BadRequest();
            }

            var existingStudent = _context.Student.Where(s => s.studentId == student.studentId).Include(s => s.addresses).SingleOrDefault();

            if (existingStudent != null)
            {
                _context.Entry(existingStudent).CurrentValues.SetValues(student);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("{studentId}/AddAddress")]
        public async Task<IActionResult> AddAddressForStudent(int studentId,Address newAddress)
        {
            var existingStudent = _context.Student.Where(s => s.studentId == studentId).Include(s=> s.addresses).SingleOrDefault();

            if (existingStudent != null)
            {
               existingStudent.addresses.Add(newAddress);
               await _context.SaveChangesAsync();
            }
            else
            {
                return  NotFound("Student Id does not exist");
            }


            return Ok();
        }

        [HttpPut("{studentId}/{addressId}/UpdateAddress")]
        public async Task<IActionResult> UpdateAddressForStudent(int studentId, int addressId, Address updatedAddress)
        {

            if(studentId!= updatedAddress.studentId || addressId != updatedAddress.addressId)
            {
                return BadRequest("please ensure consistency of studentId and addressId between API parameters and Address ");
            }

            var existingStudent = _context.Student.Where(s => s.studentId == studentId).Include(s=> s.addresses).SingleOrDefault();

            if (existingStudent != null)
            {
                var existingAddress = existingStudent.addresses.Where(add => add.addressId == updatedAddress.addressId).SingleOrDefault();

                if (existingAddress != null)
                {
                    _context.Entry(existingAddress).CurrentValues.SetValues(updatedAddress);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound($"No address with addressId={updatedAddress.addressId} was found for stundent with studentId={studentId}");
                }
            }
            else
            {
                return NotFound($"Student with studentId={studentId} does not exist");
            }


            return Ok($"Successfully update the address with addressId={updatedAddress.addressId} for student with studentId={studentId}  ");
        }




        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.studentId == id);
        }
    }
}
