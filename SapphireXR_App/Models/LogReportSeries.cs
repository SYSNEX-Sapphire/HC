using OxyPlot;
using System.Drawing;
using SapphireXR_App.ViewModels;

namespace SapphireXR_App.Models
{
    static class LogReportSeries
    {
        public static float? GetFlowValue(RecipeLog recipeLog, string deviceName)
        {
            switch(deviceName)
            {
                case nameof(RecipeLog.PV_M01):
                    return recipeLog.PV_M01;

                case nameof(RecipeLog.PV_M02):
                    return recipeLog.PV_M02;

                case nameof(RecipeLog.PV_M03):
                    return recipeLog.PV_M03;

                case nameof(RecipeLog.PV_M04):
                    return recipeLog.PV_M04;

                case nameof(RecipeLog.PV_M05):
                    return recipeLog.PV_M05;

                case nameof(RecipeLog.PV_M06):
                    return recipeLog.PV_M06;

                case nameof(RecipeLog.PV_M07):
                    return recipeLog.PV_M07;

                case nameof(RecipeLog.PV_M08):
                    return recipeLog.PV_M08;

                case nameof(RecipeLog.PV_M09):
                    return recipeLog.PV_M09;

                case nameof(RecipeLog.PV_M10):
                    return recipeLog.PV_M10;

                case nameof(RecipeLog.PV_M11):
                    return recipeLog.PV_M11;

                case nameof(RecipeLog.PV_M12):
                    return recipeLog.PV_M12;
             
                case nameof(RecipeLog.PV_F01):
                    return recipeLog.PV_F01;

                case nameof(RecipeLog.PV_F02):
                    return recipeLog.PV_F02;

                case nameof(RecipeLog.PV_F03):
                    return recipeLog.PV_F03;

                case nameof(RecipeLog.PV_F04):
                    return recipeLog.PV_F04;

                case nameof(RecipeLog.PV_F05):
                    return recipeLog.PV_F05;

                case nameof(RecipeLog.PV_F06):
                    return recipeLog.PV_F06;

                case nameof(RecipeLog.PV_IHT_KW):
                    return recipeLog.PV_IHT_KW;

                case nameof(RecipeLog.PV_SH_CW):
                    return recipeLog.PV_SH_CW;

                case nameof(RecipeLog.PV_IHT_CW):
                    return recipeLog.PV_IHT_CW;

                case nameof(RecipeLog.SV_M01):
                    return recipeLog.SV_M01;

                case nameof(RecipeLog.SV_M02):
                    return recipeLog.SV_M02;

                case nameof(RecipeLog.SV_M03):
                    return recipeLog.SV_M03;

                case nameof(RecipeLog.SV_M04):
                    return recipeLog.SV_M04;

                case nameof(RecipeLog.SV_M05):
                    return recipeLog.SV_M05;

                case nameof(RecipeLog.SV_M06):
                    return recipeLog.SV_M06;

                case nameof(RecipeLog.SV_M07):
                    return recipeLog.SV_M07;

                case nameof(RecipeLog.SV_M08):
                    return recipeLog.SV_M08;

                case nameof(RecipeLog.SV_M09):
                    return recipeLog.SV_M09;

                case nameof(RecipeLog.SV_M10):
                    return recipeLog.SV_M10;

                case nameof(RecipeLog.SV_M11):
                    return recipeLog.SV_M11;

                case nameof(RecipeLog.SV_M12):
                    return recipeLog.SV_M12;

                case nameof(RecipeLog.SV_F01):
                    return recipeLog.SV_F01;

                case nameof(RecipeLog.SV_F02):
                    return recipeLog.SV_F02;

                case nameof(RecipeLog.SV_F03):
                    return recipeLog.SV_F03;

                case nameof(RecipeLog.SV_F04):
                    return recipeLog.SV_F04;

                case nameof(RecipeLog.SV_F05):
                    return recipeLog.SV_F05;

                case nameof(RecipeLog.SV_F06):
                    return recipeLog.SV_F06;

                default:
                    return null;
            }
        }
        public static float? GetFlowPercentageValue(RecipeLog recipeLog, string deviceName)
        {
            switch (deviceName)
            {
                case nameof(RecipeLog.PV_M01):
                    return recipeLog.PV_M01 / SettingViewModel.ReadMaxValue("MFC01") * 100.0f;

                case nameof(RecipeLog.PV_M02):
                    return recipeLog.PV_M02 / SettingViewModel.ReadMaxValue("MFC02") * 100.0f;

                case nameof(RecipeLog.PV_M03):
                    return recipeLog.PV_M03 / SettingViewModel.ReadMaxValue("MFC03") * 100.0f;

                case nameof(RecipeLog.PV_M04):
                    return recipeLog.PV_M04 / SettingViewModel.ReadMaxValue("MFC04") * 100.0f;

                case nameof(RecipeLog.PV_M05):
                    return recipeLog.PV_M05 / SettingViewModel.ReadMaxValue("MFC05") * 100.0f;

                case nameof(RecipeLog.PV_M06):
                    return recipeLog.PV_M06 / SettingViewModel.ReadMaxValue("MFC06") * 100.0f;

                case nameof(RecipeLog.PV_M07):
                    return recipeLog.PV_M07 / SettingViewModel.ReadMaxValue("MFC07") * 100.0f;

                case nameof(RecipeLog.PV_M08):
                    return recipeLog.PV_M08 / SettingViewModel.ReadMaxValue("MFC08") * 100.0f;

                case nameof(RecipeLog.PV_M09):
                    return recipeLog.PV_M09 / SettingViewModel.ReadMaxValue("MFC09") * 100.0f;

                case nameof(RecipeLog.PV_M10):
                    return recipeLog.PV_M10 / SettingViewModel.ReadMaxValue("MFC10") * 100.0f;

                case nameof(RecipeLog.PV_M11):
                    return recipeLog.PV_M11 / SettingViewModel.ReadMaxValue("MFC11") * 100.0f;

                case nameof(RecipeLog.PV_M12):
                    return recipeLog.PV_M12 / SettingViewModel.ReadMaxValue("MFC12") * 100.0f;

                case nameof(RecipeLog.PV_F01):
                    return recipeLog.PV_F01 / SettingViewModel.ReadMaxValue("Temperature1") * 100.0f;

                case nameof(RecipeLog.PV_F02):
                    return recipeLog.PV_F02 / SettingViewModel.ReadMaxValue("Temperature2") * 100.0f;

                case nameof(RecipeLog.PV_F03):
                    return recipeLog.PV_F03 / SettingViewModel.ReadMaxValue("Temperature3") * 100.0f;

                case nameof(RecipeLog.PV_F04):
                    return recipeLog.PV_F04 / SettingViewModel.ReadMaxValue("Temperature4") * 100.0f;

                case nameof(RecipeLog.PV_F05):
                    return recipeLog.PV_F05 / SettingViewModel.ReadMaxValue("Temperature5") * 100.0f;

                case nameof(RecipeLog.PV_F06):
                    return recipeLog.PV_F06 / SettingViewModel.ReadMaxValue("Temperature6") * 100.0f;

                case nameof(RecipeLog.PV_IHT_KW):
                    return recipeLog.PV_IHT_KW / 100.0f;

                case nameof(RecipeLog.PV_SH_CW):
                    return recipeLog.PV_SH_CW / 100.0f;

                case nameof(RecipeLog.PV_IHT_CW):
                    return recipeLog.PV_IHT_CW / 100.0f;

                case nameof(RecipeLog.SV_M01):
                    return recipeLog.SV_M01 / SettingViewModel.ReadMaxValue("MFC01") * 100.0f;

                case nameof(RecipeLog.SV_M02):
                    return recipeLog.SV_M02 / SettingViewModel.ReadMaxValue("MFC02") * 100.0f;

                case nameof(RecipeLog.SV_M03):
                    return recipeLog.SV_M03 / SettingViewModel.ReadMaxValue("MFC03") * 100.0f;

                case nameof(RecipeLog.SV_M04):
                    return recipeLog.SV_M04 / SettingViewModel.ReadMaxValue("MFC04") * 100.0f;

                case nameof(RecipeLog.SV_M05):
                    return recipeLog.SV_M05 / SettingViewModel.ReadMaxValue("MFC05") * 100.0f;

                case nameof(RecipeLog.SV_M06):
                    return recipeLog.SV_M06 / SettingViewModel.ReadMaxValue("MFC06") * 100.0f;

                case nameof(RecipeLog.SV_M07):
                    return recipeLog.SV_M07 / SettingViewModel.ReadMaxValue("MFC07") * 100.0f;

                case nameof(RecipeLog.SV_M08):
                    return recipeLog.SV_M08 / SettingViewModel.ReadMaxValue("MFC08") * 100.0f;

                case nameof(RecipeLog.SV_M09):
                    return recipeLog.SV_M09 / SettingViewModel.ReadMaxValue("MFC09") * 100.0f;

                case nameof(RecipeLog.SV_M10):
                    return recipeLog.SV_M10 / SettingViewModel.ReadMaxValue("MFC10") * 100.0f;

                case nameof(RecipeLog.SV_M11):
                    return recipeLog.SV_M11 / SettingViewModel.ReadMaxValue("MFC11") * 100.0f;

                case nameof(RecipeLog.SV_M12):
                    return recipeLog.SV_M12 / SettingViewModel.ReadMaxValue("MFC12") * 100.0f;

                case nameof(RecipeLog.SV_F01):
                    return recipeLog.SV_F01 / SettingViewModel.ReadMaxValue("Temperature1") * 100.0f;

                case nameof(RecipeLog.SV_F02):
                    return recipeLog.SV_F02 / SettingViewModel.ReadMaxValue("Temperature2") * 100.0f;

                case nameof(RecipeLog.SV_F03):
                    return recipeLog.SV_F03 / SettingViewModel.ReadMaxValue("Temperature3") * 100.0f;

                case nameof(RecipeLog.SV_F04):
                    return recipeLog.SV_F04 / SettingViewModel.ReadMaxValue("Temperature4") * 100.0f;

                case nameof(RecipeLog.SV_F05):
                    return recipeLog.SV_F05 / SettingViewModel.ReadMaxValue("Temperature5") * 100.0f;

                case nameof(RecipeLog.SV_F06):
                    return recipeLog.SV_F06 / SettingViewModel.ReadMaxValue("Temperature6") * 100.0f;

                default:
                    return null;
            }
        }

