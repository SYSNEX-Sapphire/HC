namespace SapphireXR_App.Models
{
    public class RecipeLog
    {
#pragma warning disable CS8618 // null을 허용하지 않는 필드는 생성자를 종료할 때 null이 아닌 값을 포함해야 합니다. 'required' 한정자를 추가하거나 nullable로 선언하는 것이 좋습니다.
        public RecipeLog() { }
#pragma warning restore CS8618 // null을 허용하지 않는 필드는 생성자를 종료할 때 null이 아닌 값을 포함해야 합니다. 'required' 한정자를 추가하거나 nullable로 선언하는 것이 좋습니다.
        public RecipeLog(Recipe recipe)
        {
            Step = recipe.Name;
            SV_M01 = recipe.M01;
            SV_M02 = recipe.M02;
            SV_M03 = recipe.M03;
            SV_M04 = recipe.M04;
            SV_M05 = recipe.M05;
            SV_M06 = recipe.M06;
            SV_M07 = recipe.M07;
            SV_M08 = recipe.M08;
            SV_M09 = recipe.M09;
            SV_M10 = recipe.M10;
            SV_M11 = recipe.M11;
            SV_M12 = recipe.M12;
            SV_F01 = recipe.F01;
            SV_F02 = recipe.F02;
            SV_F03 = recipe.F03;
            SV_F04 = recipe.F04;
            SV_F05 = recipe.F05;
            SV_F06 = recipe.F06;

            PV_M01 = PLCService.ReadCurrentValue("MFC01");
            PV_M02 = PLCService.ReadCurrentValue("MFC02");
            PV_M03 = PLCService.ReadCurrentValue("MFC03");
            PV_M04 = PLCService.ReadCurrentValue("MFC04");
            PV_M05 = PLCService.ReadCurrentValue("MFC05");
            PV_M06 = PLCService.ReadCurrentValue("MFC06");
            PV_M07 = PLCService.ReadCurrentValue("MFC07");
            PV_M08 = PLCService.ReadCurrentValue("MFC08");
            PV_M09 = PLCService.ReadCurrentValue("MFC09");
            PV_M10 = PLCService.ReadCurrentValue("MFC10");
            PV_M11 = PLCService.ReadCurrentValue("MFC11");
            PV_M12 = PLCService.ReadCurrentValue("MFC12");
            PV_F01 = PLCService.ReadCurrentValue("Temperature1");
            PV_F02 = PLCService.ReadCurrentValue("Temperature2");
            PV_F03 = PLCService.ReadCurrentValue("Temperature3");
            PV_F04 = PLCService.ReadCurrentValue("Temperature4");
            PV_F05 = PLCService.ReadCurrentValue("Temperature5");
            PV_F06 = PLCService.ReadCurrentValue("Temperature6");
         

            LogTime = DateTime.Now;
        }

        public string Step { get; set; }
        public float PV_M01 { get; set; }
        public float PV_M02 { get; set; }
        public float PV_M03 { get; set; }
        public float PV_M04 { get; set; }
        public float PV_M05 { get; set; }
        public float PV_M06 { get; set; }
        public float PV_M07 { get; set; }
        public float PV_M08 { get; set; }
        public float PV_M09 { get; set; }
        public float PV_M10 { get; set; }
        public float PV_M11 { get; set; }
        public float PV_M12 { get; set; }
        public float PV_F01 { get; set; }
        public float PV_F02 { get; set; }
        public float PV_F03 { get; set; }
        public float PV_F04 { get; set; }
        public float PV_F05 { get; set; }
        public float PV_F06 { get; set; }
        public float PV_IHT_KW { get; set; }
        public float PV_SH_CW { get; set; }
        public float PV_IHT_CW { get; set; }
        public float SV_M01 { get; set; }
        public float SV_M02 { get; set; }
        public float SV_M03 { get; set; }
        public float SV_M04 { get; set; }
        public float SV_M05 { get; set; }
        public float SV_M06 { get; set; }
        public float SV_M07 { get; set; }
        public float SV_M08 { get; set; }
        public float SV_M09 { get; set; }
        public float SV_M10 { get; set; }
        public float SV_M11 { get; set; }
        public float SV_M12 { get; set; }
        public float SV_F01 { get; set; }
        public float SV_F02 { get; set; }
        public float SV_F03 { get; set; }
        public float SV_F04 { get; set; }
        public float SV_F05 { get; set; }
        public float SV_F06 { get; set; }


        public DateTime LogTime { get; set; }
    }
}
