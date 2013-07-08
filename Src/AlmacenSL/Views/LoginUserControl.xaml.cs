using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AlmacenSL.Infrastructure;

namespace AlmacenSL.Views
{
    [ViewExport(RegionName = "MainContentRegion")]
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
        }
    }
}