        public static float? GetMaxValue(string deviceName)
        {
            switch (deviceName)
            {
                case nameof(RecipeLog.PV_M01):
                    return SettingViewModel.ReadMaxValue("MFC01");

                case nameof(RecipeLog.PV_M02):
                    return SettingViewModel.ReadMaxValue("MFC02");

                case nameof(RecipeLog.PV_M03):
                    return SettingViewModel.ReadMaxValue("MFC03");

                case nameof(RecipeLog.PV_M04):
                    return SettingViewModel.ReadMaxValue("MFC04");

                case nameof(RecipeLog.PV_M05):
                    return SettingViewModel.ReadMaxValue("MFC05");

                case nameof(RecipeLog.PV_M06):
                    return SettingViewModel.ReadMaxValue("MFC06");

                case nameof(RecipeLog.PV_M07):
                    return SettingViewModel.ReadMaxValue("MFC07");

                case nameof(RecipeLog.PV_M08):
                    return SettingViewModel.ReadMaxValue("MFC08");

                case nameof(RecipeLog.PV_M09):
                    return SettingViewModel.ReadMaxValue("MFC09");

                case nameof(RecipeLog.PV_M10):
                    return SettingViewModel.ReadMaxValue("MFC10");

                case nameof(RecipeLog.PV_M11):
                    return SettingViewModel.ReadMaxValue("MFC11");

                case nameof(RecipeLog.PV_M12):
                    return SettingViewModel.ReadMaxValue("MFC12");

                case nameof(RecipeLog.PV_F01):
                    return SettingViewModel.ReadMaxValue("Temperature1");

                case nameof(RecipeLog.PV_F02):
                    return SettingViewModel.ReadMaxValue("Temperature2");

                case nameof(RecipeLog.PV_F03):
                    return SettingViewModel.ReadMaxValue("Temperature3");

                case nameof(RecipeLog.PV_F04):
                    return SettingViewModel.ReadMaxValue("Temperature4");

                case nameof(RecipeLog.PV_F05):
                    return SettingViewModel.ReadMaxValue("Temperature5");

                case nameof(RecipeLog.PV_F06):
                    return SettingViewModel.ReadMaxValue("Temperature6");

                case nameof(RecipeLog.PV_IHT_KW):
                    return 100.0f;

                case nameof(RecipeLog.PV_SH_CW):
                    return 100.0f;

                case nameof(RecipeLog.PV_IHT_CW):
                    return 100.0f;

                case nameof(RecipeLog.SV_M01):
                    return SettingViewModel.ReadMaxValue("MFC01");

                case nameof(RecipeLog.SV_M02):
                    return SettingViewModel.ReadMaxValue("MFC02");

                case nameof(RecipeLog.SV_M03):
                    return SettingViewModel.ReadMaxValue("MFC03");

                case nameof(RecipeLog.SV_M04):
                    return SettingViewModel.ReadMaxValue("MFC04");

                case nameof(RecipeLog.SV_M05):
                    return SettingViewModel.ReadMaxValue("MFC05");

                case nameof(RecipeLog.SV_M06):
                    return SettingViewModel.ReadMaxValue("MFC06");

                case nameof(RecipeLog.SV_M07):
                    return SettingViewModel.ReadMaxValue("MFC07");

                case nameof(RecipeLog.SV_M08):
                    return SettingViewModel.ReadMaxValue("MFC08");

                case nameof(RecipeLog.SV_M09):
                    return SettingViewModel.ReadMaxValue("MFC09");

                case nameof(RecipeLog.SV_M10):
                    return SettingViewModel.ReadMaxValue("MFC10");

                case nameof(RecipeLog.SV_M11):
                    return SettingViewModel.ReadMaxValue("MFC11");

                case nameof(RecipeLog.SV_M12):
                    return SettingViewModel.ReadMaxValue("MFC12");
                
                case nameof(RecipeLog.SV_F01):
                    return SettingViewModel.ReadMaxValue("Temperature1");

                case nameof(RecipeLog.SV_F02):
                    return SettingViewModel.ReadMaxValue("Temperature2");

                case nameof(RecipeLog.SV_F03):
                    return SettingViewModel.ReadMaxValue("Temperature3");

                case nameof(RecipeLog.SV_F04):
                    return SettingViewModel.ReadMaxValue("Temperature4");

                case nameof(RecipeLog.SV_F05):
                    return SettingViewModel.ReadMaxValue("Temperature5");

                case nameof(RecipeLog.SV_F06):
                    return SettingViewModel.ReadMaxValue("Temperature6");

                default:
                    return null;
            }
        }


