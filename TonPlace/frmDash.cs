﻿using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using TonPlace.Models;

namespace TonPlace
{
    public partial class frmDash : Telerik.WinControls.UI.RadForm
    {
        ChromeDriver test;
        // Cấu hình phần mềm
        public static Setting setting = new Setting();


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
                //option.AddExtension("Taki/captcha.crx");
                //option.AddExtension("Taki/callback.crx");
                option.AddArgument("--app=https://ton.place/id409828?ref=640e4");
                string path = txtPath.Text;
                option.AddArgument("user-data-dir=" + path + "\\Ton\\VMS\\VmsRuning");
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

                tab.SetApartmentState(ApartmentState.STA);
                tab.Start();
            }
        }

        private void btn_unit_test_Click(object sender, EventArgs e)
        {
            SDK.RapidAPI_Mail = txt_api_mail.Text;
            SDK.Call_Create_Mai();
        }
    }
}
