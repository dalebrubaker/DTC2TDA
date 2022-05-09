using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.ViewModels;

namespace DTC2TDA
{
    public partial class OptionsUserControl : UserControl
    {
        private OptionsUserControlViewModel? _viewModel;

        public OptionsUserControl()
        {
            InitializeComponent();
        }
        
        
        private string ViewModelPath => Path.Combine(Program.UserSettingsDirectory, $"{GetType().Name}.json");


        private void OptionsUserControl_Load(object sender, EventArgs e)
        {
            LoadConfig();
            optionsUserControlViewModelBindingSource.DataSource = _viewModel;
        }

        private void LoadConfig()
        {
            if (File.Exists(ViewModelPath))
            {
                var json = File.ReadAllText(ViewModelPath);
                _viewModel = JsonSerializer.Deserialize<OptionsUserControlViewModel>(json);
            }
            _viewModel ??= new OptionsUserControlViewModel
            {
                UseAccountDisplayNames = true
            };
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            SaveConfig();
            base.OnHandleDestroyed(e);
        }
        

        private void SaveConfig()
        {
            var json = JsonSerializer.Serialize(_viewModel);
            File.WriteAllText(ViewModelPath, json);
        }

    }
}
