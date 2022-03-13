using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Dtos.ReportDto;
using DataLayer.Models;
using Microsoft.Extensions.Logging;

namespace BusinessLayer
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapService _mapService;
        private readonly IOfficeService _officeService;
        private readonly IWorkingDeskService _workingDeskService;
        private readonly ILogger<ReportService> _logger;
        private readonly ICityService _cityService;
        private readonly IUserService _userService;
        private readonly IReserveService _reserveService;

        public ReportService(IMapService mapService, ICityService cityService, IUserService userService, IOfficeService officeService, ApplicationDbContext dbContext, ILogger<ReportService> logger, IWorkingDeskService workingDeskService, IReserveService reserveService)
        {
            _dbContext = dbContext;
            _userService = userService;
            _cityService = cityService;
            _officeService = officeService;
            _mapService = mapService;
            _logger = logger;
            _workingDeskService = workingDeskService;
            _reserveService = reserveService;
        }


        public async Task<GetReport> ReportByOffice(int officeId, DateTime startDate, DateTime finishDate, RequestOfficeReport requestOfficeReport)
        {
            var office = await _officeService.GetOfficeById(officeId);
            if (office == null) throw new OfficeCustomException("Office not found");
            var maps = await _mapService.GetAllMaps(office.Id);
            var workingDesksList = await _workingDeskService.GetWorkingDesksForEachMap(maps);

            var reserves = new List<Reserve>();
            foreach(var workingDesk in workingDesksList)
            {
                var reserve = await _reserveService.GetByIdAsync(workingDesk.Id);
                reserves.Add(reserve);
            }
            var filtredReserves = reserves.Where(x => x.StartDate >= startDate && x.EndDate <= finishDate);
            int numberOfDesks = workingDesksList.Count();
            var bookedDesksNumber = workingDesksList.Where(x => x.Booked == true).Count();
            var freeDesksNumber = numberOfDesks - bookedDesksNumber;
            float percentageBooked = (bookedDesksNumber / numberOfDesks) * 100;

            var getOfficeReport = new GetReport()
            {
                PercentageOfBookedWorkplaces = percentageBooked,
                NumberOfBookedWorkplaces = numberOfDesks,
                NumberOfFreeWorkplaces = freeDesksNumber,
            };

            return getOfficeReport;

            //if (requestOfficeReport.DetailsEnum == DetailsEnum.NumBooked)
            //{
            //    return getOfficeReport;
            //}
            //else if (requestOfficeReport.DetailsEnum == DetailsEnum.NumFree)
            //{ 
            //    return getOfficeReport;
            //}
            //else if (requestOfficeReport.DetailsEnum == DetailsEnum.Percentage)
            //{
            //    return getOfficeReport;
            }
        }        
    }

        //[HttpGet("ReportByCity")]
        //public async Task<GetReportDto> ReportByCity(RequestCityReportDto requestCityReportDto, DateTime startDate, DateTime finishDate, CancellationToken cancellationToken = default)
        //{
        //    var city = await _cityService.GetCityById(requestCityReportDto.CityId);
        //    if (city == null) throw new CityCustomException("City no found");

        //    var offices = await _officeService.GetAllOffices(city.Data.CountryId);
        //    if (offices == null) throw new OfficeCustomException("Office not found");

        //    var maps = await _mapService.GetMapsForEachOffice(offices);
        //    if (maps == null) throw new MapCustomException("Map not found");

        //    var workingAreas = await _workingDeskService.GetWorkingDesksForEachMap(maps);
        //    if (workingAreas == null) throw new WorkingDeskCustomException("WorkingDesks not found");

        //    int numberOfDesks = workingAreas.Count();
        //    var bookedDesksNumber = workingAreas.Where(x => x.Booked == true).Count();
        //    var freeDesksNumber = numberOfDesks - bookedDesksNumber;
        //    float percentageBooked = (bookedDesksNumber / numberOfDesks) * 100;

        //    var getCityReportResponseDto = new GetReportDto
        //    {
        //        PercentageOfBookedWorkplaces = 35, // sample output
        //        NumberOfBookedWorkplaces = bookedDesksNumber,
        //        NumberOfFreeWorkplaces = freeDesksNumber
        //    };

        //    if (requestCityReportDto.Timeline == ReportTimeline.Weekly)
        //    {
        //        if (requestCityReportDto.DetailsEnum == DetailsEnum.NumBooked)
        //        {
        //            return getCityReportResponseDto;
        //        }
        //        else if (requestCityReportDto.DetailsEnum == DetailsEnum.NumFree)
        //        {
        //            return getCityReportResponseDto;
        //        }
        //        else if (requestCityReportDto.DetailsEnum == DetailsEnum.Percentage)
        //        {
        //            return getCityReportResponseDto;
        //        }
        //        else throw new Exception("Option not found"); // needs to be modified
        //    }
        //    else if (requestCityReportDto.Timeline == ReportTimeline.Monthly)
        //    {
        //        return getCityReportResponseDto;
        //    }
        //    else throw new Exception("Option not found"); // needs to be modified
        //}

        //[HttpGet("ReportByFloor")]
        //public async Task<GetReportDto> ReportByFloor(RequestMapReportDto requestMapReportDto, DateTime startDate, DateTime finishDate, CancellationToken cancellationToken = default)
        //{
        //    var floor = await _mapService.GetMapById(requestMapReportDto.MapId);
        //    if (floor == null) throw new CustomFloorException("Floor not found");

        //    var workingAreas = await _workingDeskService.GetAllWorkingDesks(floor.Data.Floor);

        //    int numberOfDesks = workingAreas.Count();
        //    var bookedDesksNumber = workingAreas.Where(x => x.Booked == true).Count();
        //    var freeDesksNumber = numberOfDesks - bookedDesksNumber;
        //    float percentageBooked = (bookedDesksNumber / numberOfDesks) * 100;

        //    var getCityReportResponseDto = new GetReportDto
        //    {
        //        PercentageOfBookedWorkplaces = 35, // sample output
        //        NumberOfBookedWorkplaces = bookedDesksNumber,
        //        NumberOfFreeWorkplaces = freeDesksNumber
        //    };

        //    if (requestMapReportDto.Timeline == ReportTimeline.Weekly)
        //    {
        //        if (requestMapReportDto.DetailsEnum == DetailsEnum.NumBooked)
        //        {
        //            return getCityReportResponseDto;
        //        }
        //        else if (requestMapReportDto.DetailsEnum == DetailsEnum.NumFree)
        //        {
        //            return getCityReportResponseDto;
        //        }
        //        else if (requestMapReportDto.DetailsEnum == DetailsEnum.Percentage)
        //        {
        //            return getCityReportResponseDto;
        //        }
        //        else throw new Exception("Option not found"); // needs to be modified
        //    }
        //    else if (requestMapReportDto.Timeline == ReportTimeline.Monthly)
        //    {
        //        return getCityReportResponseDto;
        //    }
        //    else throw new Exception("Option not found"); // needs to be modified
        //}

        //[HttpGet("ReportByEmployee")]
        //public async Task<GetReportDto> ReportByEmployee(RequestUserReportDto requestUserReportDto, DateTime startDate, DateTime finishDate, CancellationToken cancellationToken = default)
        //{
        //    var employee = await _userService.GetByIdAsync(requestUserReportDto.UserId);
        //    if (employee == null) throw new CustomEmployeeException("User not Found");

        //    var reservesOfEmployee = await _reserveService.GetAllReserves(employee.Id);
        //    if (reservesOfEmployee == null) throw new CustomReserveException("No reserves found");

        //    int bookedDesksNumber = reservesOfEmployee.Count();

        //    var getOfficeReportResponseDto = new GetReportDto
        //    {
        //        NumberOfBookedWorkplaces = bookedDesksNumber,
        //    };

        //    if (requestUserReportDto.Timeline == ReportTimeline.Weekly)
        //    {
        //        return getOfficeReportResponseDto;
        //    }
        //    else if (requestUserReportDto.Timeline == ReportTimeline.Monthly)
        //    {
        //        return getOfficeReportResponseDto;
        //    }
        //    else throw new Exception("Option not found"); // needs to be modified
        //}


        //[HttpGet("ReportAllOffices")]
        //public async Task<GetReportDto> ReportAllOffices(RequestAllOfficesReportDto requestAllOfficesReportDto, DateTime startDate, DateTime finishDate, CancellationToken cancellationToken = default)
        //{
        //    var allOffices = await _officeService.GetAllOffices();
        //    if (allOffices == null) throw new OfficeCustomException("No data found");

        //    var maps = await _mapService.GetMapsForEachOffice(allOffices);
        //    if (maps == null) throw new MapCustomException("No data found");

        //    var workingAreas = await _workingDeskService.GetWorkingDesksForEachMap(maps);
        //    if (workingAreas == null) throw new WorkingDeskCustomException("WorkingDesks not found");

        //    int numberOfDesks = workingAreas.Count();
        //    var bookedDesksNumber = workingAreas.Where(x => x.Booked == true).Count();
        //    var freeDesksNumber = numberOfDesks - bookedDesksNumber;
        //    float percentageBooked = (bookedDesksNumber / numberOfDesks) * 100;

        //    var getReportResponseDto = new GetReportDto
        //    {
        //        PercentageOfBookedWorkplaces = 35, // sample output
        //        NumberOfBookedWorkplaces = bookedDesksNumber,
        //        NumberOfFreeWorkplaces = freeDesksNumber
        //    };

        //    if (requestAllOfficesReportDto.Timeline == ReportTimeline.Weekly)
        //    {
        //        if (requestAllOfficesReportDto.DetailsEnum == DetailsEnum.NumBooked)
        //        {
        //            return getReportResponseDto;
        //        }
        //        else if (requestAllOfficesReportDto.DetailsEnum == DetailsEnum.NumFree)
        //        {
        //            return getReportResponseDto;
        //        }
        //        else if (requestAllOfficesReportDto.DetailsEnum == DetailsEnum.Percentage)
        //        {
        //            return getReportResponseDto;
        //        }
        //        else throw new Exception("Option not found"); // needs to be modified
        //    }
        //    else if (requestAllOfficesReportDto.Timeline == ReportTimeline.Monthly)
        //    {
        //        return getReportResponseDto; // needs to be modified
        //    }
        //    else throw new Exception("Option not found"); // needs to be modified
        //}
    }
}
