using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HospitalApi.Repositories;
using HospitalApi.Models;
using HospitalApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

      public PatientsController(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientDto>>> Getpatients()
    {
        var patients = await _patientRepository.GetAllAsync();

        var patientDtos = _mapper.Map<IEnumerable<PatientDto>>(patients);

        return Ok(patientDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PatientDto>> GetPatient(int id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);
        if (patient == null)
        {
            return NotFound();
        }

        var patientDto = _mapper.Map<PatientDto>(patient);
        return Ok(patientDto);
    }

    [HttpPost]
    public async Task<ActionResult<PatientDto>> PostPatient([FromBody] CreatePatientDto createPatientDto)
    {
        var patient = _mapper.Map<Patient>(createPatientDto);

        try
        {
            await _patientRepository.UpdateAsync(patient);
            await _patientRepository.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(500, "A problem happened while handling your request.");
        }

        var PatientDto = _mapper.Map<PatientDto>(patient);
        return CreatedAtAction(nameof(GetPatient), new { id = PatientDto.Id }, PatientDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPatient(int id, [FromBody] CreatePatientDto patientDto)
    {
        var existingPatient = await _patientRepository.GetByIdAsync(id);

        if (existingPatient == null)
        {
            return NotFound();
        }

        _mapper.Map(patientDto, existingPatient);

        await _patientRepository.UpdateAsync(existingPatient);
        await _patientRepository.SaveChangesAsync();

        var resultDto = _mapper.Map<PatientDto>(existingPatient);

        return Ok(resultDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);
        
        if (patient == null)
        {
            return NotFound();
        }

        await _patientRepository.DeleteAsync(id);
        
        return Ok();
    }
}
