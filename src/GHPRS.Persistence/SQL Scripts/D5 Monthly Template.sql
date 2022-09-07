CREATE OR REPLACE VIEW D5_Monthly_Reporting AS
SELECT "Priority Tier (1, 2, 3, 4)",
       "Month",
       "Partner",
       "Agency",
       "Region",
       "District",
       "Council",
       "Ward",
       "Site Name",
       "Site ID (from DATIM)",
       "CLIENT_A_TX_NEW",
       "CLIENT_A_TX_CURR",
       "CONTACT_A",
       "IPV_HX_SCREEN",
       "KNOWN_POS_A",
       "NEG_A"                                                   AS "C_NEG_A",
       "POS_A"                                                   AS "C_POS_A",
       "CONTACT_PEDS",
       "KNOWN_POS_PEDS",
       "NEG_PEDS"                                                AS "C_NEG_PEDS",
       "POS_PEDS"                                                AS "C_POS_PEDS",
       "CLIENT_A_TX_NEW" + "CLIENT_A_TX_CURR"                    AS "INDEX_A",
       "CONTACT_A"                                               AS "INDEX_SEX",
       "IPV_HX_SCREEN"                                           AS "HTS_SEX",
       "KNOWN_POS_A" + "POS_A"                                   AS "POS_SEX",
       "OPD_P" + "OPD_A"                                         AS "OPD",
       "SCREEN_A",
       "SCREEN_ELIG_A",
       "SCREEN_HTS_A",
       "SCREEN_HTS_POS_A",
       "LCM_A",
       "REFILL",
       "SDI_0_7",
       "SDI_8_14",
       "SDI_15",
       "TX_PREV",
       "TX_CURR",
       "XFER_IN",
       "XFER_OUT",
       "XFER_DEATH",
       "MMS_1",
       "MMS_2",
       "MMS_3",
       "TB_PREV_D",
       "TB_PREV_N",
       "TB_PREV_NEW",
       "VL_ELIG_P" + "VL_ELIG _A "                               AS "VL_ELIG",
       "VL_D_P" + "VL_D_A"                                       AS "VL_D",
       "VL_N_P" + "VL_N_A"                                       AS "VL_N",
       "HTS_M_A" + "HTS_M_P"                                     AS "HTS_M",
       "HTS_F_A" + "HTS_F_P"                                     AS "HTS_F",
       "HTS_F_P" + "HTS_M_P"                                     AS "HTS_PEDS",
       "POS_M_A" + "POS_M_P"                                     AS "POS_M",
       "POS_F_P" + "POS_F_A"                                     AS "POS_F",
       "POS_M_P" + "POS_F_P"                                     AS "POS_PEDS",
       "TX_NEW_M_A" + "TX_NEW_M_P"                               AS "TX_NEW_M",
       "TX_NEW_F_P" + "TX_NEW_F_A"                               AS "TX_NEW_F",
       "TX_NEW_M_P" + "TX_NEW_F_P"                               AS "TX_NEW_PEDS",
       "tx_curr.u15.m"                                           AS "TX_CURR_PEDS_M",
       "tx_curr.u15.f"                                           AS "TX_CURR_PEDS_F",
       "tx_curr.o15.m"                                           AS "TX_CURR_A_M",
       "tx_curr.o15.f"                                           AS "TX_CURR_A_F",
       "MMS_6_P" + "MMS_6_A"                                     AS "MMS_6",
       "LFTU_A" + "LFTU_P"                                       AS "LTFU",
       "L_SELF_REF_P" + "L_SELF_REF_A"                           AS "L_SELF_REF",
       "L_CTC_P" + "L_CTC_A"                                     AS "L_CTC",
       "L_RTX_P" + "L_RTX_A"                                     AS "L_RTX",
       "L_DXD_A" + "L_DXD_P"                                     AS "L_DXD",
       "L_REFX_A" + "L_REFX_P"                                   AS "L_REFX",
       "L_WRNGD_P" + "L_WRNGD_A"                                 AS "L_WRNGD",
       "L_UNBL_P" + "L_UNBL_A"                                   AS "L_UNBL",
       "L_NOATTMPT_P" + "L_NOATTMPT_A"                           AS "L_NOATTMPT",
       "HTS_2 months",
       "POS_preg",
       "VL_ELIG_P"                                               AS "VL_ELIG <15",
       "VL_D_P"                                                  AS "VL_D<15",
       "VL_N_P"                                                  AS "VL_N<15",
       "VL_ELIG _A "                                             AS "VL_ELIG>15",
       "VL_D_A"                                                  AS "VL_D>15",
       "VL_N_A"                                                  AS "VL_N>15",
       "HTS_M_A" + "HTS_M_P" + "HTS_F_A" + "HTS_F_P"             AS "HTS_TST_ALL",
       "POS_M_A" + "POS_M_A" + "POS_F_P" + "POS_F_A"             AS "HTS_POS_ALL",
       "TX_NEW_M_A" + "TX_NEW_M_P" + "TX_NEW_F_P" + "TX_NEW_F_A" AS "TX_NEW_ALL",
       case
           when ("HTS_M_A" + "HTS_M_P" + "HTS_F_A" + "HTS_F_P") = 0 then 0
           else ("POS_M_A" + "POS_M_A" + "POS_F_P" + "POS_F_A") / ("HTS_M_A" + "HTS_M_P" + "HTS_F_A" + "HTS_F_P")
           end                                                   AS "Yield_All",
       case
           when (("TX_NEW_M_A" + "TX_NEW_F_A") + ("tx_curr.o15.m" + "tx_curr.o15.f")) = 0 then 0
           else (("CLIENT_A_TX_NEW" + "CLIENT_A_TX_CURR") /
                 (("TX_NEW_M_A" + "TX_NEW_F_A") + ("tx_curr.o15.m" + "tx_curr.o15.f"))) * 100
           end                                                   AS "Index Acceptance Rate",
       case
           when ("CLIENT_A_TX_NEW" + "CLIENT_A_TX_CURR") = 0 then 0
           else ("CONTACT_A" / ("CLIENT_A_TX_NEW" + "CLIENT_A_TX_CURR")) * 100
           end                                                   AS "Index Contact Elicitation",
       case
           when "CONTACT_A" = 0 then 0
           else ("IPV_HX_SCREEN" / "CONTACT_A") * 100
           end                                                   AS "Index Testing Rate",
       case
           when "IPV_HX_SCREEN" = 0 then 0
           else (("KNOWN_POS_A" + "POS_A") / "IPV_HX_SCREEN") * 100
           end                                                   AS "Index Testing Yield",
       case
           when ("OPD_P" + "OPD_A") = 0 then 0
           else ("SCREEN_A" / ("OPD_P" + "OPD_A")) * 100
           end                                                   AS "Optimized PITC Screening",
       case
           when "SCREEN_A" = 0 then 0
           else ("SCREEN_ELIG_A" / "SCREEN_A") * 100
           end                                                   AS "Optimized PITC Eligibility Rate",
       case
           when "SCREEN_ELIG_A" = 0 then 0
           else ("SCREEN_HTS_A" / "SCREEN_ELIG_A") * 100
           end                                                   AS "Optimized PITC Testing Rate",
       case
           when "SCREEN_HTS_A" = 0 then 0
           else ("SCREEN_HTS_POS_A" / "SCREEN_HTS_A") * 100
           end                                                   AS "Optimized PITC Testing Yield",
       case
           when (("POS_M_A" + "POS_M_P") + ("POS_F_P" + "POS_F_A")) = 0 then 0
           else ("LCM_A" / (("POS_M_A" + "POS_M_P") + ("POS_F_P" + "POS_F_A"))) * 100
           end                                                   AS "LCM Uptake",
       case
           when ("SDI_0_7" + "SDI_8_14" + "SDI_15") = 0 then 0
           else ("SDI_0_7" / ("SDI_0_7" + "SDI_8_14" + "SDI_15")) * 100
           end                                                   AS "Same Day Initiation",
       case
           when ("SDI_0_7" + "SDI_8_14" + "SDI_15") = 0 then 0
           else ("REFILL" / ("SDI_0_7" + "SDI_8_14" + "SDI_15")) * 100
           end                                                   AS "Early Retention",
       case
           when ("XFER_IN" + "TX_PREV" + ("TX_NEW_M_A" + "TX_NEW_M_P") + ("tx_curr.o15.m" + "tx_curr.o15.f") +
                 ("TX_NEW_M_P" + "TX_NEW_F_P") - ("XFER_OUT" + "XFER_DEATH")) = 0 then 0
           else ("TX_CURR" /
                 ("XFER_IN" + "TX_PREV" + ("TX_NEW_M_A" + "TX_NEW_M_P") + ("tx_curr.o15.m" + "tx_curr.o15.f") +
                  ("TX_NEW_M_P" + "TX_NEW_F_P") - ("XFER_OUT" + "XFER_DEATH"))) * 100
           end                                                   AS "Retention",
       case
           when ("MMS_1" + "MMS_2" + "MMS_3") = 0 then 0
           else ("MMS_3" / ("MMS_1" + "MMS_2" + "MMS_3")) * 100
           end                                                   AS "Multi Month Scripting",
       case
           when "TB_PREV_D" = 0 then 0
           else ("TB_PREV_N" / "TB_PREV_D") * 100
           end                                                   AS "IPT Completion",
       case
           when ("VL_ELIG_P" + "VL_ELIG _A ") = 0 then 0
           else (("VL_D_P" + "VL_D_A") / ("VL_ELIG_P" + "VL_ELIG _A ")) * 100
           end                                                   AS "Viral Load Coverage",
       case
           when ("VL_D_P" + "VL_D_A") = 0 then 0
           else (("VL_N_P" + "VL_N_A") / ("VL_D_P" + "VL_D_A")) * 100
           end                                                   AS "Viral Load Suppression",
       "TX_NEW_M_A" + "TX_NEW_M_P" + "TX_NEW_F_P" + "TX_NEW_F_A" AS "TX_NEW",
       "HTS_M_A" + "HTS_M_P" + "HTS_F_A" + "HTS_F_P"             AS "HTS_TST",
       "POS_M_A" + "POS_M_A" + "POS_F_P" + "POS_F_A"             AS "HTS_POS",
       case
           when ("HTS_M_A" + "HTS_M_P" + "HTS_F_A" + "HTS_F_P") = 0 then 0
           else ("POS_M_A" + "POS_M_A" + "POS_F_P" + "POS_F_A") / ("HTS_M_A" + "HTS_M_P" + "HTS_F_A" + "HTS_F_P")
           end                                                   AS "All Yield",
       "VL_D_A"                                                  AS "Viral Load Coverage_ADL",
       "VL_N_A"                                                  AS "Viral Load Suppression_ADL",
       "VL_D_P"                                                  AS "Viral Load Coverage_PEDS",
       "VL_N_P"                                                  AS "Viral Load Suppression_PEDS",
       "CONTACT_A" + "CONTACT_PEDS"                              AS "Contacts Elicited_All",
       "NEG_A" + "POS_A" + "NEG_PEDS" + "POS_PEDS"               AS "Contacts Tested_All",
       "POS_A" + "POS_PEDS"                                      AS "C_POS_All",
       case
           when ("NEG_A" + "POS_A" + "NEG_PEDS" + "POS_PEDS") = 0 then 0
           else (("POS_A" + "POS_PEDS") / ("NEG_A" + "POS_A" + "NEG_PEDS" + "POS_PEDS")) * 100
           end                                                   AS "Index Yield"

FROM public."USAIDMonthlyReportingTemplate_v1.FacilityData";