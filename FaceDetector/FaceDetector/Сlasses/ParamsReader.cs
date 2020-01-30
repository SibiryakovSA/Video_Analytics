using System.Linq;

namespace FaceDetector.Сlasses
{
    public static class ParamsReader
    {
        public static string GetParamValue(string[] parametrs, string parametr)
        {
            for (int i = 0; i < parametrs.Length; i++)
                if (parametrs.Length != i + 1 && parametrs[i] == parametr)
                    return parametrs[i + 1];

            return null;
        }

        public static bool IsTheParamInParametrs(string[] parametrs, string parametr)
        {
            string res = GetParamValue(parametrs, parametr);
            return res != null;
        }

        public static string GetHaarCascadeParam(string[] parametrs) => GetParamValue(parametrs, "-h");

        public static string GetImgParam(string[] parametrs) => GetParamValue(parametrs, "-i");

        public static string GetPathToSaveParam(string[] parametrs) => GetParamValue(parametrs, "-pts");
    }
}