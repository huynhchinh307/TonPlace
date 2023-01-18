using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using TonPlace.Logic;
using TonPlace.Models;

namespace TonPlace
{
    public partial class frmDash : Telerik.WinControls.UI.RadForm
    {
        ChromeDriver test;
        // Cấu hình phần mềm
        public static Setting setting = new Setting();
        // Danh sách tài khoản Tweet được Pin
        public static List<Tweet_Profile> tweet_Profiles = new List<Tweet_Profile>();

        static frmDash _obj;
        public static frmDash Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new frmDash();
                }
                return _obj;
            }
        }

        public frmDash()
        {
            InitializeComponent();
        }



        private void btnTest_Click(object sender, EventArgs e)
        {
            Thread Chrome = new Thread(() =>
            {
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                ChromeOptions option = new ChromeOptions();
                option.AddArgument("window-size=393,851");
                option.AddExcludedArgument("enable-automation");
                option.AddAdditionalOption("useAutomationExtension", false);
                option.AddArgument("--autoplay-policy=no-user-gesture-required");
                option.AddArgument("--mute-audio");
                option.AddArgument("no-sandbox");
                option.AddArgument("--disable-infobars");
                option.AddArgument("--disable-default-apps");
                option.AddArgument("--disable-gpu");
                option.AddArgument("--FontRenderHinting[none]");
                option.AddArgument("--disable-blink-features=AutomationControlled");
                option.AddExtension("Ton/captcha.crx");
                option.AddArgument("--app=https://ton.place/id409828?ref=640e4");
                string path = txtPath.Text;
                option.AddArgument("user-data-dir=" + path + "\\VmsRuning");
                test = new ChromeDriver(driverService, option);


            });
            Chrome.Name = "Thread Test: " + "test";
            Chrome.SetApartmentState(ApartmentState.STA);
            Chrome.Start();
        }

        private void btn_setting_path_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    setting.path = @fbd.SelectedPath;
                    txtPath.Text = @fbd.SelectedPath;
                }
            }
        }

        private void frmDash_Load(object sender, EventArgs e)
        {
            LoadSetting();
        }

        private void LoadSetting()
        {
            string file = "Ton\\config.json";
            if (!File.Exists(file))
            {
                File.Create(file);
            }

            string file_content = File.ReadAllText("Ton\\config.json");
            setting = JsonConvert.DeserializeObject<Setting>(file_content);

            if (setting == null)
            {
                setting = new Setting();
            }

            txtPath.Text = setting.path;
            num_tab.Value = setting.num_tab;
            num_like.Value = setting.num_like;
            num_post.Value = setting.num_post;
            num_commnet.Value = setting.num_comment;

            // Setting API --start
            txt_api_account.Text = setting.key;
            txt_api_captcha.Text = setting.API.api_captcha;
            txt_api_mail.Text = setting.API.api_mail;
            txt_api_post.Text = setting.API.api_post;
            txt_api_proxy.Text = setting.API.api_proxy;
            txt_api_sms.Text = setting.API.api_sms;
            // Setting API --end

            // Setting Profile Username start
            string file_username = "Ton\\username.json";
            if (!File.Exists(file_username))
            {
                File.Create(file_username);
            }
            string user_content = File.ReadAllText(file_username);
            tweet_Profiles = JsonConvert.DeserializeObject<List<Tweet_Profile>>(user_content);
            // Setting Profile Username end
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (setting.future == null)
            {
                setting.future = new Future();
            }

            setting.path = txtPath.Text;
            setting.num_tab = (int)num_tab.Value;
            setting.num_post = (int)num_post.Value;
            setting.num_like = (int)num_like.Value;
            setting.num_comment = (int)num_commnet.Value;

            // Setting API --start
            if (setting.API == null)
            {
                setting.API = new API();
            }

            setting.API.api_mail = txt_api_mail.Text;
            setting.API.api_captcha = txt_api_captcha.Text;
            setting.API.api_proxy = txt_api_proxy.Text;
            setting.API.api_sms = txt_api_sms.Text;
            setting.API.api_post = txt_api_post.Text;
            // Setting API --end

            string json_Config = JsonConvert.SerializeObject(setting, Formatting.Indented);
            FileIO.Create_File_From_Json(json_Config, "Ton\\config.json");
            MessageBox.Show("Lưu thành công");
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < (int)num_tab.Value; i++)
            {
                Thread tab = new Thread(() =>
                {

                });

                tab.Name = i.ToString();
                tab.SetApartmentState(ApartmentState.STA);
                tab.Start();
            }
        }

        private void btn_unit_test_Click(object sender, EventArgs e)
        {
            Support.Create_Ton(setting);
        }

        private void btn_get_twitter_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem((o) => {
            Get_Again:
                Message("Lấy thông tin tài khoản ...");
                var client = new RestClient("https://twitter154.p.rapidapi.com/user/details?username=" + txt_twitter.Text);
                var request = new RestRequest("", Method.Get);
                request.AddHeader("X-RapidAPI-Key", "3b7b1d0cadmsh3840d5495663fb0p1c9477jsn6e545ce8c03a");
                request.AddHeader("X-RapidAPI-Host", "twitter154.p.rapidapi.com");
                var response = client.Execute(request);
                JObject jObject = JObject.Parse(response.Content);
                string user_id = (string)jObject["user_id"];
                var client2 = new RestClient("https://twitter154.p.rapidapi.com/user/following?user_id=" + user_id + "&limit=20");
                var request2 = new RestRequest("", Method.Get);
                request2.AddHeader("X-RapidAPI-Key", "3b7b1d0cadmsh3840d5495663fb0p1c9477jsn6e545ce8c03a");
                request2.AddHeader("X-RapidAPI-Host", "twitter154.p.rapidapi.com");
                var response2 = client2.Execute<RootProfile>(request2);
                if (response2.IsSuccessful)
                {
                    List<Tweet_Profile> profiles = response2.Data.results;
                    if (profiles.Count == 0)
                    {
                        MessageBox.Show("Get thất bại !!!");
                        return;
                    }
                    profiles.ForEach(r => r.profile_pic_url = r.profile_pic_url.Replace("_normal", ""));
                    tweet_Profiles.AddRange(profiles);
                }
                else
                {
                    Delay(5);
                    goto Get_Again;
                }

                string json = JsonConvert.SerializeObject(tweet_Profiles, Formatting.Indented);
                FileIO.Create_File_From_Json(json, "Ton/username.json");
                MessageBox.Show("Đang có: " + tweet_Profiles.Count + " đang trống !!!");
            });

        }

        public void Message(string msg)
        {
            if (lbl_message.InvokeRequired)
            {
                lbl_message.Invoke(new MethodInvoker(() =>
                {
                    lbl_message.Text = msg;
                }));
            }
            else
            {
                lbl_message.Text = msg;
            }
        }

        #region Chức năng delay
        public void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;
            }
        }
        #endregion
    }
}
