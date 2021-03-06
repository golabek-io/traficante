﻿using Traficante.Connect;
using Traficante.Studio.Models;

namespace Traficante.Studio.ViewModels
{
    public interface ISelectableObject
    {
        IDataSourceObjectModel Object { get; }
        public string Title { get; }
        public object Icon { get; }
        QueryLanguage QueryLanguage { get; set; }
        QueryLanguageRadioButtonModel[] QueryLanguages { get; }
    }
}
