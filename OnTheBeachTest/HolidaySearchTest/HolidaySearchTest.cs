using AutoFixture;
using Moq.AutoMock;
using OnTheBeachTechnicalTest;
using OnTheBeachTechnicalTest.Implementation.HolidaySearcher;
using OnTheBeachTechTest;
using Xunit;

namespace OnTheBeachTest.HolidaySearchTest

{
    public class HolidaySearchTest
    {
        public Fixture fixture = new Fixture();
        public AutoMocker autoMocker = new AutoMocker();
        
        [Fact]
        public void GivenIHaveAFlightAndHotel_WhenISearchForHoliday_ThenCalculateTotalPrice()
        // what I want is to test the total price of the model
        {
            //arrange

            
            //act

            //assert
        }
        public class SalarySlipTests
        {
            public Fixture fixture = new Fixture();
            public AutoMocker autoMocker = new AutoMocker();

            [Fact]
            public void GivenIHaveAFlightAndHotel_WhenISearchForHoliday_ThenCalculateTotalPrice()
            {
                
            }
        //example test from katas with andrew
        //     public void GivenIHaveAEmployee_WhenIGenerateFor_ThenCalculateMonthlySalary()
        //     {
        //         //Arrange
        //         var employee = fixture.Create<Employee>();
        //         var salarySlipGenerator = autoMocker.CreateInstance<SalarySlipGenerator>();
        //
        //         var nationalInsuranceContributions = fixture.Create<decimal>();
        //
        //         autoMocker.GetMock<INationalInsuranceCalculator>().Setup(calc => calc.Calculate(employee.annualGrossSalary))
        //             .Returns(nationalInsuranceContributions);
        //
        //
        //         //Act
        //         var result = salarySlipGenerator.GenerateFor(employee);
        //
        //         //Assert
        //         decimal expectedMonthlyGrossSalary = employee.annualGrossSalary / 12;
        //         result.monthlyGrossSalary.Should().Be(Decimal.Round(expectedMonthlyGrossSalary, 2));
        //         result.EmployeeId.Should().Be(employee.id);
        //         result.Name.Should().Be(employee.name);
        //         result.nationalInsuranceContributions.Should().Be(nationalInsuranceContributions);
        //     }
        // }
        
    
    }
}

