using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AirtableApiClient;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace DarkMatterWeb.Services
{
    public class AirTableService
    {
        private readonly string baseId;
        private readonly string appKey;

        //private List<AirtableRecord<Place>> _places;
        //private List<AirtableRecord<Cuisine>> _cuisines;
        //private List<AirtableRecord<DeliveryService>> _deliveryServices;

        public AirTableService(IConfiguration configuration)
        {
            baseId = configuration["AirTable:BaseId"];
            appKey = configuration["AirTable:AppKey"];
        }

        public void ResetPlaces()
        {
           // _places = null;
        }

        public void ResetCuisines()
        {
          //  _cuisines = null;
        }

        //public async Task<Cuisine> GetCuisineAsync(string id)
        //{
        //    if (_cuisines == null)
        //    {
        //        _cuisines = await GetCuisinesAsync();
        //    }

        //    return _cuisines.Where(c => c.Id == id).FirstOrDefault().Fields;
        //}

        //public async Task<DeliveryService> GetDeliveryServiceAsync(string id)
        //{
        //    if (_deliveryServices == null)
        //    {
        //        _deliveryServices = await GetDeliveryServicesAsync();
        //    }

        //    return _deliveryServices.Where(c => c.Id == id).FirstOrDefault().Fields;
        //}

        //public async Task<List<AirtableRecord<Place>>> GetPlacesAsync()
        //{
        //    // check the cache
        //    if (_places != null) return _places;

        //    _places = new List<AirtableRecord<Place>>();
        //    string offset = null;

        //    using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
        //    {
        //        do
        //        {

        //            Task<AirtableListRecordsResponse<Place>> task =
        //                airtableBase.ListRecords<Place>(tableName: "Places", offset: offset);

        //            var response = await task;

        //            if (response.Success)
        //            {
        //                _places.AddRange(response.Records);
        //                offset = response.Offset;
        //            }
        //            else if (response.AirtableApiError is AirtableApiException)
        //            {
        //                throw new Exception(response.AirtableApiError.ErrorMessage);
        //                break;
        //            }
        //            else
        //            {
        //                throw new Exception("Unknown error");
        //                break;
        //            }

        //        } while (offset != null);

                   
        //    }
        //    return _places;
        //}

        //public async Task<List<AirtableRecord<Cuisine>>> GetCuisinesAsync()
        //{
        //    // check the cache
        //    if (_cuisines != null) return _cuisines;

        //    _cuisines = new List<AirtableRecord<Cuisine>>();
        //    string offset = null;

        //    using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
        //    {
        //        do
        //        {

        //            Task<AirtableListRecordsResponse<Cuisine>> task =
        //                airtableBase.ListRecords<Cuisine>(tableName: "Cuisines", offset: offset);

        //            var response = await task;

        //            if (response.Success)
        //            {
        //                _cuisines.AddRange(response.Records);
        //                offset = response.Offset;
        //            }
        //            else if (response.AirtableApiError is AirtableApiException)
        //            {
        //                throw new Exception(response.AirtableApiError.ErrorMessage);
        //                break;
        //            }
        //            else
        //            {
        //                throw new Exception("Unknown error");
        //                break;
        //            }

        //        } while (offset != null);


        //    }
        //    return _cuisines;
        //}

        //public async Task<List<AirtableRecord<DeliveryService>>> GetDeliveryServicesAsync()
        //{
        //    // check the cache
        //    if (_deliveryServices != null) return _deliveryServices;

        //    _deliveryServices = new List<AirtableRecord<DeliveryService>>();
        //    string offset = null;

        //    using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
        //    {
        //        do
        //        {

        //            var task =
        //                airtableBase.ListRecords<DeliveryService>(tableName: "Delivery Services", offset: offset);

        //            var response = await task;

        //            if (response.Success)
        //            {
        //                _deliveryServices.AddRange(response.Records);
        //                offset = response.Offset;
        //            }
        //            else if (response.AirtableApiError is AirtableApiException)
        //            {
        //                throw new Exception(response.AirtableApiError.ErrorMessage);
        //                break;
        //            }
        //            else
        //            {
        //                throw new Exception("Unknown error");
        //                break;
        //            }

        //        } while (offset != null);


        //    }
        //    return _deliveryServices;
        //}
    }
}
