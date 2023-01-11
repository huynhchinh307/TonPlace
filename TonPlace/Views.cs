using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonPlace
{
    class Views
    {
        public static string Sign_in_Button = "#profile_scrollView > div > div.ptr__children > div.Profile > div.InlineAuthForm > div.InlineAuthForm__footer > div";
        public static string Google_Sign_in = "div.AuthPopover__wrapper > div.AuthPopover > div > div.AuthPopover__content > div.Auth > div.Auth__socials > div:nth-child(2) > div.Button__text";
        public static string Captcha__content = "div.Captcha__recaptcha";
        public static string Sign_Nick_Name = "#root > div > div.Content__wrap > div.Registration__header > div.Registration__title";
        public static string Sign_Input = "#root > div > div.Content__wrap > div.Form > div:nth-child(1) > div.Form__item__cont > div > div.Input__wrapper > input";
    }
}
