using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonPlace.Models
{
    public class Element
    {

        public string Catpcha = "//*[@id=\"__next\"]/div[2]/div[1]/div[2]/div[2]/div/div[2]/div/div/div/div/iframe";
        public static string Captcha_Invisable = "div:nth-child(2) > iframe";

        public string Copy_Button = "//*[@id=\"__next\"]/div[2]/div/div/div/div[2]/div[2]/div[2]/div/div[2]/div[1]/div/div";

        // Back get code
        public string Back_Get_Code = "//*[@id=\"__next\"]/div[2]/div[1]/div[2]/div[2]/button";
        // Bước 2
        public string Create_My_Coin = "//*[@id=\"modal-root\"]/div[2]/div/div[2]/div/button";
        public string Goto_Wallet = "//*[@id=\"modal-root\"]/div[2]/div/div[2]/div/button[2]";
        // Buy coin
        public string Buy_Coin_Button_C = "#__next > div.css-aweyws.ej2twmx20 > div > div > div.css-c9cvz2.e56mmy048 > div > div > div > div.css-11xi8vz.e56mmy033 > div.css-cgbnge.e56mmy043 > button.css-1e691c3.e15ggqxc9";
        public string Get_Coin_C = "#modal-root > div.css-1ll9bqd.e1l1al3h31 > div > div.css-1lju76g.epiie927 > form > div.css-1anqzxy.e16m6pu920 > div.css-7h9h7c.e19vp1032 > div.css-1k6v9io.ej2twmx20 > div > div";
        public string Buy_Amount_C = "#modal-root > div.css-1ll9bqd.e1l1al3h31 > div > div.css-1lju76g.epiie927 > form > div.css-1anqzxy.e16m6pu920 > div.css-7h9h7c.e19vp1032 > div.css-xfg7pj.emn2ld34 > div > input";
        public string Buy_C = "#modal-root > div.css-1ll9bqd.e1l1al3h31 > div > div.css-1lju76g.epiie927 > form > button";
        public string Go_Wallet_After_Buy_Coin = "#modal-root > div.css-1ll9bqd.e1l1al3h31 > div > div.css-1lju76g.epiie927 > div > div.css-ltuzx7.e16m6pu99 > button.css-yi2qqh.e15ggqxc9";

        public string Setting_Taki_Gold = "confirmGoldTaki";
        public string Setting_Follow = "confirmFollowUser";


        public static class Captcha
        {
            public static string Url = "chrome-extension://ifibfemgeogfhoebkmokieepdoobkbpo/options/options.html";
            public static string Input_API = "body > div > div.content > table > tbody > tr:nth-child(1) > td:nth-child(2) > input[type=text]";
            public static string Input = "#connect";
            public static string autoSubmitForms = "#autoSubmitForms";
            public static string autoSolveRecaptchaV2 = "#autoSolveRecaptchaV2";
            public static string autoSolveRecaptchaV3 = "#autoSolveRecaptchaV3";
            public static string captcha_solver = "div.captcha-solver";
            public static string msg = "div.css-1l75fk7.emn2ld31";
            public static string captcha_callback = "head > captcha-widgets > captcha-widget";
        }

        public static class Create
        {
            public static string Sign_up_or_Log_in = "div.ptr__children > div.Profile > div.InlineAuthForm > div.InlineAuthForm__footer > div";
            public static string Input_Email = "div.Form__item.Auth__email__input.Form__item > div.Form__item__cont > div > input";
            public static string Continue = "div.Auth > div.Form > div:nth-child(2) > div > div";
            public static string Input_Code = "div.AuthPopover__content > div.Auth > div.Form.Auth__email__form > div.Form__item.Form__item > div > div > input";
            public static string Continue_Code = "div.AuthPopover > div > div.AuthPopover__content > div.Auth > div.Form.Auth__email__form > div.Auth__email__controls > div:nth-child(1) > div > div";
            public static string Input_Name = "#root > div > div.Content__wrap > div.Form > div:nth-child(1) > div.Form__item__cont > div > div.Input__wrapper > input";
            public static string Continue_Name = "#root > div > div.Content__wrap > div.Form > div:nth-child(2) > div > div";
            public static string Back = "#root > div > div.Content__wrap > div > div.Header.hasBack > div.Header__back";
        }

        public static class Profile
        {
            public static string link = "https://ton.place/{0}?w=edit";
            public static string First_name = "#root > div > div.Modal__wrap > div > div.ScrollView > div > div.Form > div:nth-child(1) > div.Form__item__cont > div > input";
            public static string Bio = "#root > div > div.Modal__wrap > div > div.ScrollView > div > div.Form > div:nth-child(3) > div.Form__item__cont > div > textarea";
            public static string Save = "#root > div > div.Modal__wrap > div > div.BottomBar.row > div > div > div";
            public static string Logo = "#profile_scrollView > div > div.ptr__children > div.Profile > div.Profile__info_block > div.Profile__common_info > div.UnitPhoto.large.active";
            public static string Change_Profile = "#action_sheet > div > div.BottomSheet__sheet_wrap > div > div.BottomSheet__content.hasScroll > div > div:nth-child(1) > div > div > div.ListItem__content > div > input";
        }

        public static class Create_post
        {
            public static string link = "https://ton.place/{0}?w=post";
            public static string Content = "#ql_editor > div > div.ql-editor.ql-blank";
            public static string Publish = "#root > div > div.Modal__wrap > div > div.BottomBar.fixed.row > div > div > div";
        }
    }
}
