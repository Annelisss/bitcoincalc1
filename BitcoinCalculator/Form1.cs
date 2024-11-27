using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BitcoinCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currencyinput.SelectedItem.ToString() == "EEK")
            {
                button1.Visible = true;
                currencyinput.Visible = true;
                BitcoinRates newbitcoinrate = GetRates();

                if (float.TryParse(bitcoinamountinput.Text, out float bitcoinAmount))
                {
                    float result = bitcoinAmount * (float)newbitcoinrate.Bpi.EUR.rate_float;
                    resultlabel.Text = $"{result} Bitcoini {newbitcoinrate.Bpi.EUR.code}";
                }
                else
                {
                    resultlabel.Text = "Palun sisestage kehtiv number!";
                }
            }
            if (currencyinput.SelectedItem.ToString() == "USD")
            {
                button1.Visible = true;
                currencyinput.Visible = true;
                BitcoinRates newbitcoinrate = GetRates();

                if (float.TryParse(bitcoinamountinput.Text, out float bitcoinAmount))
                {
                    float result = bitcoinAmount * (float)newbitcoinrate.Bpi.USD.rate_float;
                    resultlabel.Text = $"{result} Bitcoini {newbitcoinrate.Bpi.USD.code}";
                }
                else
                {
                    resultlabel.Text = "Palun sisestage kehtiv number!";
                }
            }
            if (currencyinput.SelectedItem.ToString() == "GBP")
            {
                button1.Visible = true;
                currencyinput.Visible = true;
                BitcoinRates newbitcoinrate = GetRates();

                if (float.TryParse(bitcoinamountinput.Text, out float bitcoinAmount))
                {
                    float result = bitcoinAmount * (float)newbitcoinrate.Bpi.GBP.rate_float;
                    resultlabel.Text = $"{result} Bitcoini {newbitcoinrate.Bpi.GBP.code}";
                }
                else
                {
                    resultlabel.Text = "Palun sisestage kehtiv number!";
                }
            }
            if (currencyinput.SelectedItem.ToString() == "EEK")
            {
                button1.Visible = true;
                currencyinput.Visible = true;
                float eekExchangeRate = 15.6466f;

                if (float.TryParse(bitcoinamountinput.Text, out float bitcoinAmount))
                {
                    BitcoinRates newbitcoinrate = GetRates();
                    float result = bitcoinAmount * (float)newbitcoinrate.Bpi.EUR.rate_float * eekExchangeRate;
                    resultlabel.Text = $"{result} Bitcoini EEK";
                }
                else
                {
                    resultlabel.Text = "Palun sisestage kehtiv number!";
                }
            }
        }
        public static BitcoinRates GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            BitcoinRates bitcoin;
            using (var responseReader = new StreamReader(webStream))
            {
                var data = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<BitcoinRates>(data);
            }
            return bitcoin;
        }

    }
}

