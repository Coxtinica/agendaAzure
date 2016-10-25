using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace agendaAzure
{
    public class agendaAzure
    {
        string id;
        string nombre;
        string apellido;
        string telefono;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "Nombre")]
        public string Name
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [JsonProperty(PropertyName = "Apellido")]
        public string Lastname
        {
            get { return apellido; }
            set { apellido = value; }
        }

        [JsonProperty(PropertyName = "Telefono")]
        public string Cellphone
        {
            get { return telefono; }
            set { telefono = value; }
        }

        [Version]
        public string Version { get; set; }
    
}
}
