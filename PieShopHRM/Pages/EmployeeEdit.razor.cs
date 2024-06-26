﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PieShopHRM.Services;
using PieShopHRM.Shared.Domain;

namespace PieShopHRM.Pages
{
    public partial class EmployeeEdit
    {
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        [Inject]
        public ICountryDataService? CountryDataService { get; set; }

        [Inject]
        public IJobCategoryDataService? JobCategoryDataService { get; set; }


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string EmployeeId { get; set; } = string.Empty;

        public Employee Employee { get; set; } = new Employee();

        public List<Country> Countries { get; set; } = new List<Country>();

        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        protected string Message = string.Empty;

        protected string StatusClass = string.Empty;

        protected bool Saved = false;

        private IBrowserFile selectedFile;

        protected async override Task OnInitializedAsync()
        {
            //  Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));

            Countries = (await CountryDataService.GetAllCountries()).ToList();

            JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();

            int.TryParse(EmployeeId, out var employeeId);

            if (employeeId == 0)
            {
                Employee = new Employee
                {
                    CountryId = 1,
                    JobCategoryId = 1,
                    JoinedDate = DateTime.Now,
                    BirthDate = DateTime.Now
                };
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }


        }

        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Employee.EmployeeId == 0) //new
            {
                if(selectedFile != null)
                {
                    var file = selectedFile;
                    Stream stream = file.OpenReadStream();
                    MemoryStream ms = new MemoryStream();
                    await stream.CopyToAsync(ms);
                    stream.Close();

                    Employee.ImageName = file.Name;
                    Employee.ImageContent = ms.ToArray();
                }
             
                var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Employee updated successfully.";
                Saved = true;
            }
        }
        protected async Task HandleInValidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }


        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }

    }
}
