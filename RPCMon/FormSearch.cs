﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPCMon
{
    public delegate void searchEventHandler(string i_SearchString, bool i_SearchDown, bool i_MatchWholeWord, bool i_MatchSensitive);
    public partial class FormSearch : Form
    {
        //internal searchEventHandler searchForMatch;

        public event searchEventHandler searchForMatch;

        public FormSearch()
        {
            InitializeComponent();
            this.AcceptButton = buttonFind;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void OnSearchForMatch(string i_SearchString, bool i_SearchDown, bool i_MatchWholeWord, bool i_MatchSensitive)
        {
            if (searchForMatch != null)
            {
                searchForMatch.Invoke(i_SearchString, i_SearchDown, i_MatchWholeWord, i_MatchSensitive);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            OnSearchForMatch(comboBox1.Text, radioButtonDown.Checked, false, caseSensitiveCheckBox.Checked);
        }
    }
}
