namespace SapphireXR_App.Models
{
    public class RecipeLog
    {
#pragma warning disable CS8618 // null을 허용하지 않는 필드는 생성자를 종료할 때 null이 아닌 값을 포함해야 합니다. 'required' 한정자를 추가하거나 nullable로 선언하는 것이 좋습니다.
        public RecipeLog() { }
#pragma warning restore CS8618 // null을 허용하지 않는 필드는 생성자를 종료할 때 null이 아닌 값을 포함해야 합니다. 'required' 한정자를 추가하거나 nullable로 선언하는 것이 좋습니다.
        public RecipeLog(string name)
        {
            Step = name;
            SV_M01 = PLCService.ReadControlValue("MFC01");
            SV_M02 = PLCService.ReadControlValue("MFC02");
            SV_M03 = PLCService.ReadControlValue("MFC03");
            SV_M04 = PLCService.ReadControlValue("MFC04");
            SV_M05 = PLCService.ReadControlValue("MFC05");
            SV_M06 = PLCService.ReadControlValue("MFC06");
            SV_M07 = PLCService.ReadControlValue("MFC07");
            SV_M08 = PLCService.ReadControlValue("MFC08");
            SV_M09 = PLCService.ReadControlValue("MFC09");
            SV_M10 = PLCService.ReadControlValue("MFC10");
            SV_M11 = PLCService.ReadControlValue("MFC11");
            SV_M12 = PLCService.ReadControlValue("MFC12");
            SV_F01 = PLCService.ReadControlValue("Temperature1");
            SV_F02 = PLCService.ReadControlValue("Temperature2");
            SV_F03 = PLCService.ReadControlValue("Temperature3");
            SV_F04 = PLCService.ReadControlValue("Temperature4");
            SV_F05 = PLCService.ReadControlValue("Temperature5");
            SV_F06 = PLCService.ReadControlValue("Temperature6");

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
