using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerskaForma : Form
    {
        Server server = new Server();

        static List<Button> buttons = new List<Button>();
        public ServerskaForma()
        {
            InitializeComponent();

            btnZaustavi.Enabled = false;

            buttons.Add(btnPokreni);
            buttons.Add(btnZaustavi);
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            Thread nit = new Thread(server.Start);
            nit.IsBackground = true;
            nit.Start();

            OmoguciPotrebnoDugme();
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            server.Stop();
            OmoguciPotrebnoDugme();
        }
        private static void OmoguciPotrebnoDugme()
        {
            buttons.ForEach(button => button.Enabled = button.Enabled ? false : true);
        }

    }
}
