using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Primeiro_Projeto.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;      // Estudar para que serve o "?" nesse código

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)  
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}