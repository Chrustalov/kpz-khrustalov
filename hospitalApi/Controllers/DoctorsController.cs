using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HospitalApi.Repositories;
using HospitalApi.Models;
using HospitalApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;

    public DoctorsController(IDoctorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
    {
        var doctors = await _repository.GetAllAsync();

        var doctorDtos = _mapper.Map<IEnumerable<DoctorDto>>(doctors);

        return Ok(doctorDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDto>> GetDoctor(int id)
    {
        var doctor = await _repository.GetByIdAsync(id);
        if (doctor == null)
        {
            return NotFound();
        }

        var doctorDto = _mapper.Map<DoctorDto>(doctor);
        return Ok(doctorDto);
    }

    [HttpPost]
    public async Task<ActionResult<DoctorDto>> PostDoctor([FromBody] CreateDoctorDto createDoctorDto)
    {
        var doctor = _mapper.Map<Doctor>(createDoctorDto);

        try
        {
            await _repository.AddAsync(doctor);
            await _repository.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500, "A problem happened while handling your request.");
        }

        var DoctorDto = _mapper.Map<DoctorDto>(doctor);
        return CreatedAtAction(nameof(GetDoctor), new { id = DoctorDto.Id }, DoctorDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDoctor(int id, DoctorDto doctorDto)
    {
        if (id != doctorDto.DepartmentId)
        {
            return BadRequest();
        }

        var doctor = _mapper.Map<Doctor>(doctorDto);
        doctor.Id = id;
        
        doctor.HireDate = doctorDto.HireDate != DateTime.MinValue ? doctorDto.HireDate : doctor.HireDate;
        doctor.DepartmentId = doctorDto.DepartmentId != 0 ? doctorDto.DepartmentId : doctor.DepartmentId;
        doctor.Status = !string.IsNullOrEmpty(doctorDto.Status) ? doctorDto.Status : doctor.Status;
        doctor.Position = !string.IsNullOrEmpty(doctorDto.Position) ? doctorDto.Position : doctor.Position;
        doctor.Specialization = !string.IsNullOrEmpty(doctorDto.Specialization) ? doctorDto.Specialization : doctor.Specialization;
        doctor.Experience = doctorDto.Experience != 0 ? doctorDto.Experience : doctor.Experience;


        if (doctor.ContactInformation == null)
        {
            doctor.ContactInformation = new ContactInformation();
        }

        doctor.ContactInformation.FirstName = !string.IsNullOrEmpty(doctorDto.ContactInformation.FirstName) 
            ? doctorDto.ContactInformation.FirstName 
            : doctor.ContactInformation.FirstName;

        doctor.ContactInformation.LastName = !string.IsNullOrEmpty(doctorDto.ContactInformation.LastName) 
            ? doctorDto.ContactInformation.LastName 
            : doctor.ContactInformation.LastName;

        doctor.ContactInformation.BirthOfDate = doctorDto.ContactInformation.BirthOfDate != DateTime.MinValue 
            ? doctorDto.ContactInformation.BirthOfDate 
            : doctor.ContactInformation.BirthOfDate;

        doctor.ContactInformation.PhoneNumber = !string.IsNullOrEmpty(doctorDto.ContactInformation.PhoneNumber) 
            ? doctorDto.ContactInformation.PhoneNumber 
            : doctor.ContactInformation.PhoneNumber;

        doctor.ContactInformation.AdditionalInformation = !string.IsNullOrEmpty(doctorDto.ContactInformation.AdditionalInformation) 
            ? doctorDto.ContactInformation.AdditionalInformation 
            : doctor.ContactInformation.AdditionalInformation;

        try
        {
            await _repository.UpdateAsync(doctor);
            await _repository.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500, "A problem happened while handling your request.");
        }

        var resultDto = _mapper.Map<DoctorDto>(doctor);

        return CreatedAtAction(nameof(GetDoctor), new { id = resultDto.DepartmentId }, resultDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var doctor = await _repository.GetByIdAsync(id);
        
        if (doctor == null)
        {
            return NotFound();
        }
        
        await _repository.DeleteAsync(id);
        
        return Ok();
    }
}
