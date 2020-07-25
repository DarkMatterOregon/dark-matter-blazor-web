using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AirtableApiClient;
using DarkMatterWasm.Shared.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace DarkMatterWeb.Services
{
    public class AirTableService
    {
        private readonly string baseId;
        private readonly string appKey;

        private List<CrewMember> _crew;
        private Random random;

        public AirTableService(IConfiguration configuration)
        {
            baseId = configuration["AirTable:BaseId"];
            appKey = configuration["AirTable:AppKey"];
            random = new Random(DateTime.UtcNow.Second);
        }



        public async Task<CrewMember> GetCrewMemberAsync(string name)
        {
            if (_crew == null)
            {
                _crew = await GetCrewMembersAsync();
            }

            return _crew.Where(c => c.Name == name).FirstOrDefault();
        }




        public async Task<List<CrewMember>> GetCrewMembersAsync()
        {
            // check the cache
            //if (_crew != null) return _crew;

            _crew = new List<CrewMember>();
            string offset = null;

            using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
            {
                do
                {

                    Task<AirtableListRecordsResponse<CrewMember>> task =
                        airtableBase.ListRecords<CrewMember>(tableName: "Crew", offset: offset);

                    var response = await task;

                    if (response.Success)
                    {
                        foreach(AirtableRecord<CrewMember> airCrew in response.Records)
                        {
                            _crew.Add(airCrew.Fields);
                        }
                        offset = response.Offset;
                    }
                    else if (response.AirtableApiError is AirtableApiException)
                    {
                        throw new Exception(response.AirtableApiError.ErrorMessage);
                    }
                    else
                    {
                        throw new Exception("Unknown error");
                    }

                } while (offset != null);


            }
            return _crew.OrderBy(x => random.Next(1, 1000)).ToList();
        }

        public async Task<bool> ContactUs(Contact contact)
        {
            try
            {
                using (AirtableBase airtableBase = new AirtableBase(appKey, baseId))
                {
                    var fields = new Fields();
                    fields.AddField("Name", contact.Name);
                    fields.AddField("Message", contact.Message);
                    fields.AddField("Email", contact.Email);
                    fields.AddField("Phone", contact.Phone);
                    fields.AddField("Company", contact.Company);
                    var response = await airtableBase.CreateRecord("Contact", fields, true);
                    return response.Success;
                }
                // alert Doug or Mark about new message?
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
