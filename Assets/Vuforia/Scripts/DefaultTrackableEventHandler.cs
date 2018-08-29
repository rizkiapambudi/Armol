/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        public Transform PanelScanMarker;
        public Transform PanelMenu;
        public Transform PanelInformasi;
        public Transform TextTargetName;
        public Transform TextDescription;
        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            PanelMenu.gameObject.SetActive(true);
            PanelInformasi.gameObject.SetActive(true);
            PanelScanMarker.gameObject.SetActive(false);
            TextTargetName.gameObject.SetActive(true);
            TextDescription.gameObject.SetActive(true);

            if (mTrackableBehaviour.TrackableName == "Ag") {
                TextDescription.GetComponent<Text>().text = "Ini merupakan unsur Ag atau Argentum, lebih umum dikenal sebagai perak";
            } else if (mTrackableBehaviour.TrackableName == "Al") {
                TextDescription.GetComponent<Text>().text = "Ini merupakan unsur Al atau Aluminium";
            } else if (mTrackableBehaviour.TrackableName == "Br") {
                TextDescription.GetComponent<Text>().text = "Ini merupakan unsur Br atau Brom";
            } else if (mTrackableBehaviour.TrackableName == "Ca") {
                TextDescription.GetComponent<Text>().text = "Ini merupakan unsur Ca atau Kalsium";
            } else if (mTrackableBehaviour.TrackableName == "Cr") {
                TextDescription.GetComponent<Text>().text = "Ini merupakan unsur Cr atau Krom";
            } else if (mTrackableBehaviour.TrackableName == "Cl") {
                TextDescription.GetComponent<Text>().text = "Ini merupakan unsur Cl atau Klor";
            } else if (mTrackableBehaviour.TrackableName == "Cu") {
                TextDescription.GetComponent<Text>().text = "Ini merupakan unsur Cu atau Cuprum, lebih umum dikenal sebagai tembaga";
            } else if (mTrackableBehaviour.TrackableName == "Fe") {
                TextDescription.GetComponent<Text>().text = "Ini merupakan unsur Fe atau Ferrum, lebih umum dikenal sebagai besi";
            } else if (mTrackableBehaviour.TrackableName == "Mg") {
                TextDescription.GetComponent<Text>().text = "Ini merupakan unsur Mg atau Magnesium";
            } else if (mTrackableBehaviour.TrackableName == "Na") {
                TextDescription.GetComponent<Text>().text = "Ini merupakan unsur Na atau Natrium";
            } else if (mTrackableBehaviour.TrackableName == "Zn") {
                TextDescription.GetComponent<Text>().text = "Ini merupakan unsur Zn atau Zink (Seng)";
            } else if (
                mTrackableBehaviour.TrackableName == "AgBr" || mTrackableBehaviour.TrackableName == "BrAg"
                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul AgBr atau Perak Bromide, berguna sebagai film fotografi";
            } else if (
                mTrackableBehaviour.TrackableName == "AgI" || mTrackableBehaviour.TrackableName == "IAg"
                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul AgI atau Perak Iodida, berguna sebagai film fotografi";
            } else if (
                mTrackableBehaviour.TrackableName == "AlAlOOO" || mTrackableBehaviour.TrackableName == "AlOAlOO" ||
                mTrackableBehaviour.TrackableName == "AlOOAlO" || mTrackableBehaviour.TrackableName == "AlOOOAl" ||
                mTrackableBehaviour.TrackableName == "OAlAlOO" || mTrackableBehaviour.TrackableName == "OAlOAlO" ||
                mTrackableBehaviour.TrackableName == "OAlOOAl" || mTrackableBehaviour.TrackableName == "OOAlAlO" ||
                mTrackableBehaviour.TrackableName == "OOAlOAl" || mTrackableBehaviour.TrackableName == "OOOAlAl"
                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul Al2O3 atau Aluminium Oksida, berguna sebagai penggosok besi";
            } else if (
                mTrackableBehaviour.TrackableName == "CO" || mTrackableBehaviour.TrackableName == "OC"
                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CO atau Karbon Monoksida, berguna sebagai reduktor pada pengolahan besi";
            } else if (
                mTrackableBehaviour.TrackableName == "COO" || 
                mTrackableBehaviour.TrackableName == "OCO" || 
                mTrackableBehaviour.TrackableName == "OOC"
                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CO2 atau Karbon Dioksida, berguna sebagai pembentuk minuman berkarbonat dan air soda";
            } else if (

                mTrackableBehaviour.TrackableName == "CClClFF" || mTrackableBehaviour.TrackableName == "CClFClF" ||
                mTrackableBehaviour.TrackableName == "CClFFCl" || mTrackableBehaviour.TrackableName == "CFClClF" ||
                mTrackableBehaviour.TrackableName == "CFClFCl" || mTrackableBehaviour.TrackableName == "CFFClCl" ||
                mTrackableBehaviour.TrackableName == "ClCClFF" || mTrackableBehaviour.TrackableName == "ClCFClF" ||
                mTrackableBehaviour.TrackableName == "ClCFFCl" || mTrackableBehaviour.TrackableName == "ClClCFF" ||

                mTrackableBehaviour.TrackableName == "ClClFCF" || mTrackableBehaviour.TrackableName == "ClClFFC" ||
                mTrackableBehaviour.TrackableName == "ClFCClF" || mTrackableBehaviour.TrackableName == "ClFCFCl" ||
                mTrackableBehaviour.TrackableName == "ClFClCF" || mTrackableBehaviour.TrackableName == "ClFClFC" ||
                mTrackableBehaviour.TrackableName == "ClFFCCl" || mTrackableBehaviour.TrackableName == "ClFFClC" ||
                mTrackableBehaviour.TrackableName == "FCClClF" || mTrackableBehaviour.TrackableName == "FCClFCl" ||

                mTrackableBehaviour.TrackableName == "FCFClCl" || mTrackableBehaviour.TrackableName == "FClCClF" ||
                mTrackableBehaviour.TrackableName == "FClCFCl" || mTrackableBehaviour.TrackableName == "FClClCF" ||
                mTrackableBehaviour.TrackableName == "FClClFC" || mTrackableBehaviour.TrackableName == "FClFCCl" ||
                mTrackableBehaviour.TrackableName == "FClFClC" || mTrackableBehaviour.TrackableName == "FFCClCl" ||
                mTrackableBehaviour.TrackableName == "FFClCCl" || mTrackableBehaviour.TrackableName == "FFClClC"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CCl2F2 atau Freon-12, berguna sebagai zat pendingi dan lemari es AC";
            } else if (
                
                mTrackableBehaviour.TrackableName == "BrCHHH" || mTrackableBehaviour.TrackableName == "BrHCHH" ||
                mTrackableBehaviour.TrackableName == "BrHHCH" || mTrackableBehaviour.TrackableName == "BrHHHC" ||
                mTrackableBehaviour.TrackableName == "CBrHHH" || mTrackableBehaviour.TrackableName == "CHBrHH" ||
                mTrackableBehaviour.TrackableName == "CHHBrH" || mTrackableBehaviour.TrackableName == "CHHHBr" ||
                mTrackableBehaviour.TrackableName == "HBrCHH" || mTrackableBehaviour.TrackableName == "HBrHCH" ||

                mTrackableBehaviour.TrackableName == "HBrHHC" || mTrackableBehaviour.TrackableName == "HCBrHH" ||
                mTrackableBehaviour.TrackableName == "HCHBrH" || mTrackableBehaviour.TrackableName == "HCHHBr" ||
                mTrackableBehaviour.TrackableName == "HHBrCH" || mTrackableBehaviour.TrackableName == "HHBrHC" ||
                mTrackableBehaviour.TrackableName == "HHCBrH" || mTrackableBehaviour.TrackableName == "HHCHBr" ||
                mTrackableBehaviour.TrackableName == "HHHBrC" || mTrackableBehaviour.TrackableName == "HHHCBr"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CH3Br atau Metil Bromide, berguna sebagai zat pemadam kebakaran";
            } else if (

                mTrackableBehaviour.TrackableName == "CAOOOOS" || mTrackableBehaviour.TrackableName == "CAOOOSO" ||
                mTrackableBehaviour.TrackableName == "CAOOSOO" || mTrackableBehaviour.TrackableName == "CAOSOOO" ||
                mTrackableBehaviour.TrackableName == "CASOOOO" || mTrackableBehaviour.TrackableName == "OCAOOOS" ||
                mTrackableBehaviour.TrackableName == "OCAOOSO" || mTrackableBehaviour.TrackableName == "OCAOSOO" ||
                mTrackableBehaviour.TrackableName == "OCASOOO" || mTrackableBehaviour.TrackableName == "OOCAOOS" ||

                mTrackableBehaviour.TrackableName == "OOCAOSO" || mTrackableBehaviour.TrackableName == "OOCASOO" ||
                mTrackableBehaviour.TrackableName == "OOOCAOS" || mTrackableBehaviour.TrackableName == "OOOCASO" ||
                mTrackableBehaviour.TrackableName == "OOOOCAS" || mTrackableBehaviour.TrackableName == "OOOOSCA" ||
                mTrackableBehaviour.TrackableName == "OOOSCAO" || mTrackableBehaviour.TrackableName == "OOOSOCA" ||
                mTrackableBehaviour.TrackableName == "OOSCAOO" || mTrackableBehaviour.TrackableName == "OOSOCAO" ||

                mTrackableBehaviour.TrackableName == "OOSOOCA" || mTrackableBehaviour.TrackableName == "OSCAOOO" ||
                mTrackableBehaviour.TrackableName == "OSOCAOO" || mTrackableBehaviour.TrackableName == "OSOOCAO" ||
                mTrackableBehaviour.TrackableName == "OSOOOCA" || mTrackableBehaviour.TrackableName == "SCAOOOO" ||
                mTrackableBehaviour.TrackableName == "SOCAOOO" || mTrackableBehaviour.TrackableName == "SOOCAOO" ||
                mTrackableBehaviour.TrackableName == "SOOOCAO" || mTrackableBehaviour.TrackableName == "SOOOOCA"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CaSO4 atau Kalsium Sulfat, berguna sebagai pembuat gips";
            }else if (
                
                mTrackableBehaviour.TrackableName == "CHIII" || mTrackableBehaviour.TrackableName == "CIHII" ||
                mTrackableBehaviour.TrackableName == "CIIHI" || mTrackableBehaviour.TrackableName == "CIIIH" ||
                mTrackableBehaviour.TrackableName == "HCIII" || mTrackableBehaviour.TrackableName == "HICII" ||
                mTrackableBehaviour.TrackableName == "HIICI" || mTrackableBehaviour.TrackableName == "HIIIC" ||
                mTrackableBehaviour.TrackableName == "ICHII" || mTrackableBehaviour.TrackableName == "ICIHI" ||

                mTrackableBehaviour.TrackableName == "ICIIH" || mTrackableBehaviour.TrackableName == "IHCII" ||
                mTrackableBehaviour.TrackableName == "IHICI" || mTrackableBehaviour.TrackableName == "IHIIC" ||
                mTrackableBehaviour.TrackableName == "IICHI" || mTrackableBehaviour.TrackableName == "IICIH" ||
                mTrackableBehaviour.TrackableName == "IIHCI" || mTrackableBehaviour.TrackableName == "IIHIC" ||
                mTrackableBehaviour.TrackableName == "IIICH" || mTrackableBehaviour.TrackableName == "IIIHC"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CHI3 atau Iodoform, berguna sebagai zat organik";
            } else if (
                
                mTrackableBehaviour.TrackableName == "CII" || mTrackableBehaviour.TrackableName == "ICI" ||
                mTrackableBehaviour.TrackableName == "IIC"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CI2 atau Disinfekan, berguna sebagai pembunuh kuman";
            } else if (
                
                mTrackableBehaviour.TrackableName == "CAO" || mTrackableBehaviour.TrackableName == "OCA"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CaO atau Kalsium Oksida, berguna sebagai gamping, semen, dan industri semen";
            }  else if (
                
                mTrackableBehaviour.TrackableName == "CACC" || mTrackableBehaviour.TrackableName == "CCAC" ||
                mTrackableBehaviour.TrackableName == "CCCA"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CaC2 atau Kalsium Karbida, berguna sebagai pembuat gas asitelin untuk pengelas";
            } else if (
                
                mTrackableBehaviour.TrackableName == "CACOOO" || mTrackableBehaviour.TrackableName == "CAOCOO" ||
                mTrackableBehaviour.TrackableName == "CAOOCO" || mTrackableBehaviour.TrackableName == "CAOOOC" ||
                mTrackableBehaviour.TrackableName == "CCAOOO" || mTrackableBehaviour.TrackableName == "COCAOO" ||
                mTrackableBehaviour.TrackableName == "COOCAO" || mTrackableBehaviour.TrackableName == "COOOCA" ||
                mTrackableBehaviour.TrackableName == "OCACOO" || mTrackableBehaviour.TrackableName == "OCAOCO" ||

                mTrackableBehaviour.TrackableName == "OCAOOC" || mTrackableBehaviour.TrackableName == "OCCAOO" ||
                mTrackableBehaviour.TrackableName == "OCOCAO" || mTrackableBehaviour.TrackableName == "OCOOCA" ||
                mTrackableBehaviour.TrackableName == "OOCACO" || mTrackableBehaviour.TrackableName == "OOCAOC" ||
                mTrackableBehaviour.TrackableName == "OOCCAO" || mTrackableBehaviour.TrackableName == "OOCOCA" ||
                mTrackableBehaviour.TrackableName == "OOOCAC" || mTrackableBehaviour.TrackableName == "OOOCCA"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CaCO3 atau Kalsium Karbonat, berguna sebagai pengecat bangunan";
            } else if (
                
                mTrackableBehaviour.TrackableName == "ClClClCH" || mTrackableBehaviour.TrackableName == "ClHClCCl" ||
                mTrackableBehaviour.TrackableName == "ClClClHC" || mTrackableBehaviour.TrackableName == "ClHCClCl" ||
                mTrackableBehaviour.TrackableName == "ClClCClH" || mTrackableBehaviour.TrackableName == "CClClClH" ||
                mTrackableBehaviour.TrackableName == "ClClCHCl" || mTrackableBehaviour.TrackableName == "CClClHCl" ||
                mTrackableBehaviour.TrackableName == "ClClHClC" || mTrackableBehaviour.TrackableName == "CClHClCl" ||

                mTrackableBehaviour.TrackableName == "ClClHCCl" || mTrackableBehaviour.TrackableName == "CHClClCl" ||
                mTrackableBehaviour.TrackableName == "ClCClClH" || mTrackableBehaviour.TrackableName == "HClClClC" ||
                mTrackableBehaviour.TrackableName == "ClCClHCl" || mTrackableBehaviour.TrackableName == "HClClCCl" ||
                mTrackableBehaviour.TrackableName == "ClCHClCl" || mTrackableBehaviour.TrackableName == "HClCClCl" ||
                mTrackableBehaviour.TrackableName == "ClHClClC" || mTrackableBehaviour.TrackableName == "HCClClCl"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CHCl3 atau Kloroform, berguna sebagai bahan pembius";
            } else if (

                mTrackableBehaviour.TrackableName == "CHHHHO" || mTrackableBehaviour.TrackableName == "HHHHOC" ||
                mTrackableBehaviour.TrackableName == "CHHHOH" || mTrackableBehaviour.TrackableName == "HHHOCH" ||
                mTrackableBehaviour.TrackableName == "CHHOHH" || mTrackableBehaviour.TrackableName == "HHHOHC" ||
                mTrackableBehaviour.TrackableName == "CHOHHH" || mTrackableBehaviour.TrackableName == "HHOCHH" ||
                mTrackableBehaviour.TrackableName == "COHHHH" || mTrackableBehaviour.TrackableName == "HHOHCH" ||

                mTrackableBehaviour.TrackableName == "HCHHHO" || mTrackableBehaviour.TrackableName == "HHOHHC" ||
                mTrackableBehaviour.TrackableName == "HCHHOH" || mTrackableBehaviour.TrackableName == "HOCHHH" ||
                mTrackableBehaviour.TrackableName == "HCHOHH" || mTrackableBehaviour.TrackableName == "HOHCHH" ||
                mTrackableBehaviour.TrackableName == "HCOHHH" || mTrackableBehaviour.TrackableName == "HOHHCH" ||
                mTrackableBehaviour.TrackableName == "HHCHHO" || mTrackableBehaviour.TrackableName == "HOHHHC" ||

                mTrackableBehaviour.TrackableName == "HHCHOH" || mTrackableBehaviour.TrackableName == "OCHHHH" ||
                mTrackableBehaviour.TrackableName == "HHCOHH" || mTrackableBehaviour.TrackableName == "OHCHHH" ||
                mTrackableBehaviour.TrackableName == "HHHCHO" || mTrackableBehaviour.TrackableName == "OHHCHH" ||
                mTrackableBehaviour.TrackableName == "HHHCOH" || mTrackableBehaviour.TrackableName == "OHHHCH" ||
                mTrackableBehaviour.TrackableName == "HHHHCO" || mTrackableBehaviour.TrackableName == "OHHHHC"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CH3OH atau Metanol, berguna sebagai alkohol";
            } else if (
                
                mTrackableBehaviour.TrackableName == "CRO" || mTrackableBehaviour.TrackableName == "OCR"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CrO atau Kromium (II) Oksida, berguna sebagai pewarna dalam percetakan, industri tekstil dan keramik";
            } else if (
                
                mTrackableBehaviour.TrackableName == "CrClClCl" || mTrackableBehaviour.TrackableName == "ClClCrCl" ||
                mTrackableBehaviour.TrackableName == "ClCrClCl" || mTrackableBehaviour.TrackableName == "ClClClCr"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CrCl3 atau Kromium (II) Klorida, berguna sebagai zat pewarna hijau dalam pembuatan keramik";
            } else if (
                
                mTrackableBehaviour.TrackableName == "CuClCl" || mTrackableBehaviour.TrackableName == "ClClCu" ||
                mTrackableBehaviour.TrackableName == "ClCuCl"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul CuCl2 atau Tembaga Klorida, berguna sebagai pewarna keramik dan gelas, pabrik tinta dan fotografi";
            } else if (
                
                mTrackableBehaviour.TrackableName == "FeO" || mTrackableBehaviour.TrackableName == "OFe"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul FeO atau Besi (II) Oksida, berguna sebagai pewarna ubin";
            } else if (
                
                mTrackableBehaviour.TrackableName == "HCN" || mTrackableBehaviour.TrackableName == "HNC" ||
                mTrackableBehaviour.TrackableName == "CHN" || mTrackableBehaviour.TrackableName == "CNH" ||
                mTrackableBehaviour.TrackableName == "NHC" || mTrackableBehaviour.TrackableName == "NCH"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul HCN atau Asam Sianida, berguna sebagai pembasmi hama dan untuk obat-obatan";
            } else if (
                
                mTrackableBehaviour.TrackableName == "HCl" || mTrackableBehaviour.TrackableName == "ClH"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul HCl atau Asam Klorida, berguna sebagai pembersih lantai";
            } else if (
                
                mTrackableBehaviour.TrackableName == "HClO" || mTrackableBehaviour.TrackableName == "ClOH" ||
                mTrackableBehaviour.TrackableName == "HOCl" || mTrackableBehaviour.TrackableName == "OHCl" ||
                mTrackableBehaviour.TrackableName == "ClHO" || mTrackableBehaviour.TrackableName == "OClH"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul HClO atau Asam Hipoklorit, berguna sebagai Disinfekan dan agen pemutih";
            } else if (
                
                mTrackableBehaviour.TrackableName == "HF" || mTrackableBehaviour.TrackableName == "FH"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul HF atau Asam Flourida, berguna sebagai pembuat freon";
            } else if (
                
                mTrackableBehaviour.TrackableName == "HNOOO" || mTrackableBehaviour.TrackableName == "OHOON" ||
                mTrackableBehaviour.TrackableName == "HONOO" || mTrackableBehaviour.TrackableName == "ONHOO" ||
                mTrackableBehaviour.TrackableName == "HOONO" || mTrackableBehaviour.TrackableName == "ONOHO" ||
                mTrackableBehaviour.TrackableName == "HOOON" || mTrackableBehaviour.TrackableName == "ONOOH" ||
                mTrackableBehaviour.TrackableName == "NHOOO" || mTrackableBehaviour.TrackableName == "OOHNO" ||

                mTrackableBehaviour.TrackableName == "NOHOO" || mTrackableBehaviour.TrackableName == "OOHON" ||
                mTrackableBehaviour.TrackableName == "NOOHO" || mTrackableBehaviour.TrackableName == "OONHO" ||
                mTrackableBehaviour.TrackableName == "NOOOH" || mTrackableBehaviour.TrackableName == "OONOH" ||
                mTrackableBehaviour.TrackableName == "OHNOO" || mTrackableBehaviour.TrackableName == "OOOHN" ||
                mTrackableBehaviour.TrackableName == "OHONO" || mTrackableBehaviour.TrackableName == "OOONH"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul HNO3 atau Asam Nitrat, berguna sebagai bahan peledak";
            } else if (
                
                mTrackableBehaviour.TrackableName == "CHHO" || mTrackableBehaviour.TrackableName == "CHOH" ||
                mTrackableBehaviour.TrackableName == "COHH" || mTrackableBehaviour.TrackableName == "HCHO" ||
                mTrackableBehaviour.TrackableName == "HCOH" || mTrackableBehaviour.TrackableName == "HHCO" ||
                mTrackableBehaviour.TrackableName == "HHOC" || mTrackableBehaviour.TrackableName == "HOCH" ||
                mTrackableBehaviour.TrackableName == "HOHC" || mTrackableBehaviour.TrackableName == "OCHH" ||
                mTrackableBehaviour.TrackableName == "OHCH" || mTrackableBehaviour.TrackableName == "OHHC"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul H2CO atau Formalin, berguna sebagai pengawet jasad atau kadaver";
            } else if (
                
                mTrackableBehaviour.TrackableName == "HHO" || mTrackableBehaviour.TrackableName == "HOH" ||
                mTrackableBehaviour.TrackableName == "OHH"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul H2O atau Air, berguna sebagai air, pelarut, pembersih, dll.";
            } else if (
                
                mTrackableBehaviour.TrackableName == "HHOOOOS" || mTrackableBehaviour.TrackableName == "OOHSOHO" ||
                mTrackableBehaviour.TrackableName == "HHOOOSO" || mTrackableBehaviour.TrackableName == "OOHSOOH" ||
                mTrackableBehaviour.TrackableName == "HHOOSOO" || mTrackableBehaviour.TrackableName == "OOOHHOS" ||
                mTrackableBehaviour.TrackableName == "HHOSOOO" || mTrackableBehaviour.TrackableName == "OOOHHSO" ||
                mTrackableBehaviour.TrackableName == "HHSOOOO" || mTrackableBehaviour.TrackableName == "OOOHOHS" ||

                mTrackableBehaviour.TrackableName == "HOHOOOS" || mTrackableBehaviour.TrackableName == "OOOHOSH" ||
                mTrackableBehaviour.TrackableName == "HOHOOSO" || mTrackableBehaviour.TrackableName == "OOOHSHO" ||
                mTrackableBehaviour.TrackableName == "HOHOSOO" || mTrackableBehaviour.TrackableName == "OOOHSOH" ||
                mTrackableBehaviour.TrackableName == "HOHSOOO" || mTrackableBehaviour.TrackableName == "OOOOHHS" ||
                mTrackableBehaviour.TrackableName == "HOOHOOS" || mTrackableBehaviour.TrackableName == "OOOOHSH" ||

                mTrackableBehaviour.TrackableName == "HOOHOSO" || mTrackableBehaviour.TrackableName == "OOOOSHH" ||
                mTrackableBehaviour.TrackableName == "HOOHSOO" || mTrackableBehaviour.TrackableName == "OOOSHHO" ||
                mTrackableBehaviour.TrackableName == "HOOOHOS" || mTrackableBehaviour.TrackableName == "OOOSHOH" ||
                mTrackableBehaviour.TrackableName == "HOOOHSO" || mTrackableBehaviour.TrackableName == "OOOSOHH" ||
                mTrackableBehaviour.TrackableName == "HOOOOHS" || mTrackableBehaviour.TrackableName == "OOSHHOO" ||

                mTrackableBehaviour.TrackableName == "HOOOOSH" || mTrackableBehaviour.TrackableName == "OOSHOHO" ||
                mTrackableBehaviour.TrackableName == "HOOOSHO" || mTrackableBehaviour.TrackableName == "OOSHOOH" ||
                mTrackableBehaviour.TrackableName == "HOOOSOH" || mTrackableBehaviour.TrackableName == "OOSOHHO" ||
                mTrackableBehaviour.TrackableName == "HOOSHOO" || mTrackableBehaviour.TrackableName == "OOSOHOH" ||
                mTrackableBehaviour.TrackableName == "HOOSOHO" || mTrackableBehaviour.TrackableName == "OOSOOHH" ||

                mTrackableBehaviour.TrackableName == "HOOSOOH" || mTrackableBehaviour.TrackableName == "OSHHOOO" ||
                mTrackableBehaviour.TrackableName == "HOSHOOO" || mTrackableBehaviour.TrackableName == "OSHOHOO" ||
                mTrackableBehaviour.TrackableName == "HOSOHOO" || mTrackableBehaviour.TrackableName == "OSHOOHO" ||
                mTrackableBehaviour.TrackableName == "HOSOOHO" || mTrackableBehaviour.TrackableName == "OSHOOOH" ||
                mTrackableBehaviour.TrackableName == "HOSOOOH" || mTrackableBehaviour.TrackableName == "OSOHHOO" ||

                mTrackableBehaviour.TrackableName == "HSHOOOO" || mTrackableBehaviour.TrackableName == "OSOHOHO" ||
                mTrackableBehaviour.TrackableName == "HSOHOOO" || mTrackableBehaviour.TrackableName == "OSOHOOH" ||
                mTrackableBehaviour.TrackableName == "HSOOHOO" || mTrackableBehaviour.TrackableName == "OSOOHHO" ||
                mTrackableBehaviour.TrackableName == "HSOOOHO" || mTrackableBehaviour.TrackableName == "OSOOHOH" ||
                mTrackableBehaviour.TrackableName == "HSOOOOH" || mTrackableBehaviour.TrackableName == "OSOOOHH" ||

                mTrackableBehaviour.TrackableName == "OHHOOOS" || mTrackableBehaviour.TrackableName == "SHHOOOO" ||
                mTrackableBehaviour.TrackableName == "OHHOOSO" || mTrackableBehaviour.TrackableName == "SHOHOOO" ||
                mTrackableBehaviour.TrackableName == "OHHOSOO" || mTrackableBehaviour.TrackableName == "SHOOHOO" ||
                mTrackableBehaviour.TrackableName == "OHHSOOO" || mTrackableBehaviour.TrackableName == "SHOOOHO" ||
                mTrackableBehaviour.TrackableName == "OHOHOOS" || mTrackableBehaviour.TrackableName == "SHOOOOH" ||

                mTrackableBehaviour.TrackableName == "OHOHOSO" || mTrackableBehaviour.TrackableName == "SOHHOOO" ||
                mTrackableBehaviour.TrackableName == "OHOHSOO" || mTrackableBehaviour.TrackableName == "SOHOHOO" ||
                mTrackableBehaviour.TrackableName == "OHOOHOS" || mTrackableBehaviour.TrackableName == "SOHOOHO" ||
                mTrackableBehaviour.TrackableName == "OHOOHSO" || mTrackableBehaviour.TrackableName == "SOHOOOH" ||
                mTrackableBehaviour.TrackableName == "OHOOOHS" || mTrackableBehaviour.TrackableName == "SOOHHOO" ||

                mTrackableBehaviour.TrackableName == "OHOOOSH" || mTrackableBehaviour.TrackableName == "SOOHOHO" ||
                mTrackableBehaviour.TrackableName == "OHOOSHO" || mTrackableBehaviour.TrackableName == "SOOHOOH" ||
                mTrackableBehaviour.TrackableName == "OHOOSOH" || mTrackableBehaviour.TrackableName == "SOOOHHO" ||
                mTrackableBehaviour.TrackableName == "OHOSHOO" || mTrackableBehaviour.TrackableName == "SOOOHOH" ||
                mTrackableBehaviour.TrackableName == "OHOSOHO" || mTrackableBehaviour.TrackableName == "SOOOOHH" ||

                mTrackableBehaviour.TrackableName == "OHOSOOH" || 
                mTrackableBehaviour.TrackableName == "OHSHOOO" || 
                mTrackableBehaviour.TrackableName == "OHSOHOO" || 
                mTrackableBehaviour.TrackableName == "OHSOOHO" || 
                mTrackableBehaviour.TrackableName == "OHSOOOH" || 

                mTrackableBehaviour.TrackableName == "OOHHOOS" || 
                mTrackableBehaviour.TrackableName == "OOHHOSO" || 
                mTrackableBehaviour.TrackableName == "OOHHSOO" || 
                mTrackableBehaviour.TrackableName == "OOHOHOS" || 
                mTrackableBehaviour.TrackableName == "OOHOHSO" || 

                mTrackableBehaviour.TrackableName == "OOHOOHS" || 
                mTrackableBehaviour.TrackableName == "OOHOOSH" || 
                mTrackableBehaviour.TrackableName == "OOHOSHO" || 
                mTrackableBehaviour.TrackableName == "OOHOSOH" || 
                mTrackableBehaviour.TrackableName == "OOHSHOO"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul H2SO4 atau Asam Sulfat, berguna sebagai pengisi aki (accu)";
            } else if (
                
                mTrackableBehaviour.TrackableName == "KBr" || mTrackableBehaviour.TrackableName == "BrK"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul KBr atau Kalium Bromide, berguna sebagai obat-obatan";
            } else if (
                
                mTrackableBehaviour.TrackableName == "ClKOOO" || mTrackableBehaviour.TrackableName == "OKOClO" ||
                mTrackableBehaviour.TrackableName == "ClOKOO" || mTrackableBehaviour.TrackableName == "OKOOCl" ||
                mTrackableBehaviour.TrackableName == "ClOOKO" || mTrackableBehaviour.TrackableName == "OOClKO" ||
                mTrackableBehaviour.TrackableName == "ClOOOK" || mTrackableBehaviour.TrackableName == "OOClOK" ||
                mTrackableBehaviour.TrackableName == "KClOOO" || mTrackableBehaviour.TrackableName == "OOKClO" ||
                mTrackableBehaviour.TrackableName == "KOClOO" || mTrackableBehaviour.TrackableName == "OOKOCl" ||

                mTrackableBehaviour.TrackableName == "KOOClO" || mTrackableBehaviour.TrackableName == "OOOClK" ||
                mTrackableBehaviour.TrackableName == "KOOOCl" || mTrackableBehaviour.TrackableName == "OOOKCl" ||
                mTrackableBehaviour.TrackableName == "OClKOO" || mTrackableBehaviour.TrackableName == "OClOKO" ||
                mTrackableBehaviour.TrackableName == "OClOOK" || mTrackableBehaviour.TrackableName == "OKClOO" 

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul KClO3 atau Kalium Klorat, berguna sebagai kepala batang korek api";
            } else if (
                
                mTrackableBehaviour.TrackableName == "KCl" || mTrackableBehaviour.TrackableName == "ClK"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul KCl atau Kalium Klorida, berguna sebagai pupuk tanaman";
            } else if (
                
                mTrackableBehaviour.TrackableName == "KI" || mTrackableBehaviour.TrackableName == "IK"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul KI atau Kalium Iodida, berguna sebagai obat-obatan";
            } else if (
                
                mTrackableBehaviour.TrackableName == "IKOOO" || mTrackableBehaviour.TrackableName == "OIOOK" ||
                mTrackableBehaviour.TrackableName == "IOKOO" || mTrackableBehaviour.TrackableName == "OKIOO" ||
                mTrackableBehaviour.TrackableName == "IOOKO" || mTrackableBehaviour.TrackableName == "OKOIO" ||
                mTrackableBehaviour.TrackableName == "IOOOK" || mTrackableBehaviour.TrackableName == "OKOOI" ||
                mTrackableBehaviour.TrackableName == "KIOOO" || mTrackableBehaviour.TrackableName == "OOIKO" ||
                mTrackableBehaviour.TrackableName == "KOIOO" || mTrackableBehaviour.TrackableName == "OOIOK" ||

                mTrackableBehaviour.TrackableName == "KOOIO" || mTrackableBehaviour.TrackableName == "OOKIO" ||
                mTrackableBehaviour.TrackableName == "KOOOI" || mTrackableBehaviour.TrackableName == "OOKOI" ||
                mTrackableBehaviour.TrackableName == "OIKOO" || mTrackableBehaviour.TrackableName == "OOOIK" ||
                mTrackableBehaviour.TrackableName == "OIOKO" || mTrackableBehaviour.TrackableName == "OOOKI" 

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul KIO3 atau Kalium Iodat, berguna sebagai bahan campuran pada garam dapur";
            } else if (
                
                mTrackableBehaviour.TrackableName == "KKO" || mTrackableBehaviour.TrackableName == "OKK" ||
                mTrackableBehaviour.TrackableName == "KOK"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul K2O atau Kalium Oksida, berguna untuk pembuatan pupuk";
            } else if (
                
                mTrackableBehaviour.TrackableName == "MgO" || mTrackableBehaviour.TrackableName == "OMg"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul MgO atau Magnesium Oksida, berguna sebagai obat penyakit maag";
            } else if (
                
                mTrackableBehaviour.TrackableName == "NOO" || mTrackableBehaviour.TrackableName == "ONO" ||
                mTrackableBehaviour.TrackableName == "OON"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul NO2 atau Nitrogen Dioksida, berguna sebagai katalisator dalam penguraian ozon";
            } else if (
                
                mTrackableBehaviour.TrackableName == "HHHN" || mTrackableBehaviour.TrackableName == "HNHH" ||
                mTrackableBehaviour.TrackableName == "HHNH" || mTrackableBehaviour.TrackableName == "NHHH"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul NH3 atau Amonia, berguna sebagai bahan pembuat obat-obatan";
            } else if (
                
                mTrackableBehaviour.TrackableName == "ClHHHHN" || mTrackableBehaviour.TrackableName == "HHHHNCl" ||
                mTrackableBehaviour.TrackableName == "ClHHHNH" || mTrackableBehaviour.TrackableName == "HHHNClH" ||
                mTrackableBehaviour.TrackableName == "ClHHNHH" || mTrackableBehaviour.TrackableName == "HHHNHCl" ||
                mTrackableBehaviour.TrackableName == "ClHNHHH" || mTrackableBehaviour.TrackableName == "HHNClHH" ||
                mTrackableBehaviour.TrackableName == "ClNHHHH" || mTrackableBehaviour.TrackableName == "HHNHClH" ||

                mTrackableBehaviour.TrackableName == "HClHHHN" || mTrackableBehaviour.TrackableName == "HHNHHCl" ||
                mTrackableBehaviour.TrackableName == "HClHHNH" || mTrackableBehaviour.TrackableName == "HNClHHH" ||
                mTrackableBehaviour.TrackableName == "HClHNHH" || mTrackableBehaviour.TrackableName == "HNHClHH" ||
                mTrackableBehaviour.TrackableName == "HClNHHH" || mTrackableBehaviour.TrackableName == "HNHHClH" ||
                mTrackableBehaviour.TrackableName == "HHClHHN" || mTrackableBehaviour.TrackableName == "HNHHHCl" ||

                mTrackableBehaviour.TrackableName == "HHClHNH" || mTrackableBehaviour.TrackableName == "NClHHHH" ||
                mTrackableBehaviour.TrackableName == "HHClNHH" || mTrackableBehaviour.TrackableName == "NHClHHH" ||
                mTrackableBehaviour.TrackableName == "HHHClHN" || mTrackableBehaviour.TrackableName == "NHHClHH" ||
                mTrackableBehaviour.TrackableName == "HHHClNH" || mTrackableBehaviour.TrackableName == "NHHHClH" ||
                mTrackableBehaviour.TrackableName == "HHHHClN" || mTrackableBehaviour.TrackableName == "NHHHHCl"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul NH4Cl atau Amonium Klorida, berguna sebagai bahan pengisi baterai";
            } else if (
                
                mTrackableBehaviour.TrackableName == "NaBr" || mTrackableBehaviour.TrackableName == "BrNa"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul NaBr atau Natrium Bromide, berguna sebagai obat penenang syaraf";
            } else if (
                
                mTrackableBehaviour.TrackableName == "NaCl" || mTrackableBehaviour.TrackableName == "ClNa"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul NaCl atau Natrium Klorida, berguna sebagai garam dapur";
            } else if (
                
                mTrackableBehaviour.TrackableName == "NaF" || mTrackableBehaviour.TrackableName == "FNa"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul NaF atau Natrium Flourida, berguna sebagai  pengawet kayu";
            } else if (
                
                mTrackableBehaviour.TrackableName == "CHNAOOO" || mTrackableBehaviour.TrackableName == "OCHNAOO" ||
                mTrackableBehaviour.TrackableName == "CHONAOO" || mTrackableBehaviour.TrackableName == "OCHONAO" ||
                mTrackableBehaviour.TrackableName == "CHOONAO" || mTrackableBehaviour.TrackableName == "OCHOONA" ||
                mTrackableBehaviour.TrackableName == "CHOOONA" || mTrackableBehaviour.TrackableName == "OCNAHOO" ||
                mTrackableBehaviour.TrackableName == "CNAHOOO" || mTrackableBehaviour.TrackableName == "OCNAOHO" ||

                mTrackableBehaviour.TrackableName == "CNAOHOO" || mTrackableBehaviour.TrackableName == "OCNAOOH" ||
                mTrackableBehaviour.TrackableName == "CNAOOHO" || mTrackableBehaviour.TrackableName == "OCOHNAO" ||
                mTrackableBehaviour.TrackableName == "CNAOOOH" || mTrackableBehaviour.TrackableName == "OCOHONA" ||
                mTrackableBehaviour.TrackableName == "COHNAOO" || mTrackableBehaviour.TrackableName == "OCONAHO" ||
                mTrackableBehaviour.TrackableName == "COHONAO" || mTrackableBehaviour.TrackableName == "OCONAOH" ||

                mTrackableBehaviour.TrackableName == "COHOONA" || mTrackableBehaviour.TrackableName == "OCOOHNA" ||
                mTrackableBehaviour.TrackableName == "CONAHOO" || mTrackableBehaviour.TrackableName == "OCOONAH" ||
                mTrackableBehaviour.TrackableName == "CONAOHO" || mTrackableBehaviour.TrackableName == "OHCNAOO" ||
                mTrackableBehaviour.TrackableName == "CONAOOH" || mTrackableBehaviour.TrackableName == "OHCONAO" ||
                mTrackableBehaviour.TrackableName == "COOHNAO" || mTrackableBehaviour.TrackableName == "OHCOONA" ||

                mTrackableBehaviour.TrackableName == "COOHONA" || mTrackableBehaviour.TrackableName == "OHNACOO" ||
                mTrackableBehaviour.TrackableName == "COONAHO" || mTrackableBehaviour.TrackableName == "OHNAOCO" ||
                mTrackableBehaviour.TrackableName == "COONAOH" || mTrackableBehaviour.TrackableName == "OHNAOOC" ||
                mTrackableBehaviour.TrackableName == "COOOHNA" || mTrackableBehaviour.TrackableName == "OHOCNAO" ||
                mTrackableBehaviour.TrackableName == "COOONAH" || mTrackableBehaviour.TrackableName == "OHOCONA" ||

                mTrackableBehaviour.TrackableName == "HCNAOOO" || mTrackableBehaviour.TrackableName == "OHONACO" ||
                mTrackableBehaviour.TrackableName == "HCONAOO" || mTrackableBehaviour.TrackableName == "OHONAOC" ||
                mTrackableBehaviour.TrackableName == "HCOONAO" || mTrackableBehaviour.TrackableName == "OHOOCNA" ||
                mTrackableBehaviour.TrackableName == "HCOOONA" || mTrackableBehaviour.TrackableName == "OHOONAC" ||
                mTrackableBehaviour.TrackableName == "HNACOOO" || mTrackableBehaviour.TrackableName == "ONACHOO" ||

                mTrackableBehaviour.TrackableName == "HNAOCOO" || mTrackableBehaviour.TrackableName == "ONACOHO" ||
                mTrackableBehaviour.TrackableName == "HNAOOCO" || mTrackableBehaviour.TrackableName == "ONACOOH" ||
                mTrackableBehaviour.TrackableName == "HNAOOOC" || mTrackableBehaviour.TrackableName == "ONAHCOO" ||
                mTrackableBehaviour.TrackableName == "HOCNAOO" || mTrackableBehaviour.TrackableName == "ONAHOCO" ||
                mTrackableBehaviour.TrackableName == "HOCONAO" || mTrackableBehaviour.TrackableName == "ONAHOOC" ||

                mTrackableBehaviour.TrackableName == "HOCOONA" || mTrackableBehaviour.TrackableName == "ONAOCHO" ||
                mTrackableBehaviour.TrackableName == "HONACOO" || mTrackableBehaviour.TrackableName == "ONAOCOH" ||
                mTrackableBehaviour.TrackableName == "HONAOCO" || mTrackableBehaviour.TrackableName == "ONAOHCO" ||
                mTrackableBehaviour.TrackableName == "HONAOOC" || mTrackableBehaviour.TrackableName == "ONAOHOC" ||
                mTrackableBehaviour.TrackableName == "HOOCNAO" || mTrackableBehaviour.TrackableName == "ONAOOCH" ||

                mTrackableBehaviour.TrackableName == "HOOCONA" || mTrackableBehaviour.TrackableName == "ONAOOHC" ||
                mTrackableBehaviour.TrackableName == "HOONACO" || mTrackableBehaviour.TrackableName == "OOCHNAO" ||
                mTrackableBehaviour.TrackableName == "HOONAOC" || mTrackableBehaviour.TrackableName == "OOCHONA" ||
                mTrackableBehaviour.TrackableName == "HOOOCNA" || mTrackableBehaviour.TrackableName == "OOCNAHO" ||
                mTrackableBehaviour.TrackableName == "HOOONAC" || mTrackableBehaviour.TrackableName == "OOCNAOH" ||

                mTrackableBehaviour.TrackableName == "NACHOOO" || mTrackableBehaviour.TrackableName == "OOCOHNA" ||
                mTrackableBehaviour.TrackableName == "NACOHOO" || mTrackableBehaviour.TrackableName == "OOCONAH" ||
                mTrackableBehaviour.TrackableName == "NACOOHO" || mTrackableBehaviour.TrackableName == "OOHCNAO" ||
                mTrackableBehaviour.TrackableName == "NACOOOH" || mTrackableBehaviour.TrackableName == "OOHCONA" ||
                mTrackableBehaviour.TrackableName == "NAHCOOO" || mTrackableBehaviour.TrackableName == "OOHNACO" ||

                mTrackableBehaviour.TrackableName == "NAHOCOO" || mTrackableBehaviour.TrackableName == "OOHNAOC" ||
                mTrackableBehaviour.TrackableName == "NAHOOCO" || mTrackableBehaviour.TrackableName == "OOHOCNA" ||
                mTrackableBehaviour.TrackableName == "NAHOOOC" || mTrackableBehaviour.TrackableName == "OOHONAC" ||
                mTrackableBehaviour.TrackableName == "NAOCHOO" || mTrackableBehaviour.TrackableName == "OONACHO" ||
                mTrackableBehaviour.TrackableName == "NAOCOHO" || mTrackableBehaviour.TrackableName == "OONACOH" ||

                mTrackableBehaviour.TrackableName == "NAOCOOH" || mTrackableBehaviour.TrackableName == "OONAHCO" ||
                mTrackableBehaviour.TrackableName == "NAOHCOO" || mTrackableBehaviour.TrackableName == "OONAHOC" ||
                mTrackableBehaviour.TrackableName == "NAOHOCO" || mTrackableBehaviour.TrackableName == "OONAOCH" ||
                mTrackableBehaviour.TrackableName == "NAOHOOC" || mTrackableBehaviour.TrackableName == "OONAOHC" ||
                mTrackableBehaviour.TrackableName == "NAOOCHO" || mTrackableBehaviour.TrackableName == "OOOCHNA" ||

                mTrackableBehaviour.TrackableName == "NAOOCOH" || mTrackableBehaviour.TrackableName == "OOOCNAH" ||
                mTrackableBehaviour.TrackableName == "NAOOHCO" || mTrackableBehaviour.TrackableName == "OOOHCNA" ||
                mTrackableBehaviour.TrackableName == "NAOOHOC" || mTrackableBehaviour.TrackableName == "OOOHNAC" ||
                mTrackableBehaviour.TrackableName == "NAOOOCH" || mTrackableBehaviour.TrackableName == "OOONACH" ||
                mTrackableBehaviour.TrackableName == "NAOOOHC" || mTrackableBehaviour.TrackableName == "OOONAHC"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul NaHCO3 atau Soda Kue, berguna sebagai bahan pembuat kue";
            } else if (
                
                mTrackableBehaviour.TrackableName == "NaClO" || mTrackableBehaviour.TrackableName == "ClONa" ||
                mTrackableBehaviour.TrackableName == "NaOCl" || mTrackableBehaviour.TrackableName == "OClNa" ||
                mTrackableBehaviour.TrackableName == "ClNaO" || mTrackableBehaviour.TrackableName == "ONaCl"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul NaClO atau Pemutih, berguna sebagai pemutih pakaian";
            } else if (
                
                mTrackableBehaviour.TrackableName == "NaOH" || mTrackableBehaviour.TrackableName == "HONa" ||
                mTrackableBehaviour.TrackableName == "NaHO" || mTrackableBehaviour.TrackableName == "OHNa" ||
                mTrackableBehaviour.TrackableName == "HNaO" || mTrackableBehaviour.TrackableName == "ONaH"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul NaOH atau Natrium Hidroksida, berguna di bidang industri sabun, kertas, dll";
            } else if (
                
                mTrackableBehaviour.TrackableName == "OO"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul O2 atau Oksigen, berguna sebagai gas pembantu pernafasan";
            } else if (
                
                mTrackableBehaviour.TrackableName == "OOO"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul O3 atau Ozon, berguna sebagai pembasmi hama air minum";
            } else if (
                
                mTrackableBehaviour.TrackableName == "FFFFFFS" || mTrackableBehaviour.TrackableName == "FFSFFFF" ||
                mTrackableBehaviour.TrackableName == "FFFFFSF" || mTrackableBehaviour.TrackableName == "FSFFFFF" ||
                mTrackableBehaviour.TrackableName == "FFFFSFF" || mTrackableBehaviour.TrackableName == "SFFFFFF" ||
                mTrackableBehaviour.TrackableName == "FFFSFFF"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul SF6 atau Belerang Hexafluorida, berguna sebagai insulator";
            } else if (
                
                mTrackableBehaviour.TrackableName == "SOO" || mTrackableBehaviour.TrackableName == "OSO" ||
                mTrackableBehaviour.TrackableName == "OOS"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul SO2 atau Belerang Dioksida, berguna sebagai fungisida";
            } else if (
                
                mTrackableBehaviour.TrackableName == "ZnClCl" || mTrackableBehaviour.TrackableName == "ClClZn" ||
                mTrackableBehaviour.TrackableName == "ClZnCl"

                ) {
                TextDescription.GetComponent<Text>().text = "Ini merupakan molekul ZnCl2 atau Seng Klorida, berguna sebagai bahan pematri (solder)";
            }

        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }
            PanelMenu.gameObject.SetActive(false);
            PanelInformasi.gameObject.SetActive(false);
            PanelScanMarker.gameObject.SetActive(true);
            TextTargetName.gameObject.SetActive(false);
            TextDescription.gameObject.SetActive(false);
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS

    }
}
