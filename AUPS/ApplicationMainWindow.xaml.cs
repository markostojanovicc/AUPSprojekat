﻿using AUPS.SqlProviders.Interfaces;
using AUPS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AUPS
{
    /// <summary>
    /// Interaction logic for ApplicationMainWindow.xaml
    /// </summary>
    public partial class ApplicationMainWindow : Window
    {
        public ApplicationMainWindow(IUserSqlProvider userSqlProvider,
            IRadnoMestoSqlProvider radnoMestoSqlProvider)
        {
            InitializeComponent();

            DataContext = new ApplictionMainWindowViewModel(userSqlProvider, radnoMestoSqlProvider);
        }
    }
}
