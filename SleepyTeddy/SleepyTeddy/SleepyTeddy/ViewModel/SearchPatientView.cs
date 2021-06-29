using AutoMapper;
using Plugin.CloudFirestore;
using SleepyTeddy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyTeddy.ViewModel
{
    public class SearchPatientView:INotifyPropertyChanged
    {
        //public ObservableCollection<MyModel> Items { get; set; }
        public List<PatientsView> ListPatient { get; set; }
        public List<string> Cuestionarios { get; set; }
        public SearchPatientView() {
            ListPatient = new List<PatientsView>();
            Cuestionarios = new List<string>();
            Cuestionarios.Add("PHQ-9");
            Cuestionarios.Add("ISI");
            Cuestionarios.Add("Athennas Insomnia Scale");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task GetPatientsViewAsync() {
            var document =await CrossCloudFirestore.Current
                                       .Instance
                                       .Collection("Patients")
                                       .GetAsync();
           
            var resModel = document.ToObjects<Patients>().ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patients, PatientsView>()
                .ForMember(d => d.Key, o => o.MapFrom(c => c.Pacient_ID))
                .ForMember(d => d.Name, o => o.MapFrom(c => c.Names));
            });

            resModel.ForEach(a => ListPatient.Add(config.CreateMapper().Map<Patients, PatientsView>(a)));
            return;
        }
    }

    public class PatientsView { 
        public string Key { get; set; }
        public string Name { get; set; }
    }
}
