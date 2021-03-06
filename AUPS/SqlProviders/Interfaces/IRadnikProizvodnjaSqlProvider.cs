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
    public interface IRadnikProizvodnjaSqlProvider
    {
        ObservableCollection<RadnikProizvodnja> GetAllFromRadnikProizvodnja();
        bool DeleteFromRadnikProizvodnjaById(int iDRadnik);

        bool UpdateRadnikProizvodnjaById(RadnikProizvodnja radnikProizvodnja);

        bool CreateRadnikProizvodnjaById(RadnikProizvodnja radnikProizvodnjaNew);
    }
}
