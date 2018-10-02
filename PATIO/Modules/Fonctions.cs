using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PATIO.Classes;
using System.Windows.Forms;

namespace PATIO.Modules
{
    public class Fonctions
    {
        public AccesNet Acces;

        public TypePlan DonneTypePlan(string Libelle)
        {
            if (Libelle == TypePlan.DOSSIER.ToString()) { return TypePlan.DOSSIER; }
            if (Libelle == TypePlan.NATIONAL.ToString()) { return TypePlan.NATIONAL; }
            if (Libelle == TypePlan.REGIONAL.ToString()) { return TypePlan.REGIONAL; }
            if (Libelle == TypePlan.TERRITORIAL.ToString()) { return TypePlan.TERRITORIAL; }
            if (Libelle == TypePlan.TRANSVERSE.ToString()) { return TypePlan.TRANSVERSE; }
            if (Libelle == TypePlan.LOCAL.ToString()) { return TypePlan.LOCAL; }

            return TypePlan.DOSSIER;
        }

        public NiveauPlan DonneNiveauPlan(string Libelle)
        {
            if (Libelle == NiveauPlan.Niveau_2.ToString()) { return NiveauPlan.Niveau_2; }
            if (Libelle == NiveauPlan.Niveau_3.ToString()) { return NiveauPlan.Niveau_3; }
            if (Libelle == NiveauPlan.Niveau_4.ToString()) { return NiveauPlan.Niveau_4; }

            return NiveauPlan.Niveau_2;
        }

        public TypeObjectif DonneTypeObjectif(string Libelle)
        {
            if (Libelle == TypeObjectif.DOSSIER.ToString()) { return TypeObjectif.DOSSIER; }
            if (Libelle == TypeObjectif.AXE.ToString()) { return TypeObjectif.AXE; }
            if (Libelle == TypeObjectif.STRATEGIQUE.ToString()) { return TypeObjectif.STRATEGIQUE; }
            if (Libelle == TypeObjectif.OPERATIONNEL.ToString()) { return TypeObjectif.OPERATIONNEL; }

            return TypeObjectif.DOSSIER;
        }

        public Meteo DonneMeteo(string Libelle)
        {
            if (Libelle == Meteo.SOLEIL.ToString()) { return Meteo.SOLEIL; }
            if (Libelle == Meteo.SOLEIL_NUAGES.ToString()) { return Meteo.SOLEIL_NUAGES; }
            if (Libelle == Meteo.NUAGES.ToString()) { return Meteo.NUAGES; }
            if (Libelle == Meteo.ORAGE.ToString()) { return Meteo.ORAGE; }

            return Meteo.SOLEIL;
        }

        public TxAvancement DonneTxAvancement(string Libelle)
        {
            if (Libelle == TxAvancement.PCT_0_25.ToString()) { return TxAvancement.PCT_0_25; }
            if (Libelle == TxAvancement.PCT_25_50.ToString()) { return TxAvancement.PCT_25_50; }
            if (Libelle == TxAvancement.PCT_50_75.ToString()) { return TxAvancement.PCT_50_75; }
            if (Libelle == TxAvancement.PCT_75_100.ToString()) { return TxAvancement.PCT_75_100; }

            return TxAvancement.PCT_0_25;
        }

        public TypeAction DonneTypeAction(string Libelle)
        {
            if (Libelle == TypeAction.DOSSIER.ToString()) { return TypeAction.DOSSIER; }
            if (Libelle == TypeAction.ACTION.ToString()) { return TypeAction.ACTION; }
            if (Libelle == TypeAction.OPERATION.ToString()) { return TypeAction.OPERATION; }

            return TypeAction.DOSSIER;
        }

        public TypeIndicateur DonneTypeIndicateur(string Libelle)
        {
            if (Libelle == TypeIndicateur.DOSSIER.ToString()) { return TypeIndicateur.DOSSIER; }
            if (Libelle == TypeIndicateur.IMPACT.ToString()) { return TypeIndicateur.IMPACT; }
            if (Libelle == TypeIndicateur.MOYEN.ToString()) { return TypeIndicateur.MOYEN; }
            if (Libelle == TypeIndicateur.RESULTAT.ToString()) { return TypeIndicateur.RESULTAT; }

            return TypeIndicateur.DOSSIER;
        }

        public TypeLicence DonneTypeLicence(string Libelle)
        {
            if (Libelle == TypeLicence.ADMINISTRATEUR.ToString()) { return TypeLicence.ADMINISTRATEUR; }
            if (Libelle == TypeLicence.PILOTE.ToString()) { return TypeLicence.PILOTE; }
            if (Libelle == TypeLicence.VISITEUR.ToString()) { return TypeLicence.VISITEUR; }

            return TypeLicence.VISITEUR;
        }
    }
}
