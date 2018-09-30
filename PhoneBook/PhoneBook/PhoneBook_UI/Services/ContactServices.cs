using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook_UI.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();
        Task<Contact> Get(int id);
    }

    public class ContactServices : IContactService
    {
        public async Task<List<Contact>> GetAll()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(PhoneBook_UI.Properties.Settings.Default.APIRoot);
            //поменяли адрес
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            List <Contact> contact = null;

            HttpResponseMessage response = await client.GetAsync("api/Contacts");
            if (response.IsSuccessStatusCode)
            {
                contact = await response.Content.ReadAsAsync<List<Contact>>();
            }
            return contact;
        }

        public async Task<Contact> Get(int id)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(PhoneBook_UI.Properties.Settings.Default.APIRoot);
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Contact contact = null;

            HttpResponseMessage response = await client.GetAsync($"api/Contacts/{id}");
            if (response.IsSuccessStatusCode)
            {
                contact = await response.Content.ReadAsAsync<Contact>();
                return contact;
            }
            else
                throw new Exception($"{response.StatusCode}");
        }
    }
}