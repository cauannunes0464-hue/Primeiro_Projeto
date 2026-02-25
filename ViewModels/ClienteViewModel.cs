using System.Collections.ObjectModel;
using System.Windows.Input;
using Primeiro_Projeto.Models;
using Primeiro_Projeto.ViewModels;


namespace Primeiro_Projeto.ViewModel
{

    public class ClienteViewModel : ViewModelBase
    {
        public ObservableCollection<Cliente> Clientes { get; set; }


        private string _nome;
        public string Nome
        {
            get => _nome;
            set
            {
                _nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }

        private string _telefone;
        public string Telefone
        {
            get => _telefone;
            set
            {
                _telefone = value;
                OnPropertyChanged(nameof(Telefone));
            }
        }


        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

   
        public ICommand AdicionarClienteCommand { get; }

        public ClienteViewModel()
        {
            Clientes = new ObservableCollection<Cliente>();

            AdicionarClienteCommand = new RelayCommand(AdicionarCliente);
        }


        private void AdicionarCliente()
        {
            if (!string.IsNullOrWhiteSpace(Nome))
            {
                Clientes.Add(new Cliente( Nome,Telefone , Email ));

                Nome = string.Empty;
                Telefone = string.Empty;
                Email = string.Empty;
                
            }
        }
    }
}

