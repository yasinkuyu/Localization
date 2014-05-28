// @yasinkuyu
// 05/08/2014

using System.Collections;

namespace Insya.Localization
{
    public class Inline : IInline
    {

        /// <summary>
        /// English(United States)
        /// </summary>
        /// <returns></returns>
        public string en_US { get; set; }

        /// <summary>
        /// Turkish (Turkey)
        /// </summary>
        /// <returns></returns>
        public string tr_TR { get; set; }

        /// <summary>
        /// Chinese (simplified, PRC)
        /// </summary>
        /// <returns></returns>
        public string zh_CN { get; set; }

        /// <summary>
        /// Russian(Russia)
        /// </summary>
        /// <returns></returns>
        public string ru_RU { get; set; }

        /// <summary>
        /// French(France)
        /// </summary>
        /// <returns></returns>
        public string fr_FR { get; set; }

        /// <summary>
        /// Spanish(Spain)
        /// </summary>
        /// <returns></returns>
        public string es_ES { get; set; }

        /// <summary>
        /// English(United Kingdom)
        /// </summary>
        /// <returns></returns>
        public string en_GB { get; set; }

        /// <summary>
        /// German(Germany)
        /// </summary>
        /// <returns></returns>
        public string de_DE { get; set; }

        /// <summary>
        /// Portuguese(Brazil)
        /// </summary>
        /// <returns></returns>
        public string pt_BR { get; set; }

        /// <summary>
        /// English(Canada)
        /// </summary>
        /// <returns></returns>
        public string en_CA { get; set; }

        /// <summary>
        /// Spanish (Mexico)
        /// </summary>
        /// <returns></returns>
        public string es_MX { get; set; }

        /// <summary>
        /// Italian (Italy)
        /// </summary>
        /// <returns></returns>
        public string it_IT { get; set; }

        /// <summary>
        /// Japanese(Japan)
        /// </summary>
        /// <returns></returns>
        public string ja_JP { get; set; }

        /// <summary>
        /// Inline localization (xml does not have to define)
        /// </summary>
        /// <param name="en"></param>
        /// <param name="tr"></param>
        /// <param name="es"></param>
        /// <param name="de"></param>
        /// <param name="fr"></param>
        /// <param name="it"></param>
        /// <param name="enCA"></param>
        /// <param name="enGB"></param>
        /// <param name="esMX"></param>
        /// <param name="jaJP"></param>
        /// <param name="ptBR"></param>
        /// <param name="ruRU"></param>
        /// <param name="zhCN"></param>
        public Inline(string en = "", string tr = "", string es = "", string de = "", string fr = "", string it = "", string enCA = "", string enGB = "", string esMX = "", string jaJP = "", string ptBR = "", string ruRU = "", string zhCN = "")
        {
            en_US = en;
            tr_TR = tr;
            de_DE = de;
            es_ES = es;
            fr_FR = fr;
            it_IT = it;
            en_CA = enCA;
            en_GB = enGB;
            es_MX = esMX;
            ja_JP = jaJP;
            pt_BR = ptBR;
            ru_RU = ruRU;
            zh_CN = zhCN;
        }

        public Inline()
        {
        }

       
    }

}
