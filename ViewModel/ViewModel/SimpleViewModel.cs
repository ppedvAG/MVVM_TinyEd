using Microsoft.Win32;
using MVVM_TinyEd.Model.FileService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_TinyEd.ViewModels.ViewModel
{
    public class SimpleViewModel : INotifyPropertyChanged
    {
        private readonly SimpleFileService service; // feste Abhängigkeit !
        private string editorContent;

        public event PropertyChangedEventHandler PropertyChanged;

        public string EditorContent
        {
            get { return editorContent; }
            set { editorContent = value; OnPropertyChanged(nameof(EditorContent)); }
        }
        public RelayCommand OpenFileClickCommand { get; set; }
        public RelayCommand SaveFileClickCommand { get; set; }

        public SimpleViewModel()
        {
            // Controllfreak-Antipattern - Bitte zuhause nicht nachmachen !
            service = new SimpleFileService();
            OpenFileClickCommand = new RelayCommand(OpenFileClick, () => true);
            SaveFileClickCommand = new RelayCommand(SaveFileClick, () => true);
        }

        private void SaveFileClick()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == true)
                service.SaveFile(dlg.FileName, EditorContent);
        }

        private void OpenFileClick()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
                EditorContent = service.OpenFile(dlg.FileName);
        }

        protected virtual void OnPropertyChanged(string PropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

    }
}
