using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DockVision
{
    public partial class MainForm : Form
    {
        private static DockPanel _dockPanel;

        public MainForm()
        {
            InitializeComponent();

            _dockPanel = new DockPanel()
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(_dockPanel);

            _dockPanel.Theme = new VS2015BlueTheme();

            LoadDockingWindows();
        }

        private void LoadDockingWindows()
        {
            var cameraForm = new CameraForm();
            cameraForm.Show(_dockPanel, DockState.Document);

            var resultForm = new ResultForm();
            resultForm.Show(cameraForm.Pane, DockAlignment.Bottom, 0.3);

            var propForm = new PropertiesForm();
            propForm.Show(_dockPanel, DockState.DockRight);

            var statisticForm = new StatisticForm();
            statisticForm.Show(_dockPanel, DockState.DockRight);
            
            var LogForm = new LogForm();
            LogForm.Show(propForm.Pane, DockAlignment.Bottom, 0.5);
        }

        public static T GetDockForm<T>() where T : DockContent
        {
            var findForm = _dockPanel.Contents.OfType<T>().FirstOrDefault();
            return findForm;
        }







    }
}
