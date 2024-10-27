using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HospitalApi.Models;
using HospitalApi.Repositories;
using HospitalApi.DTOs;

namespace HospitalApi.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

         public DepartmentsController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentRepository.GetAllAsync();

            var departmentDtos = departments.Select(c => new DepartmentDto
            {
                Id = c.Id,
                Name = c.Name,
                Location = c.Location
            }).ToList();

            return Ok(departmentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            var departmentDto = _mapper.Map<DepartmentDto>(department);
            departmentDto.Doctors = department.Doctors.Select(d => new DoctorDto
            {
                Experience = d.Experience,
                HireDate = d.HireDate,
                Status = d.Status,
                Position = d.Position,
                Specialization = d.Specialization
            }).ToList();

            return Ok(departmentDto);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> AddDepartment([FromBody] CreateDepartmentDto createDepartmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Department = _mapper.Map<Department>(createDepartmentDto);

            try
            {
                await _departmentRepository.AddAsync(Department);
                await _departmentRepository.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            var DepartmentDto = _mapper.Map<DepartmentDto>(Department);

            return CreatedAtAction(nameof(GetDepartmentById), new { id = DepartmentDto.Id }, DepartmentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, [FromBody] CreateDepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            department.Name = departmentDto.Name;
            department.Location = departmentDto.Location;

            await _departmentRepository.UpdateAsync(department);
            await _departmentRepository.SaveChangesAsync();

            var resultDto = _mapper.Map<DepartmentDto>(department);
 
            return CreatedAtAction(nameof(GetDepartmentById), new { id = resultDto.Id }, resultDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            
            if (department == null)
            {
                return NotFound();
            }
            
            await _departmentRepository.DeleteAsync(id);
            await _departmentRepository.SaveChangesAsync();
            
            return Ok();
        }
    }
}
