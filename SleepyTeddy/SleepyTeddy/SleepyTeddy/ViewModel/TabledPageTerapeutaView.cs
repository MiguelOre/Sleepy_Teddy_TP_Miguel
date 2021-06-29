using AutoMapper;
using Plugin.CloudFirestore;
using SleepyTeddy.Models;
using SleepyTeddy.Models.Terapeuta;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyTeddy.ViewModel
{

    public class TabledPageTerapeutaView
    {
        public List<string> listTerapeutas { get; set; }
        public List<string> listPacientes { get; set; }
        //public ObservableCollection<PatientsView> ListPatient {get;set;}
        public ListaPacientes ListPatient { get; set; }
        public ListaTerapeutas ListTerapist { get; set; }


        public TabledPageTerapeutaView(){
            listTerapeutas = new List<string> { "Ernesto", "Felipe", "Juan" };
            listPacientes = new List<string> { "Andres", "Jorge", "Ronaldinho" };
            ListPatient = new ListaPacientes();//new ObservableCollection<PatientsView>();//new List<PatientsView>();
            ListTerapist = new ListaTerapeutas();
        }      
        public event NotifyCollectionChangedEventHandler CollectionChanged;


        public async Task GetPatientsViewAsync(string apellido)
        {
            ListPatient = new ListaPacientes(); //new List<PatientsView>();
            var document = await CrossCloudFirestore.Current
                                       .Instance
                                       .Collection("Patients")
                                       .WhereEqualsTo("Last_Names", apellido)
                                       .GetAsync();

            var resModel = document.ToObjects<Patients>().ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patients, PatientsView>()
                .ForMember(d => d.Key, o => o.MapFrom(c => c.Pacient_ID))
                .ForMember(d => d.Name, o => o.MapFrom(c => c.Names + " " + c.Last_Names));
            });

            resModel.ForEach(a => ListPatient.Add(config.CreateMapper().Map<Patients, PatientsView>(a)));
            return;
        }

        public async Task GetTerapistViewAsync(string apellido, string administrador_ID)
        {
            ListTerapist = new ListaTerapeutas(); //new List<PatientsView>();
            String terapeuta_role = "3";

            var document = await CrossCloudFirestore.Current
                                       .Instance
                                       .Collection("Users")
                                       .WhereEqualsTo("Role_ID", terapeuta_role)
                                       .WhereEqualsTo("Last_Names", apellido)
                                       .WhereEqualsTo("administrator_ID", administrador_ID)
                                       .GetAsync();

            var resModel = document.ToObjects<PostTerapeuta>().ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostTerapeuta, TerapistView>()
                .ForMember(d => d.Key, o => o.MapFrom(c => c.Terapeuta_ID))
                .ForMember(d => d.Name, o => o.MapFrom(c => c.Names))
                .ForMember(d => d.Last_Name, o => o.MapFrom(c => c.Last_Names))
                .ForMember(d => d.Especiality, o => o.MapFrom(c => c.Especiality))
                .ForMember(d => d.Email, o => o.MapFrom(c => c.Email))
                .ForMember(d => d.Password, o => o.MapFrom(c => c.Password))
                .ForMember(d => d.nombre_completo, o => o.MapFrom(c => c.Names + " " + c.Last_Names));
            });

            resModel.ForEach(a => ListTerapist.Add(config.CreateMapper().Map<PostTerapeuta, TerapistView>(a)));
            return;
        }


    }

    public class ListaPacientes : ObservableCollection<PatientsView> { }

    public class ListaTerapeutas : ObservableCollection<TerapistView> { }

    public class TerapistView
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Especiality { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string nombre_completo { get; set; }
        public string administrator_ID { get; set; }
    }
}
