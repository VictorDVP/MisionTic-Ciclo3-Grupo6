using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioSignoVital
    {
        //IEnumerable<SignoVital> GetAllSignosVitales();
        SignoVital AddSignoVital(SignoVital signoVital);
        /*SignoVital UpdateSignoVital(SignoVital signoVital);
        void DeleteSignoVital(int idSignoVital);
        SignoVital GetSignoVital(int idSignoVital);*/
    }
}