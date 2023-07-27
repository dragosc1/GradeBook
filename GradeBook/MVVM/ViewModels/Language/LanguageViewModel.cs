using GradeBook.MVVM.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.MVVM.ViewModels.Language
{
    public class LanguageViewModel : ViewModelBase
    {
		/// <summary>
		/// this is the language view model
		/// contains two buttons for english and romanian support
		/// </summary>
		
		public LanguageViewModel()
		{
			LanguageCommandBase.SetLanguage(Properties.Settings.Default.language);
			EnglishButtonCommand = new EnglishLanguageCommand();
            RomanianButtonCommand = new RomanianLanguageCommand();	
		}
		public EnglishLanguageCommand EnglishButtonCommand { get; set; }
		public RomanianLanguageCommand RomanianButtonCommand { get; set; }
	}
}
