namespace HospitalApi.DTOs 
{
    public class ContactInformationDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthOfDate { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string AdditionalInformation { get; set; } = null!;  
    }
}

