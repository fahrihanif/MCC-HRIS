namespace HRIS.API.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string EmployeeNumber { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly HireDate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}