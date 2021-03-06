﻿using AUPS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.SqlProviders.Interfaces
{
    public interface IRadnaListaSqlProvider
    {
        ObservableCollection<RadnaLista> GetAllFromRadnaLista();
        bool DeleteFromRadnaListaById(int iDRadnaLista);

        bool UpdateRadnaListaById(RadnaLista radnaLista);

        bool CreateRadnaListaById(RadnaLista radnaListaNew);
    }
}
