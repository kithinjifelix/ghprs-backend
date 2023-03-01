using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GHPRS.Core.Entities
{
    [Table("StagingMerData")]
    public class MerData : Entity
    {
        public string orgunituid { get; set; }
        public string sitename { get; set; }
        public string operatingunit { get; set; }
        public string operatingunituid { get; set; }
        public string country { get; set; }
        public string snu1 { get; set; }
        public string snu1uid { get; set; }
        public string psnu { get; set; }
        public string psnuuid { get; set; }
        public string snuprioritization { get; set; }
        public string typemilitary { get; set; }
        public string dreams { get; set; }
        public string prime_partner_name { get; set; }
        public string funding_agency { get; set; }
        public string mech_code { get; set; }
        public string mech_name { get; set; }
        public string prime_partner_duns { get; set; }
        public string prime_partner_uei { get; set; }
        public string award_number { get; set; }
        public string communityuid { get; set; }
        public string community { get; set; }
        public string facilityuid { get; set; }
        public string facility { get; set; }
        public string sitetype { get; set; }
        public string indicator { get; set; }
        public string numeratordenom { get; set; }
        public string indicatortype { get; set; }
        public string disaggregate { get; set; }
        public string standardizeddisaggregate { get; set; }
        public string categoryoptioncomboname { get; set; }
        public string ageasentered { get; set; }
        public string age_2018 { get; set; }
        public string age_2019 { get; set; }
        public string trendscoarse { get; set; }
        public string sex { get; set; }
        public string statushiv { get; set; }
        public string statustb { get; set; }
        public string statuscx { get; set; }
        public string hiv_treatment_status { get; set; }
        public string otherdisaggregate { get; set; }
        public string otherdisaggregate_sub { get; set; }
        public string modality { get; set; }
        public string fiscal_year { get; set; }
        public string targets { get; set; }
        public string qtr1 { get; set; }
        public string qtr2 { get; set; }
        public string qtr3 { get; set; }
        public string qtr4 { get; set; }
        public string cumulative { get; set; }
        public string source_name { get; set; }

        public int FileUploadsId { get; set; }
        public virtual FileUploads FileUploads { get; set; }
    }
}
