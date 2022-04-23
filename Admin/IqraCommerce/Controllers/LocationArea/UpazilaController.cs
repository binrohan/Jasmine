using EBonik.Data.Entities.AddressArea;
using EBonik.Data.Models.LocationArea;
using IqraCommerce.Services.LocationArea;

namespace IqraCommerce.Controllers.LocationArea
{
    public class UpazilaController : AppDropDownController<Upazila, UpazilaModel>
    {
        UpazilaService ___service;
        public UpazilaController()
        {
            service = __service = ___service = new UpazilaService();
        }
    }
}