        private static OxyColor GenerateColor()
        {
            int index = Random.Shared.Next(AllKnownColors.Length);
            Color randomColor = Color.FromKnownColor(AllKnownColors[index]);

            return OxyColor.FromRgb(randomColor.R, randomColor.G, randomColor.B);
        }

        private static readonly KnownColor[] AllKnownColors = Enum.GetValues<KnownColor>();

        public static readonly Dictionary<string, (OxyColor, OxyColor)>  LogSeriesColor = new Dictionary<string, (OxyColor, OxyColor)> {
            { "PV_M01",( GenerateColor(),  GenerateColor()) }, { "SV_M01",( GenerateColor(),  GenerateColor()) },  { "PV_M02",( GenerateColor(),  GenerateColor()) }, { "SV_M02",( GenerateColor(),  GenerateColor()) }, 
            { "PV_M03",( GenerateColor(),  GenerateColor()) },  { "SV_M03",( GenerateColor(),  GenerateColor()) }, { "PV_M04",( GenerateColor(),  GenerateColor()) }, { "SV_M04",( GenerateColor(),  GenerateColor()) }, 
            { "PV_M05",( GenerateColor(),  GenerateColor()) }, { "SV_M05",( GenerateColor(),  GenerateColor()) }, { "PV_M06",( GenerateColor(),  GenerateColor()) }, { "SV_M06",( GenerateColor(),  GenerateColor()) }, 
            { "PV_M07",( GenerateColor(),  GenerateColor()) }, { "SV_M07",( GenerateColor(),  GenerateColor()) }, { "PV_M08",( GenerateColor(),  GenerateColor()) }, { "SV_M08",( GenerateColor(),  GenerateColor()) }, 
            { "PV_M09",( GenerateColor(),  GenerateColor()) },  { "SV_M09",( GenerateColor(),  GenerateColor()) }, { "PV_M10",( GenerateColor(),  GenerateColor()) }, { "SV_M10",( GenerateColor(),  GenerateColor()) },
            { "PV_M11",( GenerateColor(),  GenerateColor()) }, { "SV_M11",( GenerateColor(),  GenerateColor()) }, { "PV_M12",( GenerateColor(),  GenerateColor()) }, { "SV_M12",( GenerateColor(),  GenerateColor()) },
            { "PV_F01",( GenerateColor(),  GenerateColor()) }, { "SV_F01",( GenerateColor(),  GenerateColor()) }, { "PV_F02",( GenerateColor(),  GenerateColor()) }, { "SV_F02",( GenerateColor(),  GenerateColor()) },
            { "PV_F03",( GenerateColor(),  GenerateColor()) }, { "SV_F03",( GenerateColor(),  GenerateColor()) }, { "PV_F04",( GenerateColor(),  GenerateColor()) }, { "SV_F04",( GenerateColor(),  GenerateColor()) },
            { "PV_F05",( GenerateColor(),  GenerateColor()) }, { "SV_F05",( GenerateColor(),  GenerateColor()) }, { "PV_F06",( GenerateColor(),  GenerateColor()) }, { "SV_F06",( GenerateColor(),  GenerateColor()) },
            { "PV_IHT_KW",( GenerateColor(),  GenerateColor()) }, { "PV_SH_CW",( GenerateColor(),  GenerateColor()) }, { "PV_IHT_CW",( GenerateColor(),  GenerateColor()) }
        };
    }
}
