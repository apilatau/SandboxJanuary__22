using DataLayer.Dtos.OfficeDto;
using DataLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IOfficeService
    {
        Task<List<OfficeResponseDto>> GetAllOffices(CancellationToken cancellationToken = default);

        Task<ResponseBase<CreateOfficeDto>> DeleteOffice(int id, CancellationToken cancellationToken = default);

        Task<ResponseBase<OfficeResponseDto>> AddOffice(CreateOfficeDto mapDto);
        Task<ResponseBase<CreateOfficeDto>> GetOfficeById(int id, CancellationToken cancellationToken = default);
    }
}
