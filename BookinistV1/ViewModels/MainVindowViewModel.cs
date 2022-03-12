using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookinistV1.ViewModels
{
    public class MainVindowViewModel : ViewModel
    {
        #region Title : string - Заголовок
        /// <summary> Заголовок </summary>
        private string _Title = "Главное окно программы";

        /// <summary> Заголовок </summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion
    }
}
